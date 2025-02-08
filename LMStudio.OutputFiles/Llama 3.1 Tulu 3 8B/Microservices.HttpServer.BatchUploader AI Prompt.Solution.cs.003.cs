using Microsoft.Azure.Storage; // Include Azure.Storage.Blobs NuGet package
using Microsoft.Azure.Storage.Blob;

public class BlobStorageService : IBlobStorageService
{
    private readonly CloudBlobClient _blobClient;

    public BlobStorageService(string connectionString)
    {
        _blobClient = new CloudBlobClient(connectionString);
    }

    public async Task UploadBlob(string id, string filePath)
    {
        var container = _blobClient.GetContainerReference("uploads"); // Replace with your actual container name
        await container.CreateIfNotExistsAsync();
        
        using (var fileStream = File.OpenRead(filePath))
        {
            var blob = container.GetBlockBlobClient(id); 
            await blob.UploadFromStreamAsync(fileStream);
        }
    }
}