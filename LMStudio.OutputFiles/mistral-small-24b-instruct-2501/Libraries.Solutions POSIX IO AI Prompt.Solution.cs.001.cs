using System.Collections.Generic;

public class FileSystem
{
    private readonly Dictionary<int, IFileDescriptor> fileDescriptors = new();

    public int Open(string path)
    {
        // Implementation for opening a file and returning a file descriptor
        return -1;  // Placeholder
    }

    public IFileDescriptor GetFileDescriptor(int fd)
    {
        if (fileDescriptors.TryGetValue(fd, out var fileDescriptor))
            return fileDescriptor;
        else
            throw new InvalidOperationException("Invalid file descriptor.");
    }
}