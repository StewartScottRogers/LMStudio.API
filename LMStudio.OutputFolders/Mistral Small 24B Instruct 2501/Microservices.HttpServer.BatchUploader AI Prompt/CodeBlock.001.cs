using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BatchUploader;

public static class FileUploader
{
    private readonly BlobServiceClient blobServiceClient = new BlobServiceClient("your_connection_string");

    public static async Task<string> UploadFile(HttpContext context)
    {
        var formCollection = await context.Request.ReadFormAsync();

        if (!formCollection.Files.Any())
            return "No file uploaded";

        var file = formCollection.Files.First();
        var blobContainerClient = FileUploader.blobServiceClient.GetBlobContainerClient("your-container-name");

        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            var uniqueFileName = $"{DateTime.UtcNow:yyyyMMddHHmmss}{Path.GetExtension(file.FileName)}";
            BlobClient blobClient = blobContainerClient.GetBlobClient(uniqueFileName);

            await using (var memoryStream = new MemoryStream())
            {
                stream.Position = 0;
                await stream.CopyToAsync(memoryStream);
                await blobClient.UploadAsync(memoryStream, overwrite: true);
            }
        }

        return $"File uploaded successfully with unique name {uniqueFileName}";
    }
}