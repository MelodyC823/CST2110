using System;
using System.Collections.Generic;
using System.Text;
using _2110.Common;

namespace _2110.Common
{
    public class StorageConfiguration : IStorageConfiguration
    {
        private static string connectionString = "DefaultEndpointsProtocol = https; AccountName=storage1yf;AccountKey=2aUiQXJwZdvE7mV/9BXNL7K41gVIEb92Xap2Uxda3Q+ci9Eu3sLLfOp0Qvj6EblKdsrkimQaeuER+AStXsYo4A==;EndpointSuffix=core.windows.net";
        public string GetStorageConnectionString()
        {
           return connectionString;
        }
    }
}
