using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Sept2022.SqlDataAccess
{
    public class ReadConfiguration : IReadConfiguration
    {
        public string GetConnectionString(string configName)
        {
            string connectionString = null;
            foreach (ConnectionStringSettings settings in ConfigurationManager.ConnectionStrings)
            {
                if (string.Compare(settings.Name, configName, true) == 0)
                {
                    connectionString = settings.ConnectionString;
                }
            }

            return connectionString;
        }
    }
}
