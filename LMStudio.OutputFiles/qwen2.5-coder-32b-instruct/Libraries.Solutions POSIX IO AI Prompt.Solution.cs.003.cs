public interface IPipe
{
    void Write(byte[] data, int offset, int count);
    int Read(byte[] buffer, int offset, int count);
}

public class Pipe : IPipe
{
    private readonly Queue<byte> pipeBuffer;

    public Pipe()
    {
        pipeBuffer = new Queue<byte>();
    }

    public void Write(byte[] data, int offset, int count)
    {
        foreach (var b in data.Skip(offset).Take(count))
        {
            pipeBuffer.Enqueue(b);
        }
    }

    public int Read(byte[] buffer, int offset, int count)
    {
        var bytesRead = 0;
        while (bytesRead < count && pipeBuffer.Count > 0)
        {
            buffer[offset + bytesRead] = pipeBuffer.Dequeue();
            bytesRead++;
        }
        return bytesRead;
    }
}