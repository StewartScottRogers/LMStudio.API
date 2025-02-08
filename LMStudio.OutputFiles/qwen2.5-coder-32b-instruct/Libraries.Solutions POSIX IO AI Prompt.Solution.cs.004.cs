public class InMemoryFileSystem : IFileSystem
{
    private readonly Dictionary<int, FileDescriptorRecord> fileDescriptors;
    private int nextFileDescriptorId;

    public InMemoryFileSystem()
    {
        fileDescriptors = new();
        nextFileDescriptorId = 3; // Simulate stdin(0), stdout(1), stderr(2)
    }

    public int Open(string name, FileModeEnum mode)
    {
        var fileDescriptor = new FileDescriptorRecord
        {
            Id = nextFileDescriptorId++,
            Name = name,
            Mode = mode
        };
        
        fileDescriptors[fileDescriptor.Id] = fileDescriptor;
        return fileDescriptor.Id;
    }

    public int Read(int fileDescriptor, byte[] buffer, int count)
    {
        if (!fileDescriptors.TryGetValue(fileDescriptor, out var fd) || fd.Mode == FileModeEnum.Write)
            throw new InvalidOperationException();

        var bytesToRead = Math.Min(count, fd.Data.Count - fd.Position);
        Array.Copy(fd.Data.ToArray(), fd.Position, buffer, 0, bytesToRead);
        fd.Position += bytesToRead;
        return bytesToRead;
    }

    public int Write(int fileDescriptor, byte[] buffer, int count)
    {
        if (!fileDescriptors.TryGetValue(fileDescriptor, out var fd) || (fd.Mode != FileModeEnum.Write && fd.Mode != FileModeEnum.ReadWrite))
            throw new InvalidOperationException();

        for (int i = 0; i < count; i++)
        {
            if (fd.Position >= fd.Data.Count)
                fd.Data.Add(buffer[i]);
            else
                fd.Data[fd.Position] = buffer[i];
            fd.Position++;
        }
        return count;
    }

    public void Close(int fileDescriptor)
    {
        if (!fileDescriptors.ContainsKey(fileDescriptor))
            throw new InvalidOperationException();

        fileDescriptors.Remove(fileDescriptor);
    }

    public void Seek(int fileDescriptor, long offset, SeekWhenceEnum whence)
    {
        if (!fileDescriptors.TryGetValue(fileDescriptor, out var fd))
            throw new InvalidOperationException();

        switch (whence)
        {
            case SeekWhenceEnum.Begin:
                fd.Position = (int)offset;
                break;
            case SeekWhenceEnum.Current:
                fd.Position += (int)offset;
                break;
            case SeekWhenceEnum.End:
                fd.Position = fd.Data.Count + (int)offset;
                break;
        }
    }
}