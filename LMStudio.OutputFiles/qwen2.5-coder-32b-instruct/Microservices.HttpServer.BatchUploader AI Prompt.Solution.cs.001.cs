using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataContracts;
using DataContracts.Interfaces;

namespace HttpServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchUploadController : ControllerBase
    {
        private readonly IFileUploader fileUploader;

        public BatchUploadController(IFileUploader fileUploader)
        {
            this.fileUploader = fileUploader ?? throw new ArgumentNullException(nameof(fileUploader));
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
        {
            var uploadResultsTuple = await fileUploader.UploadFilesAsync(files);

            return Ok(uploadResultsTuple);
        }
    }
}