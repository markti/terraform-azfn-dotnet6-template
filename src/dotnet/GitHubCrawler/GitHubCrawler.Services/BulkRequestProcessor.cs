using GitHubCrawler.Services.Interfaces;

namespace GitHubCrawler.Services;
public class BulkRequestProcessor : IBulkRequestProcessor
{
    public async Task<int> DoSomethingAsync()
    {
        return 5;
    }
}