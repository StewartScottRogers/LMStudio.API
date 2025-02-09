using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BatchUploaderService.Services;

public class AzureBlobStorageService : IFileStorageService
{
    private readonly IConfiguration _configuration;
    
    public AzureBlobStorageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task StoreFileAsync(IFormFile file)
    {
        string connectionString = _configuration.GetValue<string>("AzureBlobStorage:ConnectionString");
        string containerName = _configuration.GetValue<string>("AzureBlobStorage:ContainerName");

        var blobClient = new BlobServiceClient(connectionString).GetBlobContainerClient(containerName);
        await blobClient.CreateIfNotExistsAsync();

        string fileNameWithTimestamp = $"{Path.GetFileNameWithoutExtension(file.FileName)}-{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}{Path.GetExtension(file.FileName)}";
        var blob = blobClient.GetBlobClient(fileNameWithTimestamp);

        using (var stream = file.OpenReadStream())
        {
            await blob.UploadAsync(stream);
        }
    }
}