using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace BatchUploaderApi.Tests.Controllers
{
    [TestClass]
    public class UploadControllerTests
    {
        private readonly Mock<IAzureBlobStorageService> mockAzureBlobStorageService;

        public UploadControllerTests()
        {
            this.mockAzureBlobStorageService = new Mock<IAzureBlobStorageService>();
        }

        [TestMethod]
        public async Task UploadFileAsync_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new FileUploadRequest { File = ... }; // Initialize with a valid file

            mockAzureBlobStorageService.Setup(service => service.UploadFileToBlobAsync(It.IsAny<FileUploadRequest>()))
                .ReturnsAsync((true, "http://example.com/uniquefilename"));

            var controller = new UploadController(mockAzureBlobStorageService.Object);

            // Act
            var result = await controller.UploadFileAsync(request);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UploadFileAsync_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new FileUploadRequest { File = null };

            var controller = new UploadController(mockAzureBlobStorageService.Object);

            // Act
            var result = await controller.UploadFileAsync(request);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task UploadFileAsync_UploadFailure_ReturnsInternalServerError()
        {
            // Arrange
            var request = new FileUploadRequest { File = ... }; // Initialize with a valid file

            mockAzureBlobStorageService.Setup(service => service.UploadFileToBlobAsync(It.IsAny<FileUploadRequest>()))
                .ReturnsAsync((false, null));

            var controller = new UploadController(mockAzureBlobStorageService.Object);

            // Act
            var result = await controller.UploadFileAsync(request);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
        }
    }
}