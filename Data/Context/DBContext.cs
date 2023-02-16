using Shared.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace Data.Context
{
    public class DBContext
    {
        protected string ConnectionString { get; private set; }

        public DBContext()
        {
            ConnectionString = HelperConfigs.DefaultConnectionStrings;
        }

        public IDbConnection SqlConnection()
            => new SqlConnection(ConnectionString);
    }
}
