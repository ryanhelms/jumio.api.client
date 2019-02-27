using System;
using Jumio.Api.Netverify;

namespace Jumio.Api.Tests.Netverify
{
    public static class Defaults
    {
        public static readonly ScanDetails DriverGbr = new ScanDetails
        {
            Document = new ScanDocumentDataOnly
            {
                Type = ScanDocumentDataOnlyType.DRIVING_LICENSE,
                Address = string.Empty,
                Dob = new DateTime(1970, 9, 20),
                Expiry = new DateTime(2027, 03, 31),
                FirstName = "AHMED",
                LastName = "ELMARAKBI",
                IssuingCountry = "GBR",
                Number = "ELMAR709200A99LR07",
                Status = ScanDocumentDataOnlyStatus.APPROVED_VERIFIED
            },
                Transaction = new ScanTransactionDataOnly
            {
                MerchantScanReference = FixtureBase.MerchantIdScanReference.ToString(),
                Source = "API",
                Status = ScanTransactionDataOnlyStatus.DONE
            },
                Verification = new ScanVerificationDataOnly
            {
                MrzCheck = "NOT_AVAILABLE"
            }
        };
    }
}