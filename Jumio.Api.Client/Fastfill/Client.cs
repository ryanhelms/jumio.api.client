using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace Jumio.Api.Fastfill
{
    public partial class Client
    {
        private static readonly Regex SubmitActionRegEx = new Regex(@"^api\/netverify\/v2\/fastfill", RegexOptions);

        partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings) =>
            UpdateSerializerSettings(settings);

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            SetupHttpClient(client);

            if (IsSubmitOperation(request))
            {
                ConvertSubmitRequestToMultipart(request);
            }
        }

        private bool IsSubmitOperation(HttpRequestMessage request) =>
            request.Method == HttpMethod.Post &&
            SubmitActionRegEx.IsMatch(request.RequestUri.ToString());

        private void ConvertSubmitRequestToMultipart(HttpRequestMessage request)
        {
            var contentJson = request.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var body = JsonConvert.DeserializeObject<Body>(contentJson, JsonSerializerSettings);

            var multipartContent = new MultipartFormDataContent();

            AddStringContent(multipartContent, body.Metadata, "metadata");
            AddImageContent(multipartContent, body.FrontsideImage, "frontsideImage");
            AddImageContent(multipartContent, body.BacksideImage, "backsideImage");

            request.Content = multipartContent;
        }

        private void AddStringContent(MultipartFormDataContent multipartContent, object content, string name)
        {
            var metadata = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            multipartContent.Add(metadata, name);
        }

        private void AddImageContent(MultipartFormDataContent multipartContent, byte[] bytes, string name)
        {
            if (bytes == null) return;

            var image = GetImageContent(bytes);

            multipartContent.Add(image, name);
        }

        private ByteArrayContent GetImageContent(byte[] bytes)
        {
            var backsideImage = new ByteArrayContent(bytes)
            {
                Headers = { ContentType = new MediaTypeHeaderValue(MediaTypeNames.Image.Jpeg) }
            };

            return backsideImage;
        }
    }
}
