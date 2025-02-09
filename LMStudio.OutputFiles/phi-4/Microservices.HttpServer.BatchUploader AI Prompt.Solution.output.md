To implement this microservice application, we'll follow the outlined specifications using .NET 9.0 in Visual Studio 2022. The solution will consist of several components organized into separate files. Here's how you can structure and implement it:

### Step-by-Step Implementation

#### 1. Initialize a New Solution

Open Visual Studio 2022, create a new project with the following steps:
- Select `.NET Core` > `ASP.NET Core Web API`.
- Choose .NET 9.0 as the framework.
- Name your solution (e.g., `BatchUploaderService`).

#### 2. Project Structure

Create the following files and folders within the `BatchUploaderService` project:

```
/BatchUploaderService
    /Controllers
        FileUploadController.cs
    /Models
        BlobUploadModel.cs
    /Services
        IFileStorageService.cs
        AzureBlobStorageService.cs
    /Utilities
        DateTimeUtility.cs
    BatchUploaderService.Tests
        FileUploadTests.cs
    appsettings.json
    Program.cs
    Startup.cs
```

#### 3. Implement the Files

##### `appsettings.json`
Configure your connection string and blob container name:

```json
{
  "AzureBlobStorage": {
    "ConnectionString": "<Your Azure Blob Storage Connection String>",
    "ContainerName": "uploads"
  }
}
```

##### `Program.cs`
Set up the minimal API:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IFileStorageService, AzureBlobStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapPost("/upload", async (IFormFile file, IFileStorageService storageService) =>
{
    await storageService.StoreFileAsync(file);
    return Results.Ok("File uploaded successfully.");
});

app.Run();
```

##### `Startup.cs`
Configure services:

```csharp
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Add any additional service configurations here.
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();
    }
}
```

##### `/Models/BlobUploadModel.cs`
Define a record for model consistency:

```csharp
namespace BatchUploaderService.Models;

public readonly record class BlobUploadModel(IFormFile File);
```

##### `/Services/IFileStorageService.cs`
Define the storage service interface:

```csharp
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BatchUploaderService.Services;

public interface IFileStorageService
{
    Task StoreFileAsync(IFormFile file);
}
```

##### `/Services/AzureBlobStorageService.cs`
Implement Azure Blob Storage logic:

```csharp
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BatchUploaderService.Services;

public class AzureBlobStorageService : IFileStorageService
{
    private readonly IConfiguration _configuration;
    
    public AzureBlobStorageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task StoreFileAsync(IFormFile file)
    {
        string connectionString = _configuration.GetValue<string>("AzureBlobStorage:ConnectionString");
        string containerName = _configuration.GetValue<string>("AzureBlobStorage:ContainerName");

        var blobClient = new BlobServiceClient(connectionString).GetBlobContainerClient(containerName);
        await blobClient.CreateIfNotExistsAsync();

        string fileNameWithTimestamp = $"{Path.GetFileNameWithoutExtension(file.FileName)}-{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}{Path.GetExtension(file.FileName)}";
        var blob = blobClient.GetBlobClient(fileNameWithTimestamp);

        using (var stream = file.OpenReadStream())
        {
            await blob.UploadAsync(stream);
        }
    }
}
```

##### `/Utilities/DateTimeUtility.cs`
Utility for date-time operations:

```csharp
using System;

namespace BatchUploaderService.Utilities;

public static class DateTimeUtility
{
    public static string GetTimestamp()
    {
        return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    }
}
```

##### `/Controllers/FileUploadController.cs`
Define the file upload endpoint:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BatchUploaderService.Controllers;

[ApiController]
[Route("[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly IFileStorageService _fileStorageService;

    public FileUploadController(IFileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] BlobUploadModel model)
    {
        if (model.File == null || model.File.Length == 0)
        {
            return BadRequest("No file provided.");
        }
        
        await _fileStorageService.StoreFileAsync(model.File);
        return Ok("File uploaded successfully.");
    }
}
```

##### `/BatchUploaderService.Tests/FileUploadTests.cs`
Unit tests using the Microsoft Unit Test Framework:

```csharp
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BatchUploaderService.Controllers;
using BatchUploaderService.Services;
using System.IO;
using System.Threading.Tasks;

namespace BatchUploaderService.Tests;

[TestClass]
public class FileUploadTests
{
    [TestMethod]
    public async Task Upload_ValidFile_Success()
    {
        var mockStorageService = new Mock<IFileStorageService>();
        
        var controller = new FileUploadController(mockStorageService.Object);
        
        using (var stream = new MemoryStream())
        {
            await stream.WriteAsync(new byte[] { 1, 2, 3, 4 });
            stream.Position = 0;
            
            var formFile = new FormFile(stream, 0, stream.Length, "file", "test.txt");
            var model = new BlobUploadModel(formFile);
            
            var result = await controller.Upload(model) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("File uploaded successfully.", result.Value);
        }
    }

    // Additional tests for boundary conditions and error cases can be added here.
}
```

#### 4. Documentation

Create a `.README` file summarizing the project:

```markdown
# BatchUploaderService

## Overview
This service accepts file uploads via a POST request to `/upload` and stores them in Azure Blob Storage with a unique timestamped filename.

## Setup
1. Configure your Azure Blob Storage connection string and container name in `appsettings.json`.
2. Build the solution.
3. Run tests using the included unit test suite.

## Usage
To upload a file, make a POST request to `/upload` with a form-data body containing a file field.

```

### Final Considerations

- Ensure your Azure Blob Storage connection string and container name are correctly configured in `appsettings.json`.
- Use Visual Studio's built-in features to run unit tests.
- Review the code for any additional optimizations or improvements, especially regarding error handling and logging.

This structure adheres to the requirements specified and provides a clean, maintainable solution that is ready for deployment.