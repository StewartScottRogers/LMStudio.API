namespace DataContracts.Records
{
    public record FileUploadRequest
    {
        public string FileName { get; init; }
        public Stream FileStream { get; init; }
    }
}