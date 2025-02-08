using BatchUploader.WebApi.Services;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IBlobStorageService, BlobStorageService>();

// Configure Azure Storage Connection String
string connectionString = "YourAzureStorageConnectionStringHere";
builder.Services.AddSingleton(blobServiceClient: new BlobServiceClient(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();