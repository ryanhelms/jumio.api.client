using AutoFixture;
using Jumio.Api.Netverify;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Asserts.Compare;

namespace Jumio.Api.Tests.Netverify
{
    public class ClientTests : TestBase, IClassFixture<Fixtures>
    {
        private readonly Guid _scanReference;
        private readonly IFixture _fixture;

        public ClientTests(Fixtures fixtures)
        {
            _fixture = fixtures.Fixture;
            _scanReference = UploadDocument().Result;
        }

        [Fact(Skip = "Too slow")]
        public async Task SubmitFlow()
        {
            var scanReference = await UploadDocument();
            var scanStatus = new ScanStatus { Status = ScanStatusStatus.PENDING };
            var i = 0;

            while (scanStatus.Status == ScanStatusStatus.PENDING && i < 20)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                scanStatus = await NetverifyClient.GetScanStatusAsync(scanReference);
                i++;
            }

            Assert.Equal(ScanStatusStatus.DONE, scanStatus.Status);

            var scanData = await NetverifyClient.GetScanDataAsync(scanStatus.ScanReference);

            DeepAssert.Equal(Defaults.DriverGbr, scanData, "Timestamp", "ScanReference", "Date");
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task Submit()
        {
            var model = _fixture.Create<UploadScan>();
            var actual = await NetverifyClient.SubmitAsync(model);

            Assert.IsType<ScanReference>(actual);
        }

        // GetScanStatusAsync - статус (Done, Pending, Failed)
        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanStatus()
        {
            var expected = new ScanStatus();
            var actual = await NetverifyClient.GetScanStatusAsync(_scanReference);

            expected.Status = ScanStatusStatus.DONE;
            expected.ScanReference = _scanReference;
            DeepAssert.Equal(expected, actual, "Timestamp"); // Сравни все поля кроме Timestamp
            Assert.IsType<ScanStatus>(actual);
        }

        //GetScanDataAsync - подробные данные по документам, 404 если статус = Pending
        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanData()
        {
            var expected = new ScanDetails {ScanReference = _scanReference};
            var actual = await NetverifyClient.GetScanDataAsync(_scanReference);

            Assert.IsType<ScanDetails>(actual);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanDocumentDataOnly()
        {
            var expected = new ScanDocumentData
            {
                ScanReference = _scanReference,
                IssuingCountry = "UKR",
                Status = ScanDocumentDataOnlyStatus.ERROR_NOT_READABLE_ID,
                Type = ScanDocumentDataOnlyType.PASSPORT
            };
            var actual = await NetverifyClient.GetScanDocumentDataOnlyAsync(_scanReference);

            DeepAssert.Equal(expected, actual, "Timestamp");
            Assert.IsType<ScanDocumentData>(actual);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanTransactionDataOnly()
        {
            var actual = await NetverifyClient.GetScanTransactionDataOnlyAsync(_scanReference);

            Assert.IsType<ScanTransactionData>(actual);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanVerificationDataOnly()
        {
            var actual = await NetverifyClient.GetScanVerificationDataOnlyAsync(_scanReference);

            Assert.IsType<ScanVerificationData>(actual);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanImages()
        {
            var actual = await NetverifyClient.GetScanImagesAsync(_scanReference);

            Assert.IsType<Images>(actual);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetScanImage()
        {
            var actual = await NetverifyClient.GetScanImageAsync(_scanReference, Classifier.Front, Maskhint.Masked);

            Assert.Equal(actual, FixtureBase.GetBase64Image("passport.usa.jpg"));
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task Initiate()
        {
            var model = _fixture.Create<UserSettings>();
            var actual = await NetverifyClient.InitiateAsync(model);

            Assert.True(false);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetDocStatus() //404
        {
            var response = await NetverifyClient.GetDocStatusAsync(_scanReference);

            Assert.IsType<DocumentStatus>(response);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetDocumentData() //404
        {
            var response = await NetverifyClient.GetDocumentDataAsync(_scanReference);

            Assert.IsType<DocumentDetails>(response);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetDocumentsDocumentDataOnly() //404
        {
            var response = await NetverifyClient.GetDocumentsDocumentDataOnlyAsync(_scanReference);

            Assert.IsType<DocDocumentData>(response);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetDocumentsTransactionDataOnly() //404
        {
            var response = await NetverifyClient.GetDocumentsTransactionDataOnlyAsync(_scanReference);

            Assert.IsType<DocTransactionData>(response);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetDocImages()
        {
            var response = await NetverifyClient.GetDocImagesAsync(_scanReference);

            Assert.IsType<Images>(response);
        }

        [Fact(Skip = "Will be implemented later")]
        public async Task GetDocImage()
        {
            var response = await NetverifyClient.GetDocImageAsync(_scanReference, Classifier.Front, Maskhint.Unmasked);

            Assert.IsType<Images>(response);
        }

        private async Task<Guid> UploadDocument()
        {
            var model = _fixture.Create<UploadScan>();
            var actual = await NetverifyClient.SubmitAsync(model);

            return actual.JumioIdScanReference;
        }
    }
}