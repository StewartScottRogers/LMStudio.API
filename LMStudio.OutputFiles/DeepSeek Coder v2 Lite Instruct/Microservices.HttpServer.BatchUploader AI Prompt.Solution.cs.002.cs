public interface IBlobStorageService
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName);
    }