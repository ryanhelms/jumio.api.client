using AutoFixture;
using System.Threading.Tasks;
using Xunit;

namespace Jumio.Api.Tests.Fastfill
{
    public class ClientTests : TestBase, IClassFixture<Fastfill.Fixtures>
    {
        private readonly IFixture _fixture;

        public ClientTests(Fixtures fixtures) : base()
        {
            _fixture = fixtures.Fixture;
        }

        [Fact(Skip = "You don't have permission to access /api/netverify/v2/fastfill")]
        public async Task Submit()
        {
            var model = _fixture.Create<Api.Fastfill.Body>();
            var response = await FastfillClient.SubmitAsync(model);

            Assert.True(true);
        }
    }
}