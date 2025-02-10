using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BatchUploaderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IAzureBlobStorageService azureBlobStorageService;

        public UploadController(IAzureBlobStorageService azureBlobStorageService)
        {
            this.azureBlobStorageService = azureBlobStorageService;
        }

        /// <summary>
        /// Endpoint to handle file uploads.
        /// </summary>
        /// <param name="request">The file upload request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync([FromForm] FileUploadRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadSuccess = await azureBlobStorageService.UploadFileToBlobAsync(request);

            if (!uploadSuccess.Item1)
                return StatusCode(500, "Failed to upload the file."); // Status code for internal server error

            return Ok(new { FileUrl = uploadSuccess.Item2 });
        }
    }
}