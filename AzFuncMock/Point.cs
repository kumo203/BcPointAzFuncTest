using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFuncMock
{
    public static class Point
    {
        [FunctionName("PutPoint")]
        public static async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "/account/{id}/point/{operation}")] HttpRequest req,
            ILogger log, string id, string operation)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (id.ToUpper() == "InternalServerError".ToUpper())
            {
                return new ObjectResult(id) { StatusCode = 500 };
            }
            if (id.ToUpper() == "NotFound".ToUpper())
            {
                return new NotFoundObjectResult(id);
            }
            if (id.ToUpper() == "BadParam".ToUpper())
            {
                return new BadRequestObjectResult(id);
            }

            return new ObjectResult(id) { StatusCode = 202 };
        }
    }
}
