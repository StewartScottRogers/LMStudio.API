using HttpServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpServer.API.Controllers;

[Route("api/[controller]")]
public class BatchUploaderController : ControllerBase
{
    private readonly IBlobStorageService _blobStorageService;

    public BatchUploaderController(IBlobStorageService blobStorageService)
    {
        _blobStorageService = blobStorageService ?? throw new ArgumentNullException(nameof(blobStorageService));
    }

    [HttpPost]
    public async Task<IActionResult> UploadAsync(IFormFile file)
    {
        // Check if the file is not null and has a content type
        if (file == null || string.IsNullOrEmpty(file.ContentType))
            return BadRequest("Invalid file");

        var request = new UploadRequest { FileName = file.FileName, ContentType = file.ContentType };
        
        try
        {
            // Save to Azure Blob with unique timestamped name
            var fileNameWithTimestamp = $"{DateTimeOffset.UtcNow.ToUnixTimeStamp()}-{file.FileName}";
            await _blobStorageService.SaveAsync(file.OpenReadStream(), file.ContentType, fileNameWithTimestamp);

            return CreatedAtAction(nameof(GetUploadStatus), new { id = fileNameWithTimestamp }, new UploadResponse
            {
                Status = "Uploaded",
                FileName = fileNameWithTimestamp,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetUploadStatus(string id)
    {
        // Retrieve status from the service, mock or actual implementation
        var response = new UploadResponse { Status = "Uploaded Successfully" }; // Placeholder, implement real check

        return Ok(response);
    }
}