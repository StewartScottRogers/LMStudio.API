using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BatchUploaderService.Controllers;
using BatchUploaderService.Services;
using System.IO;
using System.Threading.Tasks;

namespace BatchUploaderService.Tests;

[TestClass]
public class FileUploadTests
{
    [TestMethod]
    public async Task Upload_ValidFile_Success()
    {
        var mockStorageService = new Mock<IFileStorageService>();
        
        var controller = new FileUploadController(mockStorageService.Object);
        
        using (var stream = new MemoryStream())
        {
            await stream.WriteAsync(new byte[] { 1, 2, 3, 4 });
            stream.Position = 0;
            
            var formFile = new FormFile(stream, 0, stream.Length, "file", "test.txt");
            var model = new BlobUploadModel(formFile);
            
            var result = await controller.Upload(model) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("File uploaded successfully.", result.Value);
        }
    }

    // Additional tests for boundary conditions and error cases can be added here.
}