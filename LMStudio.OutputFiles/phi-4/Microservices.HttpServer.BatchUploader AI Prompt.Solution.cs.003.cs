using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BatchUploaderService.Services;

public interface IFileStorageService
{
    Task StoreFileAsync(IFormFile file);
}