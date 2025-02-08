using System;

public static class SystemCalls
{
    private static readonly FileSystem fileSystem = new();

    public static int Open(string path)
    {
        return fileSystem.Open(path);
    }

    public static var ReadTuple(IFileDescriptor descriptor, byte[] buffer, int offset, int count)
    {
        return new { Buffer = buffer, BytesRead = descriptor.Read(buffer, offset, count) };
    }

    public static void Write(IFileDescriptor descriptor, byte[] buffer, int offset, int count)
    {
        descriptor.Write(buffer, offset, count);
    }

    public static void Close(int fd)
    {
        var descriptor = fileSystem.GetFileDescriptor(fd);
        descriptor.Close();
    }
}