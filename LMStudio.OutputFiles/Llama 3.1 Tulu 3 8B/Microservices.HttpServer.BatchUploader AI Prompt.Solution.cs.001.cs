using Azure.Storage.Blobs;
using HttpServer.Models;
using Microsoft.Extensions.Configuration;

namespace HttpServer.DataAccess;

public class BlobStorageService : IBlobStorageService
{
    private readonly IConfiguration _configuration;
    private readonly BlobContainerClient _blobContainer;

    public BlobStorageService(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = _configuration.GetConnectionString("AzureBlobStorage");
        _blobContainer = new BlobContainerClient(connectionString, "uploads"); // replace "uploads" with your container name
    }

    public async Task SaveAsync(Stream fileStream, string contentType, string fileName)
    {
        await _blobContainer.UploadBlobAsync(fileName, fileStream, new BlobHttpHeaders { ContentType = contentType });
    }
}