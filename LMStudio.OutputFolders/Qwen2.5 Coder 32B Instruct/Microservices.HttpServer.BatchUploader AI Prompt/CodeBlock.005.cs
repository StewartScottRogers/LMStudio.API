using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.IO;
using Xunit;

public class FileUploadControllerTests
{
    private readonly Mock<IFileStorageService> _fileStorageServiceMock;
    private readonly FileUploadController _controller;

    public FileUploadControllerTests()
    {
        _fileStorageServiceMock = new Mock<IFileStorageService>();
        _controller = new FileUploadController(_fileStorageServiceMock.Object);
    }

    [Fact]
    public async Task Upload_ReturnsBadRequest_WhenNoFileIsProvided()
    {
        var result = await _controller.Upload(null);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Upload_ReturnsOk_WhenFileUploadSucceeds()
    {
        var mockFormFile = new FormFile(new MemoryStream(), 0, 123, "id_from_form", "test.txt");

        _fileStorageServiceMock.Setup(service => service.UploadFileAsync(It.IsAny<Stream>(), It.IsAny<string>()))
            .ReturnsAsync((true, string.Empty));

        var result = await _controller.Upload(mockFormFile);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Upload_ReturnsStatusCode500_WhenFileUploadFails()
    {
        var mockFormFile = new FormFile(new MemoryStream(), 0, 123, "id_from_form", "test.txt");

        _fileStorageServiceMock.Setup(service => service.UploadFileAsync(It.IsAny<Stream>(), It.IsAny<string>()))
            .ReturnsAsync((false, "Error message"));

        var result = await _controller.Upload(mockFormFile);

        Assert.IsType<ObjectResult>(result);
        var objectResult = (ObjectResult)result;
        Assert.Equal(500, objectResult.StatusCode);
    }
}