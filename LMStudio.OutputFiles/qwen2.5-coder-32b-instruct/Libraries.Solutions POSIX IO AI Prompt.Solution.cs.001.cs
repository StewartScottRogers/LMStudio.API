public interface IFileSystemManager
{
    int Open(string name, OpenFlags flags);
    void Close(int fileDescriptorId);
    int Read(int fileDescriptorId, byte[] buffer, int offset, int count);
    int Write(int fileDescriptorId, byte[] data, int offset, int count);
    long Seek(int fileDescriptorId, long offset, SeekOrigin origin);
}

public enum OpenFlags
{
    ReadOnly = 0,
    WriteOnly = 1,
    ReadWrite = 2
}

public class FileSystemManager : IFileSystemManager
{
    private readonly List<FileDescriptor> fileDescriptors;
    private int nextFileDescriptorId;

    public FileSystemManager()
    {
        fileDescriptors = new List<FileDescriptor>();
        nextFileDescriptorId = 3; // Standard streams are 0, 1, 2
    }

    public int Open(string name, OpenFlags flags)
    {
        var newFileDescriptorData = new FileDescriptorData(nextFileDescriptorId++, name, Array.Empty<byte>(), 0);
        fileDescriptors.Add(new FileDescriptor(newFileDescriptorData));
        return newFileDescriptorData.FileDescriptorId;
    }

    public void Close(int fileDescriptorId)
    {
        var fd = GetFileDescriptor(fileDescriptorId);
        fd.Close();
    }

    public int Read(int fileDescriptorId, byte[] buffer, int offset, int count)
    {
        var fd = GetFileDescriptor(fileDescriptorId);
        return fd.Read(buffer, offset, count);
    }

    public int Write(int fileDescriptorId, byte[] data, int offset, int count)
    {
        var fd = GetFileDescriptor(fileDescriptorId);
        fd.Write(data, offset, count);
        return count;
    }

    public long Seek(int fileDescriptorId, long offset, SeekOrigin origin)
    {
        var fd = GetFileDescriptor(fileDescriptorId);
        fd.Seek(offset, origin);
        return fd.DescriptorData.CurrentPosition;
    }

    private FileDescriptor GetFileDescriptor(int fileDescriptorId)
    {
        var fd = fileDescriptors.FirstOrDefault(f => f.DescriptorData.FileDescriptorId == fileDescriptorId);
        if (fd == null) throw new ArgumentException("Invalid file descriptor");
        return fd;
    }
}