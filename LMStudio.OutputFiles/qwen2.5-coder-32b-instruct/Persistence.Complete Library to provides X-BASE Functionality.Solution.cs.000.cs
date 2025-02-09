namespace XBaseLibrary.Records
{
    public record XBaseRecord
    {
        public string RecordId { get; init; }
        public Dictionary<string, object> Fields { get; init; } = new();
    }
}