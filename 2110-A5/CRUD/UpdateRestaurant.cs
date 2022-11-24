using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using _2110.Common;
using _2110.DataAccess;

namespace CRUD
{
    public static class UpdateRestaurant
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        [FunctionName("UpdateRestaurant")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = null)] HttpRequest req,
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
            string BusinessHours = req.Query["hours"];

            var rep = new RestaurantRepository(storageConfiguration, tableName);

            var getRest = rep.Get(id, name);

            if(getRest != null)
            {
                getRest.RestaurantName = RestaurantName;
                getRest.Address = Address;  
                getRest.WebURL = WebURL;
                getRest.Email = Email;
                getRest.Phone = Phone;
                getRest.Cuisine = Cuisine;
                getRest.BusinessHours = BusinessHours;
            };

            new RestaurantRepository(storageConfiguration,tableName).Update(getRest);


            /* string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
             dynamic data = JsonConvert.DeserializeObject(requestBody);
             name = name ?? data?.name;*/

            string responseMsg = "Updated Restaurant Successfully";
            log.LogInformation(responseMsg);

            return new OkObjectResult(responseMsg);
        }
    }
}
