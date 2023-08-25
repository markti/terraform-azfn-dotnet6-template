using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GitHubCrawler.Services.Interfaces;

namespace GitHubCrawler
{
    public class GitHubCrawler
    {
        private readonly IBulkRequestProcessor _bulkRequestProcessor;
        private readonly ILogger<GitHubCrawler> _logger;

        public GitHubCrawler(ILogger<GitHubCrawler> logger, IBulkRequestProcessor bulkRequestProcessor)
        {
            _logger = logger;
            _bulkRequestProcessor = bulkRequestProcessor;
        }

        [FunctionName("GitHubCrawler")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "foo")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var myNumber = await _bulkRequestProcessor.DoSomethingAsync();

            _logger.LogInformation($"Here's my number: {myNumber}");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully. My number was {myNumber}";

            return new OkObjectResult(responseMessage);
        }
    }
}