using AspNet.WebApi.Common.Extensions;

namespace Jumio.Api.Tests.Netverify
{
    public class Fixtures : FixtureBase
    {
        public Fixtures()
        {
            Fixture.Customize<Api.Netverify.UploadScan>(m => m
                .OmitAutoProperties()
                .With(_ => _.Country, "GBR")
                .With(_ => _.IdType, Api.Netverify.UploadScanIdType.DRIVING_LICENSE)
                .With(_ => _.MerchantIdScanReference, MerchantIdScanReference.ToString())
                .With(_ => _.FrontsideImage, GetBase64Image("driver.gbr.jpg"))
            );

            Fixture.Customize<Api.Netverify.Preset>(m => m
                .With(_ => _.Country, Countries.RandomElement())
            );
        }
    }
}