using System;

public record UploadResult
{
    public string FileName { get; init; }
    public DateTime Timestamp { get; init; }
}

## Tuple Extensions

### Tuples.cs