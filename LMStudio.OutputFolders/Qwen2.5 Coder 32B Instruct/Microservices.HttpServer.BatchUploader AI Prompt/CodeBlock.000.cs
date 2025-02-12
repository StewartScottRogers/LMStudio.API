public interface IFileStorageService
{
    Task<(bool Success, string ErrorMessage)> UploadFileAsync(Stream fileStream, string fileName);
}