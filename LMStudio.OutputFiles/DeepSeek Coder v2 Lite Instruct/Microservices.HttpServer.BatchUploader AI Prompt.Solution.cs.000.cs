var builder = WebApplication.CreateBuilder();
    var app = builder.Build();

    app.MapPost("/upload", async context =>
    {
        // Logic to handle file upload and store it in Azure Blob Storage
    });

    app.Run();