using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using _2110.RestaurantDataAccess;

namespace _2110.DataAccess
{
    public class ReadConfiguration: IReadConfiguration
    {
        public string GetConnectionString(string configName)
        {
            foreach(ConnectionStringSettings settings in ConfigurationManager.ConnectionStrings)
            {
                if(string.Compare(settings.Name,configName,true)==0)
                {
                    return settings.ConnectionString;

                }
            }

            return null;

        }
    }
}
