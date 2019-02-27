using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jumio.Api.Netverify
{
    public class NoOpClient : IClient
    {
        public async Task DeleteScan2Async(Guid scanReference) =>
            await DeleteScan2Async(scanReference, CancellationToken.None);

        public async Task DeleteScan2Async(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.CompletedTask;

        public async Task DeleteScanAsync(Guid scanReference) =>
            await DeleteScanAsync(scanReference, CancellationToken.None);

        public async Task DeleteScanAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.CompletedTask;

        public async Task<string> GetDocImageAsync(Guid scanReference, Classifier classifier, Maskhint? maskhint) =>
            await GetDocImageAsync(scanReference, classifier, maskhint, CancellationToken.None);

        public async Task<string> GetDocImageAsync(Guid scanReference, Classifier classifier, Maskhint? maskhint, CancellationToken cancellationToken) =>
            await Task.FromResult(Guid.NewGuid().ToString());

        public async Task<Images> GetDocImagesAsync(Guid scanReference) =>
            await GetDocImagesAsync(scanReference, CancellationToken.None);

        public async Task<Images> GetDocImagesAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(Images));

        public async Task<DocumentStatus> GetDocStatusAsync(Guid scanReference) =>
            await GetDocStatusAsync(scanReference, CancellationToken.None);

        public async Task<DocumentStatus> GetDocStatusAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(DocumentStatus));

        public async Task<DocumentDetails> GetDocumentDataAsync(Guid scanReference) =>
            await GetDocumentDataAsync(scanReference, CancellationToken.None);

        public async Task<DocumentDetails> GetDocumentDataAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(DocumentDetails));

        public async Task<DocDocumentData> GetDocumentsDocumentDataOnlyAsync(Guid scanReference) =>
            await GetDocumentsDocumentDataOnlyAsync(scanReference, CancellationToken.None);

        public async Task<DocDocumentData> GetDocumentsDocumentDataOnlyAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(DocDocumentData));

        public async Task<DocTransactionData> GetDocumentsTransactionDataOnlyAsync(Guid scanReference) =>
            await GetDocumentsTransactionDataOnlyAsync(scanReference, CancellationToken.None);

        public async Task<DocTransactionData> GetDocumentsTransactionDataOnlyAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(DocTransactionData));

        public async Task<ScanDetails> GetScanDataAsync(Guid scanReference) =>
            await GetScanDataAsync(scanReference, CancellationToken.None);

        public async Task<ScanDetails> GetScanDataAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(ScanDetails));

        public async Task<ScanDocumentData> GetScanDocumentDataOnlyAsync(Guid scanReference) =>
            await GetScanDocumentDataOnlyAsync(scanReference, CancellationToken.None);

        public async Task<ScanDocumentData> GetScanDocumentDataOnlyAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(ScanDocumentData));

        public async Task<string> GetScanImageAsync(Guid scanReference, Classifier classifier, Maskhint? maskhint) =>
            await GetScanImageAsync(scanReference, classifier, maskhint, CancellationToken.None);

        public async Task<string> GetScanImageAsync(Guid scanReference, Classifier classifier, Maskhint? maskhint, CancellationToken cancellationToken) =>
            await Task.FromResult(default(string));

        public async Task<Images> GetScanImagesAsync(Guid scanReference) =>
            await GetScanImagesAsync(scanReference, CancellationToken.None);

        public async Task<Images> GetScanImagesAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(Images));

        public async Task<ScanStatus> GetScanStatusAsync(Guid scanReference) =>
            await GetScanStatusAsync(scanReference, CancellationToken.None);

        public async Task<ScanStatus> GetScanStatusAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(ScanStatus));

        public async Task<ScanTransactionData> GetScanTransactionDataOnlyAsync(Guid scanReference) =>
            await GetScanTransactionDataOnlyAsync(scanReference, CancellationToken.None);

        public async Task<ScanTransactionData> GetScanTransactionDataOnlyAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(ScanTransactionData));

        public async Task<ScanVerificationData> GetScanVerificationDataOnlyAsync(Guid scanReference) =>
            await GetScanVerificationDataOnlyAsync(scanReference, CancellationToken.None);

        public async Task<ScanVerificationData> GetScanVerificationDataOnlyAsync(Guid scanReference, CancellationToken cancellationToken) =>
            await Task.FromResult(default(ScanVerificationData));

        public async Task<ConnectionSettings> InitiateAsync(UserSettings body) =>
            await InitiateAsync(body, CancellationToken.None);

        public async Task<ConnectionSettings> InitiateAsync(UserSettings body, CancellationToken cancellationToken) =>
            await Task.FromResult(default(ConnectionSettings));

        public async Task<ScanReference> SubmitAsync(UploadScan body) =>
            await SubmitAsync(body, CancellationToken.None);

        public async Task<ScanReference> SubmitAsync(UploadScan body, CancellationToken cancellationToken) =>
            await Task.FromResult(new ScanReference
            {
                JumioIdScanReference = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow
            });
    }
}