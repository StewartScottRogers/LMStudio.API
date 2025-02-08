using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using Microsoft.Storage.Blob;

public record BlobUploadResponse
{
    public string?_blobContainer { get; init; }
    public string?_fileName { get; init; }
    public string?_uploadDate { get; init; }
}

public class HttpServer
{
    private readonly IConfiguration _configuration;

    public HttpServer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<BlobUploadResponse> ProcessUploadAsync(HttpRequest request)
    {
        if (request.Method != "POST")
            return new BlobUploadResponse { _uploadDate = DateTime.Now.ToString("yyyyMMddHHmmss"), _blobContainer = null, _fileName = null };

        var stream = await request.ReadAsStreamAsync();
        var fileName = GetFileName(request);
        var blobClient = new BlobClient(_configuration["BlobConnectionString"], _configuration["BlobContainerName"]);

        try
        {
            var blobItem = new BlobItem(fileName)
            {
                Data = stream
            };

            await blobClient.AppendToBlobAsync(blobItem);

            return new BlobUploadResponse { 
                _uploadDate = DateTime.Now.ToString("yyyyMMddHHmmss"), 
                _blobContainer = _configuration["BlobContainerName"], 
                _fileName = fileName 
            };
        }
        catch (Exception ex)
        {
            // Log error
            return new BlobUploadResponse { 
                _uploadDate = DateTime.Now.ToString("yyyyMMddHHmmss"), 
                _blobContainer = _configuration["BlobContainerName"], 
                _fileName = "error-" + Guid.NewGuid().ToString() + ".txt" 
            };
        }
    }

    private static string GetFileName(HttpRequest request)
    {
        var headers = request.Headers;
        var dispositionHeader = headers.GetValues("Content-Disposition");
        
        if (dispositionHeader == null) return "file.txt";
        
        string filename = dispositionHeader[0];
        filename = filename.Substring(0, filename.IndexOf('\'')) // Remove quotes
                           .Trim();
        
        return Path.GetFileName(filename);
    }
}

public class Program
{
    public static async void Main()
    {
        var listener = new HttpListener();
        listener.Prefix = "*";
        listener.Port = 8080;
        listener.AutoForwardRewrite = false;

        listener.Start(() =>
        {
            var server = new HttpServer(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables());

            listener.RequestHandlers.Add("POST", (context) => 
            {
                context.Response.StatusCode = 200;
                string response = "File uploaded successfully.";
                context.Response.Content = response;
            });

            await server.ProcessUploadAsync(context.Request);
        });
    }
}