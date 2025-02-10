using System.Threading.Tasks;
using BatchUploaderApi.Models;

namespace BatchUploaderApi.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<(bool IsSuccess, string FileUrl)> UploadFileToBlobAsync(FileUploadRequest request);
    }
}