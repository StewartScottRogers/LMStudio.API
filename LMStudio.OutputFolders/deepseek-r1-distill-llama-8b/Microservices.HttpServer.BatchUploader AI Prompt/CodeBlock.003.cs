using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddApplicationSerializerSettings(
                new ApplicationSerializerSettings { MaxModelSize = 1000 });

        services.AddTransient<IBlobService, BlobService>();
        
        var blobStorageConfig = Configuration.GetSection("BlobStorage");
        var blobContainerUri = blobStorageConfig.GetValue<string>("ConnectionString");
        
        if (!string.IsNullOrEmpty(blobContainerUri))
        {
            services.AddAzureStorage(
                blobContainerUri,
                true,
                new AzureStorageOptions()
                    { ConcurrentRequestHandling = ConcurrentRequestHandler.None }
            );
        }
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionMiddleware();
        app.UseWebOptimizer(env);

        if (!env.IsDevelopment())
            app.UseExceptionHandler("/error");
        
        app.UseHttpsRedirection();
        app.UseStaticFiles(new StaticFileOptions { DefaultContentType = "text/plain" });
        
        app.UseRouting();

        app.MapFallbackToController("Default", "Index");
    }
}