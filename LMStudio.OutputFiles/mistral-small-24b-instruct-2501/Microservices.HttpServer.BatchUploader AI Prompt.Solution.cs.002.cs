using Microsoft.AspNetCore.Http;

namespace BatchUploaderApi.Models
{
    public class FileUploadRequest
    {
        public IFormFile File { get; set; }
    }
}