using Microsoft.Extensions.Logging;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Multipart;
using System.Text;
using Azure.Storage.Blob;

public class HttpServer : Program
{
    public static async Task HandleFileUpload(
        IHTTPRequest request,
        IFormAssembly<IFileInfoModel> form,
        ILogger<HttpServer> logger)
    {
        try
        {
            var file = form.File?.FirstOrDefault(f => f.Name == "file") ?? throw new InvalidOperationException("No file uploaded");
            
            var fileNameSanitized = await SanitizeFileName(file.FileName);
            var timestamp = DateTime.UtcNow.ToString("yyyMMDDHHmmss");
            var blobName = $"{fileNameSanitized}_{timestamp}.blob";
            
            var contentDispositionHeader = new ContentDispositionHeaderValue("form-data")
            {
                FileName = file.FileName
            };

            await _blobContainerClient.UploadAsync(blobName, file.Content);
            return Tuple.Create(blobName, contentDispositionHeader);
        }
        catch (Exception e)
        {
            logger.LogError(e, "File upload failed");
            throw;
        }
    }

    private static async Task<string> SanitizeFileName(string fileName)
    {
        var cleanFileName = new StringBuilder(fileName).RemoveRange(0, 255).ToString();
        return await Task.FromResult(cleanFileName);
    }
}