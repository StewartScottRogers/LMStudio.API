using Microsoft.AspNetCore.Mvc;

public class DefaultController : ControllerBase
{
    public async Task<IActionResult> Index()
    {
        return View("UploadForm");
    }

    [HttpPost("Upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (!file.RequestFormFile.ContentType.IsSupported())
            return BadRequest("Unsupported file type");

        try
        {
            var fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{file.FileName}";
            
            using (var stream = file.OpenReadStream())
                await UploadHelper.UploadAsync(stream, fileName);

            return Ok(new { fileName });
        }
        catch (Exception ex)
        {
            if (ex is ServiceException se)
                return Problem(se.Message);
            
            return Problem(ex, "Failed to process file upload");
        }
    }

    private async Task<UploadResultTuple> UploadHelper.UploadAsync(
        Stream stream, string fileName)
    {
        var blobService = new BlobService();
        return await blobService.UploadFileAsync(stream, fileName);
    }
}