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