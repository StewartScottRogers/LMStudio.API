using HttpServer.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace HttpServer.Tests
{
    public class BatchUploaderControllerTests
    {
        [Fact]
        public async Task UploadAsync_ShouldReturnCreatedWhenValidFile()
        {
            // Arrange
            var mockBlobStorage = new Mock<IBlobStorageService>();
            mockBlobStorage.Setup(bs => bs.SaveAsync(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var controller = new BatchUploaderController(mockBlobStorage.Object);

            using (var stream = new MemoryStream())
            {
                var file = new FormFile(stream, 0, stream.Length, "text/plain", "sample.txt");

                // Act
                var result = await controller.UploadAsync(file);

                // Assert
                Assert.IsType<CreatedAtActionResult>(result.Result);
            }
        }

        [Fact]
        public async Task UploadAsync_ShouldReturnBadRequestForInvalidFile()
        {
            // Arrange
            var controller = new BatchUploaderController(null); // Mock not required for this basic validation

            // Act
            var result = await controller.UploadAsync(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}