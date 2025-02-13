using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class BlobServiceTests
{
    private readonly ILogger<BlobService> _loggerMock;
    private readonly BlobContainerClient _blobContainerMock;

    public BlobServiceTests()
    {
        var logger = new Logger<BlobService>(new LoggerFactory(), _loggerMock);
        _blobContainerMock = new BlobContainerClient(
            "https://teststorageaccount.blob.core.windows.net",
            true,
            new AzureStorageOptions
                { ConcurrentRequestHandling = ConcurrentRequestHandler.None }
        );
    }

    [Fact]
    public async Task UploadFile_ShouldSaveToBlob()
    {
        // Arrange
        var fileName = "testfile.txt";
        var stream = new MemoryStream();
        _loggerMock.Clear();

        // Act
        var result = await BlobService.UploadFileAsync(stream, fileName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fileName, result.FileName);
        
        var blobInfo = await BlobService.GetBlobAsync(fileName);
        Assert.NotNull(blobInfo);
    }

    [Fact]
    public async Task GetBlob_ShouldRetrieveFileInfo()
    {
        var fileName = "testfile.txt";
        _loggerMock.Clear();

        var blobService = new BlobService(_blobContainerMock, _loggerMock);
        var result = await blobService.GetBlobAsync(fileName);

        Assert.NotNull(result);
    }
}

### ControllerTests.cs