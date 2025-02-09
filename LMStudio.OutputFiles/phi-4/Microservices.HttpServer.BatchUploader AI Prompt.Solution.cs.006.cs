using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BatchUploaderService.Controllers;

[ApiController]
[Route("[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly IFileStorageService _fileStorageService;

    public FileUploadController(IFileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] BlobUploadModel model)
    {
        if (model.File == null || model.File.Length == 0)
        {
            return BadRequest("No file provided.");
        }
        
        await _fileStorageService.StoreFileAsync(model.File);
        return Ok("File uploaded successfully.");
    }
}