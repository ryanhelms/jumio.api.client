using AutoFixture;
using Jumio.Api.Netverify;
using System.Threading.Tasks;
using Xunit;

namespace Jumio.Api.Tests.Netverify
{
    public class NoOpClientTests : NoOpTestBase, IClassFixture<Fixtures>
    {
        private readonly IFixture _fixture;

        public NoOpClientTests(Fixtures fixtures)
        {
            _fixture = fixtures.Fixture;
        }

        [Fact]
        public async Task Submit()
        {
            var model = _fixture.Create<UploadScan>();
            var actual = await NetverifyClient.SubmitAsync(model);

            Assert.NotNull(actual);
        }
    }
}