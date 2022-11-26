using Azure;
using Azure.Data.Tables;
using _2110.DataAccess;
using System;
using Microsoft.Data.SqlClient;
using _2110.RestaurantDataAccess;
using _2110.Common;

namespace _2110
{
    class Program
    {
        private IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        static void Main(string[] args)
        {

            //new Program().AddRestaurant();

            //new Program().GetRestaurant();

            //new Program().UpdateRestaurant();

            //new Program().DeleteRestaurant();

            //new Program().QueryCity();

            //new Program().QueryCityName();

            //new Program().QueryCityNameCuisine();

        }

        public void QueryCity()
        {
            var accounts = new RestaurantRepository(this.storageConfiguration,tableName).Query("Vancouver");

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", account.PartitionKey, account.RowKey,account.Cuisine));
            }
        }

        public void QueryCityName()
        {
            var accounts = new RestaurantRepository(this.storageConfiguration, tableName).Query("Vancouver","THE KEG");

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", account.BusinessHours, account.RowKey, account.Cuisine));
            }
        }

        public void QueryCityNameCuisine()
        {
            var accounts = new RestaurantRepository(this.storageConfiguration, tableName).Query("Vancouver", "THE KEG", "Fine dining");

            foreach (var account in accounts)
            {
                Console.WriteLine(string.Format("{0}-{1}-{2}", account.BusinessHours, account.RowKey, account.Phone));
            }
        }

        public void AddRestaurant()
        {
            var rest = new Restaurant()
            {
                //partitionKey is unique (customer id) Rowkey is account id
                PartitionKey = "V002",
                RowKey = "THE KEG",
                RestaurantName = "THE KEG",
                Address = "123 Graville St",
                City = "Vancouver",
                PostalCode = "V6P 3F2",
                Email = "thekeg@gmail.com",
                Phone = "126-155-0000",
                Cuisine = "Fine dining",
                WebURL = "www.thekeg.com",
                Rating = 5,
                IsVegan = true,
                IsVegetarian = true,
                IsAlcohol = true,
                Price = 4,
                BusinessHours = "11:00 - 22:00",
                
            };

           new RestaurantRepository(this.storageConfiguration, tableName).Add(rest);
        }

        public void GetRestaurant()
        {
            var rest = new RestaurantRepository(this.storageConfiguration, tableName).Get("V001", "Dominos");
            Console.WriteLine($"{rest.PartitionKey}, {rest.RowKey},{rest.RestaurantName}");
        }

        public void DeleteRestaurant()
        {
            new RestaurantRepository(this.storageConfiguration, tableName).Delete("V001", "Dominos");
        }

        public void UpdateRestaurant()
        {
            var repo = new RestaurantRepository(this.storageConfiguration, tableName);
            var restaurant = repo.Get("V002", "THE KEG");
            restaurant.PostalCode = "V5H2A9";
            repo.Update(restaurant);
        }


        public static void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);

            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Restaurant(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL)";


            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close(); 
        }
    }
}
