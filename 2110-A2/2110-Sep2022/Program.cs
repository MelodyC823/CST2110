using System;
using Microsoft.Data.SqlClient;
using _2110_Sep2022.TableStorage;
using Sept2022.SqlDataAccess;
using _2110_Sep2022.Common;
using _2110_Sep2022.Queue;
using System.Text.Json;
using System.Collections.Generic;
using _2110_Sep2022.BlobStorage;
using System.IO;

namespace _2110_Sep2022
{
    class Program
    {
        private static string tableName = "CustomerAccount";
        private static string queueName = "orderqueue";
        private static string containerName = "customerfiles";
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();

        static void Main(string[] args)
        {
            // new Program().TestDownloadBlob();
            // new Program().TestUploadBlob();


            // new Program().TestSerialization();
            //new Program().AddCustomerAccount();
            //new Program().GetCustomerAccount();
            //new Program().Query();

            //new Program().EnqueueMessage("892123", "I19101");
            //new Program().EnqueueMessage("890167", "I17701");
            //new Program().EnqueueMessage("890623", "I19101");
            //new Program().EnqueueMessage("890190", "I19121");
            //new Program().PeekMessage();
            //new Program().DequeueMessage();
        }

        public void TestSerialization()
        {
            var address1 = new Address()
            {
                NumberAndStreet = "1189 Howe ST",
                Unit = "1002",
                City = "Vancouver",
                PostalCode = "V6Z2X4",
                Province = "BC",
                Country = "Canada"
            };
            var address2 = new Address()
            {
                NumberAndStreet = "2159 Broughton ST",
                Unit = "1980",
                City = "Vancouver",
                PostalCode = "V6Z2W4",
                Province = "BC",
                Country = "Canada"
            };

            var serializedOrder = new Program().Serialize(new Order()
            {
                OrderID = "001",
                CustomerID = "C1200",
                OrderDateTime = DateTime.UtcNow,
                DeliveryAddresses = new List<Address>() { address1, address2 }
            });

            var order = new Program().Desrialize(serializedOrder);
        }

        public void TestUploadBlob()
        {
            string fileName = "azure-error-v6.txt";
            
            var customerBlobRepository = new CustomerBlobStorageRepository(this.storageConfiguration, containerName);
            customerBlobRepository.UploadFile(fileName);
        }

        public void TestDownloadBlob()
        {
            string fileName = "azure-error-v5.txt";
            string downloadFileName = $"download-{fileName}";

            var customerBlobRepository = new CustomerBlobStorageRepository(this.storageConfiguration, containerName);
            customerBlobRepository.Download(fileName, downloadFileName);
        }

        public void EnqueueMessage(string orderID, string customerID)
        {
            var order = new Order() { OrderID = orderID, CustomerID = customerID };
            var orderQueueRepository = new OrderQueueRepository(this.storageConfiguration, queueName);
            orderQueueRepository.Enqueue(order);
        }

        public void PeekMessage()
        {
            var orderQueueRepository = new OrderQueueRepository(this.storageConfiguration, queueName);
            orderQueueRepository.Peek();
        }

        public void DequeueMessage()
        {
            var orderQueueRepository = new OrderQueueRepository(this.storageConfiguration, queueName);
            orderQueueRepository.Dequeue();
        }

        public void Query()
        {
            var accounts = new CustomerAccountTableStorageRepository(this.storageConfiguration, tableName)
                .Query("C013");

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", account.PartitionKey, account.RowKey, account.InterestRate));
            }
        }

        public void AddCustomerAccount()
        {
            var customerAccount = new CustomerAccount()
            {
                PartitionKey = "C015",  // Customer ID - has to be Unique ID
                RowKey = "200002",      // Account ID - has to be Unique for each customer
                InterestRate = 2,
                IsAccountActive = true,
            };

            new CustomerAccountTableStorageRepository(this.storageConfiguration, tableName).Add(customerAccount);
        }

        public void GetCustomerAccount()
        {
            var customer = new CustomerAccountTableStorageRepository(this.storageConfiguration, tableName).Get("C013", "200002");
            Console.WriteLine($"{customer.PartitionKey}, {customer.RowKey}, {customer.InterestRate}");
        }

        public void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);
            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Employee(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL)";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Serialiation is taking an in-memory object (could be nested) and flattening it into a stream of bytes (XML, JSON, etc.).
        // Desrialization works the reverse of serialization to reconstruct the object in memory from the data stream.
        //  typically used for: 
        //  1 - transmit objects across the network or applications
        //  2 - store objects to a database or a file e.g. table storage

        public string Serialize(Order order)
        {
            return JsonSerializer.Serialize(order);
        }

        public Order Desrialize(string serializedOrder)
        {
            return JsonSerializer.Deserialize<Order>(serializedOrder);
        }
    }
}
