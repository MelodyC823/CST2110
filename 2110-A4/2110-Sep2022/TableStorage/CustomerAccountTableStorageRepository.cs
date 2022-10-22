using _2110_Sep2022.Common;
using System.Collections.Generic;

namespace _2110_Sep2022.TableStorage
{
    public class CustomerAccountTableStorageRepository : BaseTableStorageRepository
    {
        public CustomerAccountTableStorageRepository(IStorageConfiguration storageConfiguration, string tableName)
            : base(storageConfiguration, tableName)
        {
        }

        public void Add(CustomerAccount customerAccount)
        {
            var tableClient = GetTableClient();

            var res = tableClient.AddEntity<CustomerAccount>(customerAccount);
        }

        public CustomerAccount Get(string customerID, string accountID)
        {
            var tableClient = GetTableClient();

            var customerAccount = tableClient.GetEntity<CustomerAccount>(
                partitionKey: customerID,
                rowKey: accountID
                );

            return customerAccount;
        }

        public IEnumerable<CustomerAccount> Query(string customerID)
        {
            var tableClient = GetTableClient();
            var customerAccounts = tableClient.Query<CustomerAccount>(x => x.PartitionKey == customerID);

            return customerAccounts;
        }
    }
}
