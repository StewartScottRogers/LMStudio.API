using BatchUploader.WebApi.Services;
using Azure.Storage.Blobs;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();
        string connectionString = "YourAzureStorageConnectionStringHere";
        services.AddSingleton(blobServiceClient: new BlobServiceClient(connectionString));

        // Register the blob storage service
        services.AddScoped<IBlobStorageService, BlobStorageService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}