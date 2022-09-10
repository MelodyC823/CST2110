using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

namespace _2110.DataAccess
{
    public class ReadConfiguration: IReadConfiguration
    {
        public string GetConnectionString(string configName)
        {
            string connectionString = null;
            foreach(ConnectionStringSettings settings in ConfigurationManager.ConnectionStrings)
            {
                if(string.Compare(settings.Name,configName,true)==0)
                {
                    connectionString = settings.ConnectionString;

                }
            }

            return connectionString;

        }
    }
}
