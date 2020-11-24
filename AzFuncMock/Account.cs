using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BcPointUnitTestProject
{
    public class CreatedObjectResult : ActionResult
    {
    }

    public static class Account
    {
        [FunctionName("PostAccount")]
        public static async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "account/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (id.ToUpper() == "InternalServerError".ToUpper())
            {
                return new ObjectResult(id) { StatusCode=500 };
            }
            if (id.ToUpper() == "Conflict".ToUpper())
            {
                return new ConflictObjectResult(id);
            }
            if (id.ToUpper() == "BadParam".ToUpper())
            {
                return new BadRequestObjectResult(id);
            }

            return new ObjectResult(id) { StatusCode = 201 };
        }


        [FunctionName("DeleteAccount")]
        public static async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "account/{id}")] HttpRequest req,
            ILogger log, string id)
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

            return new ObjectResult(id) { StatusCode = 204 };
        }

    }
}
