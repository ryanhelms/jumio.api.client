using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace Jumio.Api.Tests
{
    public abstract class TestBase
    {
        internal readonly Jumio.Api.Netverify.IClient NetverifyClient;
        internal readonly Jumio.Api.Fastfill.IClient FastfillClient;

        protected TestBase()
        {
            var settings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var configuration = settings
                .GetSection("jumio")
                .Get<Configuration>();
            var httpClient = new HttpClient();

            NetverifyClient = new Jumio.Api.Netverify.Client(configuration, httpClient);
            FastfillClient = new Jumio.Api.Fastfill.Client(configuration, httpClient);
        }
    }
}