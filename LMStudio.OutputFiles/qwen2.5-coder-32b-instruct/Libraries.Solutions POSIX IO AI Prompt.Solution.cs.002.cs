public class StandardStreams : IFileSystemManager
{
    private readonly FileSystemManager fileSystemManager;

    public StandardStreams(FileSystemManager fileSystemManager)
    {
        this.fileSystemManager = fileSystemManager;
    }

    public int Open(string name, OpenFlags flags) => fileSystemManager.Open(name, flags);
    public void Close(int fileDescriptorId) => fileSystemManager.Close(fileDescriptorId);
    public int Read(int fileDescriptorId, byte[] buffer, int offset, int count) => fileSystemManager.Read(fileDescriptorId, buffer, offset, count);
    public int Write(int fileDescriptorId, byte[] data, int offset, int count) => fileSystemManager.Write(fileDescriptorId, data, offset, count);
    public long Seek(int fileDescriptorId, long offset, SeekOrigin origin) => fileSystemManager.Seek(fileDescriptorId, offset, origin);

    // Additional methods for standard I/O operations
}