using AutoFixture;
using Jumio.Api.Fastfill;
using System.Threading.Tasks;
using Xunit;

namespace Jumio.Api.Tests.Fastfill
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
            var model = _fixture.Create<Body>();
            var actual = await FastfillClient.SubmitAsync(model);

            Assert.NotNull(actual);
        }
    }
}