using System.Collections.Concurrent;

public class Pipe : IFileDescriptor
{
    private readonly ConcurrentQueue<byte> buffer = new();

    public int Read(byte[] buffer, int offset, int count)
    {
        var bytesRead = 0;
        while (bytesRead < count && buffer.TryDequeue(out var b))
        {
            buffer[offset + bytesRead] = b;
            bytesRead++;
        }
        return bytesRead;
    }

    public int Write(byte[] buffer, int offset, int count)
    {
        for (var i = 0; i < count; i++)
        {
            this.buffer.Enqueue(buffer[offset + i]);
        }
        return count;
    }

    public void Close()
    {
        // Implementation for closing the pipe
    }

    public void Dispose()
    {
        Close();
    }
}