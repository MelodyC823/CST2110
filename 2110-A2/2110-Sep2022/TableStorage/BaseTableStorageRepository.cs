using _2110_Sep2022.Common;
using Azure.Data.Tables;

namespace _2110_Sep2022.TableStorage
{
    public class BaseTableStorageRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string tableName;

        public BaseTableStorageRepository(IStorageConfiguration storageConfiguration, string tableName)
        {
            this.tableName = tableName;
            this.storageConfiguration = storageConfiguration;
        }

        protected TableClient GetTableClient()
        {
            var tableServiceClient = new TableServiceClient(this.storageConfiguration.GetStorageConnectionString());
            var tableClient = tableServiceClient.GetTableClient(tableName: this.tableName);
            tableClient.CreateIfNotExists();

            return tableClient;
        }
    }
}
