using System.Collections.Concurrent;

namespace PosixIoLibrary
{
    public class Pipe
    {
        private readonly ConcurrentQueue<byte> inputQueue = new();
        private readonly ConcurrentQueue<byte> outputQueue = new();

        public void Write(byte data)
        {
            inputQueue.Enqueue(data);
        }

        public byte Read()
        {
            if (outputQueue.TryDequeue(out var data))
            {
                return data;
            }
            else
            {
                throw new InvalidOperationException("Pipe is empty.");
            }
        }
    }
}