using System.IO;

public class StandardStream : IFileDescriptor
{
    private readonly Stream stream;

    public StandardStream(Stream stream)
    {
        this.stream = stream;
    }

    public int Read(byte[] buffer, int offset, int count)
    {
        return stream.Read(buffer, offset, count);
    }

    public int Write(byte[] buffer, int offset, int count)
    {
        return stream.Write(buffer, offset, count);
    }

    public void Close()
    {
        stream.Close();
    }

    public void Dispose()
    {
        Close();
    }
}