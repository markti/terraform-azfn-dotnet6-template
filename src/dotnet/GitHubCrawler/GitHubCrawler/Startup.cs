using System;
using GitHubCrawler.Services;
using GitHubCrawler.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GitHubCrawler.Startup))]

namespace GitHubCrawler
{
	public class Startup : FunctionsStartup
    {
		public Startup()
		{
		}

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IBulkRequestProcessor, BulkRequestProcessor>();
        }
    }
}