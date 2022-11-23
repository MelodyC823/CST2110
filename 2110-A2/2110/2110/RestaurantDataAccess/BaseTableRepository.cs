using System;
using System.Collections.Generic;
using System.Text;
using _2110.Common;
using Azure.Data.Tables;

namespace _2110.RestaurantDataAccess
{
    public class BaseTableRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string tableName;

        public BaseTableRepository(IStorageConfiguration storageConfiguration, string tableName)
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
