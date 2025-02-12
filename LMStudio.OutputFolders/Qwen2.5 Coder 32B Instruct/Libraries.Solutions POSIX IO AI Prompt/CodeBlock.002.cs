// FileDescriptorRecord.cs
public readonly record struct FileDescriptorRecord(
    int FileDescriptor,
    string Path,
    FileModeEnum Mode,
    byte[] DataBuffer,
    long CurrentPosition);