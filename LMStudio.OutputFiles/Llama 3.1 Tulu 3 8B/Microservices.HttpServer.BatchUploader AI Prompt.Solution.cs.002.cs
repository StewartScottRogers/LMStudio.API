using System.IO;
using System.Threading.Tasks;

public class FileUploader : IFileUploader
{
    public async Task<string> SaveToTemp(IFormFile file)
    {
        var filePath = Path.GetTempFileName();
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;
    }
}