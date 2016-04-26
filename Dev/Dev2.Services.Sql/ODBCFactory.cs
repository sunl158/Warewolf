﻿using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dev2.Common;
using Dev2.Common.Interfaces.Services.Sql;
using System.Data.Odbc;
using Warewolf.Security.Encryption;

namespace Dev2.Services.Sql
{
    [ExcludeFromCodeCoverage]
    internal class ODBCFactory : IDbFactory
    {
        #region Implementation of IDbFactory

        public IDbConnection CreateConnection(string connectionString)
        {
            VerifyArgument.IsNotNull("connectionString", connectionString);
            if (connectionString.CanBeDecrypted())
            {
                connectionString = DpapiWrapper.Decrypt(connectionString);
            }
            return new OdbcConnection(connectionString);
        }

        public IDbCommand CreateCommand(IDbConnection connection, CommandType commandType, string commandText)
        {
            return new OdbcCommand(commandText, connection as OdbcConnection)
            {
                CommandType = commandType,
                CommandTimeout = (int)GlobalConstants.TransactionTimeout.TotalSeconds
            };
        }

        public DataTable GetSchema(IDbConnection connection, string collectionName)
        {
            return GetOdbcServerSchema(connection);
        }

        DataTable GetOdbcServerSchema(IDbConnection connection)
        {
            if (!(connection is OdbcConnection))
                throw new Exception("Invalid Oracle connection");

            return ((OdbcConnection)connection).GetSchema();
        }

        public DataTable CreateTable(IDataReader reader, LoadOption overwriteChanges)
        {
            var table = new DataTable();
            table.Load(reader, LoadOption.OverwriteChanges);
            return table;
        }

        public DataSet FetchDataSet(IDbCommand command)
        {
            if (!(command is OdbcCommand))
                throw new Exception("Invalid OracleCommand expected.");
            using (var dataSet = new DataSet())
            {
                using (var adapter = new OdbcDataAdapter(command as OdbcCommand))
                {
                    adapter.Fill(dataSet);
                }
                return dataSet;
            }



        }

        #endregion
    }
}
