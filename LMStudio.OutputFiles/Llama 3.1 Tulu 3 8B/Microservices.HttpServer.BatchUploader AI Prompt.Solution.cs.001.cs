public interface IFileUploader
{
    Task<string> SaveToTemp(IFormFile file); // Save the file to a temporary location
}