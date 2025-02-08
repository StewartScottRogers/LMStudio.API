var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(_ => new BlobStorageService("your-connection-string"));