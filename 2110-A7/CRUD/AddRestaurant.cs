using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using _2110.Common;
using _2110.RestaurantDataAccess;

using Newtonsoft.Json;

namespace CRUD
{
    public static class AddRestaurant
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        [FunctionName("AddRestuarant")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"];
            string name = req.Query["name"];
            string RestaurantName = req.Query["name"];
            string Address = req.Query["address"];
            string WebURL = req.Query["weburl"];
            string Email = req.Query["email"];
            string Phone = req.Query["phone"];
            string Cuisine = req.Query["cuisine"];
           /* bool IsVegan = req.Query["isvegan"];
            bool IsVegetarian = req.Query["isvegetarian"];
            bool IsAlcohol = req.Query["isalcohol"];*/
/*            double Price = req.Query["price"];
*/            string BusinessHours = req.Query["hours"];

            var rest1 = new Restaurant()
            {
                PartitionKey = id,
                RowKey = name,
                RestaurantName = RestaurantName,
                Address = Address,
                WebURL = WebURL,
                Email = Email,
                Phone = Phone,
                Cuisine = Cuisine,
                BusinessHours = BusinessHours,
            };

            new _2110.DataAccess.RestaurantRepository(storageConfiguration, tableName).Add(rest1);

            var isValid = !(string.IsNullOrEmpty(id) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(RestaurantName) 
                && string.IsNullOrEmpty(Address) && string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Cuisine));

            if (isValid)
            {
                var response = $"HTTP function received req with Restaurant Name {RestaurantName} Address {Address} Phone {Phone} Cuisine {Cuisine}";
                log.LogInformation(response);

                return new OkObjectResult(response);
            }

            var errorMsg = "Invalid input";
            log.LogInformation(errorMsg);

            return new BadRequestObjectResult(errorMsg);

          
        }
    }
}
