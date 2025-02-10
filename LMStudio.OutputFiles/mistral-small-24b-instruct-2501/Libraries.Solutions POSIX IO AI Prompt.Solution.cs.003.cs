using System.IO;

namespace PosixIoLibrary
{
    public class StreamOperations : IFileDescriptor
    {
        private readonly MemoryStream memoryStream = new();

        public int Open(string fileName)
        {
            // Simulate opening a stream.
            return 0;
        }

        public int Read(int fd, out byte[] data)
        {
            var buffer = memoryStream.ToArray();
            data = buffer;
            return buffer.Length;
        }

        public int Write(int fd, byte[] data)
        {
            memoryStream.Write(data);
            return data.Length;
        }

        public void Close(int fd)
        {
            // Simulate closing a stream.
        }

        public int Lseek(int fd, long offset)
        {
            // Simulate lseek operation. In-memory buffer doesn't support seek.
            return 0;
        }
    }
}