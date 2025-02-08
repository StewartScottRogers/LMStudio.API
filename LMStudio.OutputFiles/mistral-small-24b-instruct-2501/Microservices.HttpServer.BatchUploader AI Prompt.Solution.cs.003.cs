using Azure.Storage.Blobs;

public interface IBlobStorageService
{
    Task<(bool success, string fileName) UploadFileToBlobAsync(IFormFile file);
}