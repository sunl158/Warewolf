#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Services.Sql;
using Oracle.ManagedDataAccess.Client;
using Unlimited.Framework.Converters.Graph;

namespace Dev2.Runtime.ServiceModel.Esb.Brokers
{
    /// <summary>
    /// A Oracle SQL specific database broker implementation
    /// </summary>
    public class OracleDatabaseBroker : AbstractDatabaseBroker<OracleServer>
    {
        protected override string NormalizeXmlPayload(string payload)
        {
            var result = new StringBuilder();

            var xDoc = new XmlDocument();
            xDoc.LoadXml(payload);
            var nl = xDoc.SelectNodes("//NewDataSet/Table/*[starts-with(local-name(),'XML_')]");
            var foundXMLFrags = 0;

            if (nl != null)
            {
                foreach (XmlNode n in nl)
                {
                    var tmp = n.InnerXml;
                    result = result.Append(tmp);
                    foundXMLFrags++;
                }
            }

            var res = result.ToString();

            if (foundXMLFrags >= 1)
            {
                res = "<FromXMLPayloads>" + res + "</FromXMLPayloads>";
            }
            else
            {
                if (foundXMLFrags == 0)
                {
                    res = payload;
                }
            }

            return base.NormalizeXmlPayload(res);
        }
        public override List<string> GetDatabases(DbSource dbSource)
        {
            VerifyArgument.IsNotNull("dbSource", dbSource);
            using (var server = CreateDbServer(dbSource))
            {
                server.Connect(dbSource.ConnectionString);
                return server.FetchDatabases();
            }
        }

        #region Overrides of AbstractDatabaseBroker<MySqlServer>

        public override ServiceMethodList GetServiceMethods(DbSource dbSource)
        {
            VerifyArgument.IsNotNull("dbSource", dbSource);


            var serviceMethods = new ServiceMethodList();

            //
            // Function to handle procedures returned by the data broker
            //
            Func<IDbCommand, IList<IDbDataParameter>, IList<IDbDataParameter>, string, string, bool> procedureFunc = (command, parameters, outparameters, helpText, executeAction) =>
            {
                var serviceMethod = CreateServiceMethod(command, parameters, outparameters, helpText, executeAction);
                serviceMethods.Add(serviceMethod);
                return true;
            };

            //
            // Function to handle functions returned by the data broker
            //
            Func<IDbCommand, IList<IDbDataParameter>, IList<IDbDataParameter>, string, string, bool> functionFunc = (command, parameters, outparameters, helpText, executeAction) =>
            {
                var serviceMethod = CreateServiceMethod(command, parameters, outparameters, helpText, executeAction);
                serviceMethods.Add(serviceMethod);
                return true;
            };

            //
            // Get stored procedures and functions for this database source
            //
            using(var server = CreateDbServer(dbSource))
            {
                server.Connect(dbSource.ConnectionString);
                server.FetchStoredProcedures(procedureFunc, functionFunc, false, dbSource.DatabaseName);
            }

            // Add to cache ;)

            return serviceMethods;
        }

        #region Overrides of AbstractDatabaseBroker<MySqlServer>

        protected override OracleServer CreateDbServer(DbSource dbSource) => new OracleServer();

        static ServiceMethod CreateServiceMethod(IDbCommand command, IEnumerable<IDataParameter> parameters, IEnumerable<IDataParameter> outParameters, string sourceCode, string executeAction) => new ServiceMethod(command.CommandText, sourceCode, parameters.Select(MethodParameterFromDataParameter), null, null, executeAction)
        {
            OutParameters = outParameters.Select(MethodParameterFromDataParameter).ToList()
        };
        #endregion

        #endregion

        public override IOutputDescription TestService(DbService dbService)
        {
            VerifyArgument.IsNotNull("dbService", dbService);
            VerifyArgument.IsNotNull("dbService.Source", dbService.Source);

            IOutputDescription result;
            using (var server = CreateDbServer(dbService.Source as DbSource))
            {
                server.Connect(((DbSource)dbService.Source).ConnectionString);
                server.BeginTransaction();
                try
                {
                    //
                    // Execute command and normalize XML
                    //
                    var command = CommandFromServiceMethod(server, dbService.Method);



                    var databaseName = (dbService.Source as DbSource).DatabaseName;
                    var fullProcedureName = dbService.Method.ExecuteAction.Substring(dbService.Method.ExecuteAction.IndexOf(".", StringComparison.Ordinal) + 1);

                    
                    var outParams = server.GetProcedureOutParams(fullProcedureName, databaseName);
                    var countRefCursors = outParams.Count(parameter => parameter.OracleDbType == OracleDbType.RefCursor);
                    var countSingleParams = outParams.Count(parameter => parameter.OracleDbType != OracleDbType.RefCursor);
                    if (countRefCursors > 1)
                    {
                        throw new Exception("Multiple Ref Cursor are not currently supported.");
                    }
                    if (countRefCursors >= 1 && countSingleParams >= 1)
                    {
                        throw new Exception("Mixing single return values and Ref Cursors are not currently supported.");
                    }
                    var dbDataParameters = server.GetProcedureInputParameters(command, databaseName, fullProcedureName);
                    var cmd = command.Connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = databaseName +"."+ fullProcedureName;
                    cmd.CommandTimeout = command.CommandTimeout;
                    var parameters = dbService.Method.Parameters;
                    foreach (var dbDataParameter in dbDataParameters)
                    {
                        var foundParameter = parameters.FirstOrDefault(parameter => parameter.Name == dbDataParameter.ParameterName);
                        if (foundParameter != null)
                        {
                            dbDataParameter.Value = foundParameter.Value;                            
                        }
                       cmd.Parameters.Add(dbDataParameter);
                    }

                    

                    
                    foreach (var dbDataParameter in outParams)
                    {
                        cmd.Parameters.Add(dbDataParameter);
                    }
                    var dataTable = server.FetchDataTable(cmd);

                    //
                    // Map shape of XML
                    //
                    result = OutputDescriptionFactory.CreateOutputDescription(OutputFormats.ShapedXML);
                    var dataSourceShape = DataSourceShapeFactory.CreateDataSourceShape();
                    result.DataSourceShapes.Add(dataSourceShape);

                    var dataBrowser = DataBrowserFactory.CreateDataBrowser();
                    dataSourceShape.Paths.AddRange(dataBrowser.Map(dataTable));
                    cmd.Dispose();
                }
                finally
                {
                    server.RollbackTransaction();
                }
            }
            
            return result;
        }
    }
}