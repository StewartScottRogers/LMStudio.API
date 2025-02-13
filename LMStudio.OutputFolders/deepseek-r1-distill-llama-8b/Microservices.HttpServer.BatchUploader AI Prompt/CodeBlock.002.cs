using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();
        services.AddMvc()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddApplicationSerializerSettings(
                new ApplicationSerializerSettings { MaxModelSize = 1000 });

        services.AddTransient<IBlobService, BlobService>();
        
        var provider = services.BuildServiceProvider();

        var app = new Microsoft.AspNetCore.Builder.ApplicationBuilder();
        app.UseWebConstants();
        app.UseStaticFiles();
        app.UseRouting();

        app.Use(async (context) =>
        {
            if (!context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                return await context.Next();

            try
            {
                // Handle POST request, parse the file and save to blob storage
                var file = await context.Request.PathSegments.First();
                
                using var stream = await context.Request.Content.ReadAsStreamAsync();
                var fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(file)}";

                var blobService = provider.GetService<IBlobService>();
                var result = await blobService.UploadFileAsync(stream, fileName);

                return Ok(result.FileName);
            }
            catch (Exception ex)
            {
                return Problem(ex, "Failed to process request");
            }
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapFallbackToController("Default", "Index");
        });

        app.Run(provider);
    }
}