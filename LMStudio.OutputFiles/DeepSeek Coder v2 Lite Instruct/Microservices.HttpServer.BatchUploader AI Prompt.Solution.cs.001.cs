public class UploadService
    {
        private readonly IDataAccess _dataAccess;

        public UploadService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> HandleUploadAsync(HttpRequest request, string containerName)
        {
            // Logic to process the upload
        }
    }