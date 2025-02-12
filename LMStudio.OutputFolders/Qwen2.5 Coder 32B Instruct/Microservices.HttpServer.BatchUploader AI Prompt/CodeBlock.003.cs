using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly IFileStorageService _fileStorageService;

    public FileUploadController(IFileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var resultTuple = await _fileStorageService.UploadFileAsync(memoryStream, file.FileName);

        if (!resultTuple.Success)
            return StatusCode(500, $"An error occurred: {resultTuple.ErrorMessage}");

        return Ok(new UploadResponse(file.FileName, true, string.Empty));
    }
}