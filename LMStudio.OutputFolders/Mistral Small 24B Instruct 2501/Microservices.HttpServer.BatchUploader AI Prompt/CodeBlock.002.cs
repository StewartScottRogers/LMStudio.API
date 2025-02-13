using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net.Http.Json;

namespace BatchUploader.Tests
{
    [TestClass]
    public class FileUploaderTests
    {
        private readonly HttpClient httpClient = new HttpClient();

        [TestMethod]
        public async Task UploadFile_Success()
        {
            // Arrange
            var content = new MultipartFormDataContent();
            var fileStream = new FileStream("path_to_test_file", FileMode.Open);
            var fileContent = new StreamContent(fileStream);
            content.Add(fileContent, "file", "test_file.txt");

            // Act
            var response = await httpClient.PostAsync("https://localhost/upload", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}