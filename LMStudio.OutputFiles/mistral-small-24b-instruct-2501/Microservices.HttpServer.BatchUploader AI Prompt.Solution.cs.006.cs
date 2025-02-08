using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Azure.Storage.Blobs;
using System.IO;

namespace BatchUploader.WebApi.Tests.UnitTests
{
    [TestClass]
    public class BlobStorageServiceTests
    {
        private Mock<IBlobClient> _mockBlobClient;
        private BlobStorageService _blobStorageService;

        [TestInitialize]
        public void Setup()
        {
            var mockContainerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            var mockBlobServiceClient = new Mock<BlobServiceClient>(MockBehavior.Strict);

            mockContainerClient.Setup(c => c.CreateIfNotExistsAsync(It.IsAny<BlobContainerCreateOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BlobContainerInfo());

            _mockBlobClient = new Mock<IBlobClient>(MockBehavior.Strict);
            mockContainerClient.Setup(c => c.GetBlobClient("fileName"))
                .Returns(_mockBlobClient.Object);

            mockBlobServiceClient.Setup(s => s.GetBlobContainerClient("batch-uploads"))
                .Returns(mockContainerClient.Object);

            _blobStorageService = new BlobStorageService(mockBlobServiceClient.Object);
        }

        [TestMethod]
        public async Task UploadFileToBlobAsync_ValidFile_ReturnsSuccess()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.OpenReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes("file content")));

            _mockBlobClient.Setup(b => b.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var resultTuple = await _blobStorageService.UploadFileToBlobAsync(fileMock.Object);

            // Assert
            Assert.IsTrue(resultTuple.Success);
        }

        [TestMethod]
        public async Task UploadFileToBlobAsync_InvalidFile_ReturnsFailure()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            _mockBlobClient.Setup(b => b.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            // Act
            var resultTuple = await _blobStorageService.UploadFileToBlobAsync(fileMock.Object);

            // Assert
            Assert.IsFalse(resultTuple.Success);
        }
    }
}