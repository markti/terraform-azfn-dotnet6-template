using System;
using GitHubCrawler.Services.Interfaces;

namespace GitHubCrawler.Services
{
    public class AltImplementation : IBulkRequestProcessor
    {
        public async Task<int> DoSomethingAsync()
        {
            return 10;
        }
    }
}