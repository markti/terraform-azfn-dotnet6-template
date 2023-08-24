using System;
namespace GitHubCrawler.Services.Interfaces
{
	public interface IBulkRequestProcessor
    {
		Task<int> DoSomethingAsync();
	}
}