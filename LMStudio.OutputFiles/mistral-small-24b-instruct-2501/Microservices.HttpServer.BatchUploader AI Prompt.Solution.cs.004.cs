using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace BatchUploader.WebApi.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string containerName = "batch-uploads";

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<(bool Success, string FileName)> UploadFileToBlobAsync(IFormFile file)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync();
                var blobClient = containerClient.GetBlobClient($"{DateTime.UtcNow:yyyyMMddHHmmss}-{file.FileName}");
                using var fileStream = file.OpenReadStream();
                await blobClient.UploadAsync(fileStream, true);

                return (true, $"{containerName}/{blobClient.Name}");
            }
            catch (Exception)
            {
                return (false, string.Empty);
            }
        }
    }
}