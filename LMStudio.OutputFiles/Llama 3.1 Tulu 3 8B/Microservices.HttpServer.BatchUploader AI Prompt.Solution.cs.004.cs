using System.IO;
using Microsoft.AspNetCore.Http;
using Xunit;

public class FileUploaderTests
{
    [Fact]
    public async Task SavesToFile()
    {
        // Arrange
        var file = new FormFile(new MemoryStream(), 0, 10, "test", "test.txt");
        var uploader = new FileUploader();
        
        // Act
        var filePath = await uploader.SaveToTemp(file);
        
        // Assert
        Assert.True(File.Exists(filePath));
    }
}