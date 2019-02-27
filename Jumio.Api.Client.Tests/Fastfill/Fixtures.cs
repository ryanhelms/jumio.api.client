using AspNet.WebApi.Common.Extensions;
using Jumio.Api.Fastfill;

namespace Jumio.Api.Tests.Fastfill
{
    public class Fixtures : FixtureBase
    {
        public Fixtures()
        {
            Fixture.Customize<Metadata>(m => m
                .With(_ => _.Type, DocumentType.PASSPORT)
                .With(_ => _.Country, Countries.RandomElement()));

            Fixture.Customize<Body>(m => m
                .With(_ => _.FrontsideImage, GetImage("passport.bel.jpg"))
                .Without(_ => _.BacksideImage));
        }
    }
}
