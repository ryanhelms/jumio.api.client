using System.Net.Http;

namespace Jumio.Api.Netverify
{
    public partial class Client
    {
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings) =>
            UpdateSerializerSettings(settings);

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) =>
            SetupHttpClient(client);
    }
}
