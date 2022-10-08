using _2110_Sep2022.Common;

namespace _2110_Sep2022.Common
{
    public class StorageConfiguration : IStorageConfiguration
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storagegblset2022;AccountKey={your-account-key};EndpointSuffix=core.windows.net";
        
        public string GetStorageConnectionString()
        {
            return connectionString;
        }
    }
}
