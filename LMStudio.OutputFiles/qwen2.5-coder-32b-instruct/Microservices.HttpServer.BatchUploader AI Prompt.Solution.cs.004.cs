using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataContracts.Interfaces;
using HttpServer.Controllers;
using Xunit;

namespace Tests
{
    public class BatchUploadControllerTests
    {
        [Fact]
        public async Task UploadFiles_ReturnsOk()
        {
            // Arrange
            var mockFileUploader = new Mock<IFileUploader>();
            mockFileUploader.Setup(x => x.UploadFilesAsync(It.IsAny<List<IFormFile>>()))
                .ReturnsAsync(new List<(string, bool)> { ("file1.txt", true) });

            var controller = new BatchUploadController(mockFileUploader.Object);
            var formCollection = GetSampleFormFiles();

            // Act
            var result = await controller.UploadFiles(formCollection);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
        }

        private List<IFormFile> GetSampleFormFiles()
        {
            var files = new List<IFormFile>();

            for (var i = 0; i < 5; i++)
            {
                using var stream = new MemoryStream();
                using var writer = new StreamWriter(stream);

                writer.Write($"Hello World {i}");
                writer.Flush();
                stream.Position = 0;

                var file = new FormFile(stream, 0, stream.Length, "id_form_file", $"file{i}.txt")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "text/plain"
                };

                files.Add(file);
            }

            return files;
        }
    }
}