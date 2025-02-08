using Microsoft.AspNetCore.Mvc;
using BatchUploader.WebApi.Services;

namespace BatchUploader.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchUploadController : ControllerBase
    {
        private readonly IBlobStorageService _blobStorageService;

        public BatchUploadController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> UploadFileAsync([FromForm] IFormFile file)
        {
            if (file == null || file.Length <= 0)
                return BadRequest();

            var uploadResultTuple = await _blobStorageService.UploadFileToBlobAsync(file);

            if (!uploadResultTuple.Item1)
                return StatusCode(500, "Internal server error");

            return Ok(new { FilePath = uploadResultTuple.FileName });
        }
    }
}