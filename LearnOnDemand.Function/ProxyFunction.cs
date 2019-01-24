using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using LearnOnDemand.API;
using Microsoft.AspNetCore.Hosting;

namespace LearnOnDemand.Function
{
    public static class ProxyFunction
    {
        private static readonly HttpClient _client;

        static ProxyFunction()
        {
            var functionPath = new FileInfo(typeof(ProxyFunction).Assembly.Location).Directory.Parent.FullName;
            Directory.SetCurrentDirectory(functionPath);
            var server = CreateServer(functionPath);
            _client = server.CreateClient();
        }

        private static TestServer CreateServer(string functionPath) =>
            new TestServer(WebHost
                .CreateDefaultBuilder()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config
                        .SetBasePath(functionPath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{builderContext.HostingEnvironment.EnvironmentName}.json",
                            optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .UseStartup<Startup>());

        [FunctionName("Proxy")]
        public static Task<HttpResponseMessage> Run([HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get", "post", "put", "delete", "patch", "options",
                Route = "{*x:regex(^(?!admin|debug|monitoring).*$)}")] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("***HTTP trigger - ASP.NET Core Proxy: function processed a request.");

            return _client.SendAsync(req);
        }
    }
}
