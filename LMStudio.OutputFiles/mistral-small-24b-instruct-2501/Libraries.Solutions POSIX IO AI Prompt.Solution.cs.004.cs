namespace PosixIoLibrary
{
    public class StandardStreams : IFileDescriptor
    {
        private readonly byte[] stdin = new byte[1024];
        private readonly byte[] stdout = new byte[1024];
        private readonly byte[] stderr = new byte[1024];

        public int Open(string fileName)
        {
            // Simulate opening standard streams.
            return 0;
        }

        public int Read(int fd, out byte[] data)
        {
            data = fd switch
            {
                0 => stdin,
                _ => throw new ArgumentOutOfRangeException(nameof(fd), "Invalid file descriptor.")
            };
            return data.Length;
        }

        public int Write(int fd, byte[] data)
        {
            if (fd == 1)
            {
                Array.Copy(data, stdout, Math.Min(stdout.Length, data.Length));
                return data.Length;
            }
            else if (fd == 2)
            {
                Array.Copy(data, stderr, Math.Min(stderr.Length, data.Length));
                return data.Length;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(fd), "Invalid file descriptor.");
            }
        }

        public void Close(int fd)
        {
            // Simulate closing standard streams.
        }

        public int Lseek(int fd, long offset)
        {
            // Simulate lseek operation. Standard streams don't support seek.
            return 0;
        }
    }
}