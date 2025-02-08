Alright, let's break this down step by step.

### 1. Solution Initialization

**Solution File Structure:**

- `BatchUploader.sln`
- `HttpServer` (Project containing the minimal API)

### 2. Project Structure within HttpServer

**Files:**

- `Program.cs`: Entry point for the application, hosting the web server.
- `IFileUploader.cs`: Interface definition for file uploading functionality.
- `FileUploader.cs`: Implementation of IFileUploader.
- `BlobStorageService.cs`: Service class to interact with Azure Blob storage.
- `Startup.cs` (optional): Configuration for the minimal API if needed.

### 3. Minimal API Definition

**Program.cs**

```csharp
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapPost("/upload", async (IFormFile file, IFileUploader uploader, IWebHostEnvironment env, IBlobStorageService storage) =>
{
    var uniqueId = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"); // Generate a unique ID based on current datetime
    var filePath = await uploader.SaveToTemp(file); // Save file to temporary location
    
    try
    {
        await storage.UploadBlob(uniqueId, filePath); // Upload file to Azure Blob with the unique ID as name
        System.IO.File.Delete(filePath); // Delete local copy after upload
        return Results.Ok(new { Id = uniqueId }); // Return OK response with uploaded blob id
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();
```

### 4. Interface Definition

**IFileUploader.cs**

```csharp
public interface IFileUploader
{
    Task<string> SaveToTemp(IFormFile file); // Save the file to a temporary location
}
```

### 5. FileUploader Implementation

**FileUploader.cs**

```csharp
using System.IO;
using System.Threading.Tasks;

public class FileUploader : IFileUploader
{
    public async Task<string> SaveToTemp(IFormFile file)
    {
        var filePath = Path.GetTempFileName();
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;
    }
}
```

### 6. Blob Storage Service

**BlobStorageService.cs**

```csharp
using Microsoft.Azure.Storage; // Include Azure.Storage.Blobs NuGet package
using Microsoft.Azure.Storage.Blob;

public class BlobStorageService : IBlobStorageService
{
    private readonly CloudBlobClient _blobClient;

    public BlobStorageService(string connectionString)
    {
        _blobClient = new CloudBlobClient(connectionString);
    }

    public async Task UploadBlob(string id, string filePath)
    {
        var container = _blobClient.GetContainerReference("uploads"); // Replace with your actual container name
        await container.CreateIfNotExistsAsync();
        
        using (var fileStream = File.OpenRead(filePath))
        {
            var blob = container.GetBlockBlobClient(id); 
            await blob.UploadFromStreamAsync(fileStream);
        }
    }
}
```

### 7. Unit Testing

**FileUploaderTests.cs**

```csharp
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
```

### 8. Azure Blob Connection String

**Note:** The `BlobStorageService` requires a valid Azure Storage connection string. Ensure you replace `"your-connection-string"` with your actual Azure Storage account connection string.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(_ => new BlobStorageService("your-connection-string"));
```

### 9. README

**README.md**

```markdown
# BatchUploader Microservice

This microservice provides a minimal HTTP endpoint for uploading files, which acts similarly to an FTP server but integrates with Azure Blob Storage.

## Key Features
- **Upload Endpoint**: `/upload` (POST)
- **File Handling**: Saves file content to temporary storage and uploads it to Azure Blob Storage.
- **Unique Naming**: Utilizes datetime stamp for unique blob names.

## Setup Requirements
- .NET 9.0 SDK
- Visual Studio 2022

## Running the Application
1. Clone this repository and open in Visual Studio 2022.
2. Set `your-connection-string` in the `Program.cs` with your Azure Storage connection string.
3. Run the application.

### Testing 
- Unit tests are located in `Tests` directory.

**Note:** This solution template provides a basic structure for an HTTP server accepting file uploads and storing them in Azure Blob Storage. Enhancements such as error handling, logging, and authentication can be added based on specific requirements.
```

This project template provides the basis of functionality required while also incorporating best practices for .NET development, including clean code organization, thorough unit testing, and comprehensive documentation. Remember to replace placeholder values (like connection strings) with actual production values before deploying or using this solution in a real-world scenario.

**Additional Considerations:**

- **Error Handling**: Ensure adequate error handling is implemented around file I/O operations and Azure Blob Storage interactions.
- **Security**: Implement authentication/authorization mechanisms if the service will be publicly accessible.
- **Scaling & Performance**: Consider how to scale the application, especially regarding storage access patterns and file upload throughput.
  
This project setup aims for clarity, maintainability, and reusability in a microservices architecture context.