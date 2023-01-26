using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SqlClient;

namespace Data.Context
{
    internal class DBContext
    {
        private readonly string _connectionStrings = "Data Source=bd;Initial Catalog=db;User ID=db;Password=db;Pooling=True;Connect Timeout=180; Application Name=Integration System;Trusted_Connection=False; TrustServerCertificate=True";

        private readonly string _sqliteConnectionStrings = "Data Source=C:\\DapperCrud.db";

        public IDbConnection SqlConnection()
            => new SqlConnection(_connectionStrings);

        public IDbConnection SqliteConnection()
            => new SqliteConnection(_sqliteConnectionStrings);
    }
}
