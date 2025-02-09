using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataContracts.Interfaces
{
    public interface IFileUploader
    {
        Task<List<(string, bool)>> UploadFilesAsync(List<IFormFile> files);
    }
}