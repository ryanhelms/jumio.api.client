using System.Threading;
using System.Threading.Tasks;

namespace Jumio.Api.Fastfill
{
    public class NoOpClient : IClient
    {
        public async Task<DocumentData> SubmitAsync(Body body) =>
            await SubmitAsync(body, CancellationToken.None);

        public async Task<DocumentData> SubmitAsync(Body body, CancellationToken cancellationToken) =>
            await Task.FromResult(new DocumentData());
    }
}