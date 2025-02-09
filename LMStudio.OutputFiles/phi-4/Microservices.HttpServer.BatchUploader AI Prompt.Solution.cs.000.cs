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