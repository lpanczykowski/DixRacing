using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace DixRacing.DataAccess
{
    public class DapperContext : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection is { State: ConnectionState.Open })
            {
                return _connection;
            }

            _connection = new SqliteConnection(_connectionString);
            _connection.Open();

            return _connection;
        }

        public void Dispose()
        {
            if (_connection is { State: ConnectionState.Open })
            {
                _connection.Dispose();
            }
        }
    }
}
