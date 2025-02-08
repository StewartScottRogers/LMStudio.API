public record FileDescriptorRecord
{
    public int Id { get; init; }
    public string Name { get; init; }
    public FileModeEnum Mode { get; init; }
    public List<byte> Data { get; init; } = new();
    public int Position { get; set; }
}