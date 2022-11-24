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
    public static class DeleteRestaurant
    {
        private static IStorageConfiguration storageConfiguration = new StorageConfiguration();
        private static string tableName = "Restaurant";

        [FunctionName("DeleteRestaurant")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"];
            string name = req.Query["name"];

            new RestaurantRepository(storageConfiguration, tableName).Delete(id, name);

            /*string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;*/

            string responseMsg = "Deleted Restaurant Successfully";
            log.LogInformation(responseMsg);

            return new OkObjectResult(responseMsg);
        }
    }
}
