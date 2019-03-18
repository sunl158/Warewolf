#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Xml;
using Dev2.Common;
using Dev2.Common.Interfaces.Services.Sql;
using Microsoft.Win32;
using Warewolf.Resource.Errors;

namespace Dev2.Services.Sql
{
    public class ODBCServer : IDbServer
    {
        readonly IDbFactory _factory;
        OdbcConnection _connection;
        IDbTransaction _transaction;
        bool _disposed;
        IDbCommand _command;
        readonly bool _testing;

        public ODBCServer(IDbFactory dbFactory)
        {
            _factory = dbFactory;
        }
        public ODBCServer()
        {
            _factory = new ODBCFactory();
        }

        public int? CommandTimeout { get; set; }
        public ODBCServer(IDbFactory factory, IDbCommand command, IDbTransaction transaction)
        {
            _factory = factory;
            _testing = true;
            _command = command;
            _transaction = transaction;
        }
        public bool Connect(string connectionString, CommandType commandType, string commandText)
        {
            _connection = (OdbcConnection)_factory.CreateConnection(connectionString);

            VerifyArgument.IsNotNull("commandText", commandText);

            return ReturnConnection(commandType, commandText);
        }

        public bool ReturnConnection(CommandType commandType, string commandText)
        {
            commandType = SetCommandType(commandText, commandType);
            _command = _factory.CreateCommand(_connection, commandType, commandText, CommandTimeout);
            if (!_testing)
            {
                _connection.Open();
            }

            return true;
        }

        public CommandType SetCommandType(string commandText, CommandType commandType)
        {
            if (commandText.ToLower().StartsWith("select ") || commandText.ToLower().StartsWith("update ") || commandText.ToLower().StartsWith("delete "))
            {
                commandType = CommandType.Text;
            }
            return commandType;
        }
        public string ConnectionString => _connection?.ConnectionString;

        public bool IsConnected
        {
            get
            {
                if (_testing)
                {
                    return true;
                }
                return _connection != null && _connection.State == ConnectionState.Open;
            }
        }

        public void BeginTransaction()
        {
            if (IsConnected)
            {
                try
                {
                    _transaction = _connection.BeginTransaction();
                }
                catch(Exception e)
                {
                    Dev2Logger.Error(@"Error creating transaction",e, GlobalConstants.WarewolfError);
                }
            }
        }
        public DataTable FetchXmlData()
        {
            var table = new DataTable();
            table.Columns.Add("ReadForXml");
            VerifyConnection();
            try
            {
                if (_command.CommandType == CommandType.StoredProcedure)
                {
                    _command.CommandType = CommandType.Text;
                }

                var reader = _factory.FetchDataSet(_command);
                var doc = new XmlDocument();
                doc.LoadXml(reader.GetXml());
                table.LoadDataRow(new object[] { doc.InnerText }, true);
                return table;

            }
            catch (Exception e)
            {
                if (!e.Message.Equals(ErrorResource.NotXmlResults))
                {
                    throw;
                }
                table.LoadDataRow(new object[] { "Error" }, true);
                return table;
            }
            table.LoadDataRow(new object[] { "Error" }, true);
            return table;
        }
        public void Connect(string connectionString)
        {
            if (!_testing)
            {
                _connection = (OdbcConnection)_factory.CreateConnection(connectionString);
                _connection.Open();
            }
        }

        public IDbCommand CreateCommand()
        {
            VerifyConnection();
            if (_testing)
            {
                return null;
            }
            IDbCommand command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }

        #region VerifyConnection

        void VerifyConnection()
        {
            if (!IsConnected)
            {
                throw new Exception("Please connect first.");
            }
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources. 
                if (disposing)
                {
                    // Dispose managed resources.
                    _transaction?.Dispose();

                    _command?.Dispose();
                    DisposeConnection();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here. 
                // If disposing is false, 
                // only the following code is executed.

                // Note disposing has been done.
                _disposed = true;
            }
        }

        private void DisposeConnection()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }

        public List<string> FetchDatabases() => GetDSN();

        public DataTable FetchDataTable(IDbCommand command)
        {
            VerifyArgument.IsNotNull("command", command);

            return ExecuteReader(command, CommandBehavior.SchemaOnly & CommandBehavior.KeyInfo,
                reader => _factory.CreateTable(reader, LoadOption.OverwriteChanges));
        }
        public DataTable FetchDataTable()
        {
            VerifyConnection();
            return ExecuteReader(_command, CommandBehavior.SchemaOnly & CommandBehavior.KeyInfo,
                reader => _factory.CreateTable(reader, LoadOption.OverwriteChanges));
        }
		public DataSet FetchDataSet(IDbCommand command)
		{
			VerifyArgument.IsNotNull("command", command);

			return _factory.FetchDataSet(command);
		}
		public int ExecuteNonQuery(IDbCommand command)
		{
			VerifyArgument.IsNotNull("command", command);

			return _factory.ExecuteNonQuery(command);
		}

		public int ExecuteScalar(IDbCommand command)
		{
			VerifyArgument.IsNotNull("command", command);

			return _factory.ExecuteScalar(command);
		}
		public static T ExecuteReaader<T>(IDbCommand command, CommandBehavior commandBehavior, Func<IDataAdapter, T> handler)
        {
            try
            {
                
                
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(command as OdbcCommand))
                {                    
                    return handler(adapter);
                }
            }
            catch (DbException e)
            {
                if (e.Message.Contains("There is no text for object "))
                {
                    var exceptionDataTable = new DataTable("Error");
                    exceptionDataTable.Columns.Add("ErrorText");
                    exceptionDataTable.LoadDataRow(new object[] { e.Message }, true);
                    return handler(new OdbcDataAdapter());
                }
                throw;
            }
        }


        static T ExecuteReader<T>(IDbCommand command, CommandBehavior commandBehavior, Func<IDataAdapter, T> handler)
        {
            if (command.CommandType == CommandType.StoredProcedure)
            {
                command.CommandType = CommandType.Text;
            }
            return ExecuteReaader(command, commandBehavior, handler);
        }

        public void FetchStoredProcedures(Func<IDbCommand, List<IDbDataParameter>, List<IDbDataParameter>, string, string, bool> procedureProcessor, Func<IDbCommand, List<IDbDataParameter>, List<IDbDataParameter>, string, string, bool> functionProcessor)
        {
            throw new NotImplementedException();
        }

        public void FetchStoredProcedures(Func<IDbCommand, List<IDbDataParameter>, List<IDbDataParameter>, string, string, bool> procedureProcessor, Func<IDbCommand, List<IDbDataParameter>, List<IDbDataParameter>, string, string, bool> functionProcessor, bool continueOnProcessorException, string dbName)
        {
            throw new NotImplementedException();
        }

        public void FetchStoredProcedures(Func<IDbCommand, List<IDbDataParameter>, string, string, bool> procedureProcessor, Func<IDbCommand, List<IDbDataParameter>, string, string, bool> functionProcessor)
        {
            throw new NotImplementedException();
        }

        public void FetchStoredProcedures(Func<IDbCommand, List<IDbDataParameter>, string, string, bool> procedureProcessor, Func<IDbCommand, List<IDbDataParameter>, string, string, bool> functionProcessor, bool continueOnProcessorException, string dbName)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        #region helper methods

        public List<string> GetDSN()
        {
            var list = new List<string>();
            list.AddRange(EnumDsn(Registry.CurrentUser, false));
            list.AddRange(EnumDsn(Registry.LocalMachine, false));
            if (Environment.Is64BitOperatingSystem)
            {
                list.AddRange(EnumDsn(Registry.CurrentUser, true));
                list.AddRange(EnumDsn(Registry.LocalMachine, true));
            }
            return list;
        }

        IEnumerable<string> EnumDsn(RegistryKey rootKey, bool is64)
        {
            var regKey = rootKey.OpenSubKey(@"Software\ODBC\ODBC.INI\ODBC Data Sources");
            if (is64)
            {
                regKey = rootKey.OpenSubKey(@"Software\Wow6432Node\ODBC\ODBC.INI\ODBC Data Sources");
            }
            if (regKey != null)
            {
                foreach (string name in regKey.GetValueNames())
                {
                    yield return name;
                }
            }
        }

        #endregion
    }
}
