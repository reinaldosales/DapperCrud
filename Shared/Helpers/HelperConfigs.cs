using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Shared.Helpers
{
    public static class HelperConfigs
    {
        private static string Get(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        private static string GetConnectionStrings(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string DefaultConnectionStrings
        {
            get
            {
                return GetConnectionStrings("LocalSqlServer");
            }
        }

        public static string SecretKey
        {
            get
            {
                return Get("SecretKey");
            }
        }
    }

}
