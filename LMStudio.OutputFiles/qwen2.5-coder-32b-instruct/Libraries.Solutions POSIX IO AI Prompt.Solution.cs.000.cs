public record FileDescriptorData(
    int FileDescriptorId,
    string Name,
    byte[] Data,
    long CurrentPosition);

public class FileDescriptor
{
    public readonly FileDescriptorData DescriptorData;

    public FileDescriptor(FileDescriptorData descriptorData)
    {
        DescriptorData = descriptorData;
    }

    public void Write(byte[] data, int offset, int count)
    {
        Array.Copy(data, 0, DescriptorData.Data, (int)DescriptorData.CurrentPosition, count);
        DescriptorData.CurrentPosition += count;
    }

    public int Read(byte[] buffer, int offset, int count)
    {
        var bytesToRead = Math.Min(count, DescriptorData.Data.Length - DescriptorData.CurrentPosition);
        Array.Copy(DescriptorData.Data, DescriptorData.CurrentPosition, buffer, offset, bytesToRead);
        DescriptorData.CurrentPosition += bytesToRead;
        return bytesToRead;
    }

    public void Seek(long offset, SeekOrigin origin)
    {
        switch (origin)
        {
            case SeekOrigin.Begin:
                DescriptorData.CurrentPosition = offset;
                break;
            case SeekOrigin.Current:
                DescriptorData.CurrentPosition += offset;
                break;
            case SeekOrigin.End:
                DescriptorData.CurrentPosition = DescriptorData.Data.Length + offset;
                break;
        }
    }

    public void Close()
    {
        // Simulate closing the file descriptor
        DescriptorData = new FileDescriptorData(DescriptorData.FileDescriptorId, DescriptorData.Name, Array.Empty<byte>(), 0);
    }
}