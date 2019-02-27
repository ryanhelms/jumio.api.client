using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Jumio.Api
{
    public abstract class ClientBase : AspNet.WebApi.ClientBase
    {
        internal static readonly RegexOptions RegexOptions = RegexOptions.Compiled & RegexOptions.IgnoreCase & RegexOptions.CultureInvariant;

        internal new readonly Configuration Configuration;

        internal ClientBase(Configuration configuration) : base(configuration)
        {
            Configuration = configuration;
        }

        internal void UpdateSerializerSettings(JsonSerializerSettings settings)
        {
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            settings.Converters.Add(new StringEnumConverter(new DefaultNamingStrategy()));
        }

        internal void SetupHttpClient(HttpClient client)
        {
            var headers = client.DefaultRequestHeaders;

            if (client.BaseAddress == null)
            {
                client.BaseAddress = Configuration.Endpoint;
            }

            if (!headers.UserAgent.Any())
            {
                headers.UserAgent.Add(new ProductInfoHeaderValue(Configuration.UserAgent.ProductName, Configuration.UserAgent.ProductVersion));
            }

            if (headers.Authorization == null)
            {
                headers.Authorization = new AuthenticationHeaderValue("Basic", Configuration.GetAdministrationCredentials());
            }
        }
    }
}
