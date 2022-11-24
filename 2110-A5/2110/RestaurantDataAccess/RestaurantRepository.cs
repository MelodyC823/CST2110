using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Azure;
using Azure.Data.Tables;
using _2110.RestaurantDataAccess;
using _2110.Common;

namespace _2110.DataAccess
{
    public class RestaurantRepository:BaseTableRepository
    {
        public RestaurantRepository(IStorageConfiguration storageConfiguration, string tableName)
            : base(storageConfiguration, tableName){}

        //Add Method
        public void Add(Restaurant restaurant)
        {
            var tableClient = GetTableClient();

            var res = tableClient.AddEntity<Restaurant>(restaurant);
        }


        //Get Method
        public Restaurant Get(string restaurantID, string restaurantName)
        {
            var tableClient = GetTableClient();

            var restaurant = tableClient.GetEntity<Restaurant>(
                partitionKey: restaurantID,
                rowKey: restaurantName
                );

            return restaurant;
        }

        //Delete Method
        public void Delete(string restaurantID, string restaurantName)
        {
            var tableClient = GetTableClient();

            tableClient.DeleteEntity(restaurantID, restaurantName);
        }

        //Update Method
        public void Update(Restaurant restaurant)
        {
            var tableClient = GetTableClient();

            tableClient.UpdateEntity<Restaurant>(restaurant, ETag.All, TableUpdateMode.Merge);
        }

        // Search by city
        public IEnumerable<Restaurant> Query(string city)
        {
            var tableClient = GetTableClient();
            var restaurants = tableClient.Query<Restaurant>(x => x.City == city);

            return restaurants;
        }


        // Search by city and name
        public IEnumerable<Restaurant> Query(string city, string name)
        {
            var tableClient = GetTableClient();
            var restaurants = tableClient.Query<Restaurant>(x => x.City == city && x.RowKey == name);

            return restaurants;
        }

        //search by city, name and cuisine
        public IEnumerable<Restaurant> Query(string city, string name, string cuisine)
        {
            var tableClient = GetTableClient();
            var restaurants = tableClient.Query<Restaurant>(x => x.City == city && x.RowKey == name && x.Cuisine == cuisine);

            return restaurants;
        }


    }
}

