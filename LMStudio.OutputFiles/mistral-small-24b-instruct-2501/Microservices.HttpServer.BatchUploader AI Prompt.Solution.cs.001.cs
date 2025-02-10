using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace BatchUploaderApi.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly string connectionString;
        private readonly BlobContainerClient containerClient;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("AzureWebJobsStorage");
            this.containerClient = new BlobContainerClient(connectionString, "uploadedfiles");
        }

        /// <summary>
        /// Uploads a file to Azure Blob Storage with a unique datetime stamp.
        /// </summary>
        /// <param name="request">The file upload request.</param>
        /// <returns>A task that represents the asynchronous operation. Returns a tuple indicating success and the file URL.</returns>
        public async Task<(bool IsSuccess, string FileUrl)> UploadFileToBlobAsync(FileUploadRequest request)
        {
            try
            {
                var fileName = $"{DateTime.UtcNow:yyyyMMddHHmmss}{Path.GetExtension(request.File.FileName)}";
                var blobClient = containerClient.GetBlobClient(fileName);

                using (var stream = new MemoryStream())
                {
                    await request.File.CopyToAsync(stream);
                    stream.Position = 0;
                    await blobClient.UploadAsync(stream, true);
                }

                return (true, blobClient.Uri.ToString());
            }
            catch
            {
                return (false, null);
            }
        }
    }
}