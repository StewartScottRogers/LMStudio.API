public interface IBlobService
{
    Task<UploadResultTuple> UploadFileAsync(Stream fileStream, string fileName);
    Task<BlobInfoTuple> GetBlobAsync(string fileName);
}