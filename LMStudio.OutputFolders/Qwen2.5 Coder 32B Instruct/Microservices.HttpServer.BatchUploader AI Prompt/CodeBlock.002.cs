using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.IO;

public class FileStorageService : IFileStorageService
{
    private readonly string _connectionString;
    private readonly string _containerName = "uploads";

    public FileStorageService(IConfiguration configuration)
    {
        _connectionString = configuration["AzureBlobStorageConnectionString"];
    }

    public async Task<(bool Success, string ErrorMessage)> UploadFileAsync(Stream fileStream, string fileName)
    {
        try
        {
            var blobClient = new BlobContainerClient(_connectionString, _containerName);

            // Create the container if it does not exist.
            await blobClient.CreateIfNotExistsAsync();

            // Get a reference to a blob named "sample-file".
            var uniqueFileName = $"{DateTime.UtcNow:yyyy-MM-dd_HH-mm-ss}_{fileName}";
            var blockBlobClient = blobClient.GetBlobClient(uniqueFileName);

            // Upload the file.
            await blockBlobClient.UploadAsync(fileStream, overwrite: true);

            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}