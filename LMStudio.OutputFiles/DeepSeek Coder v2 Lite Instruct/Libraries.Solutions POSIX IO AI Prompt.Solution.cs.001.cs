namespace POSIXIO.SystemCalls
{
    public static class SystemCalls
    {
        public static Stream Open(string path, FileMode mode)
        {
            // Simulate file opening logic here
            return new MemoryStream();
        }

        public static int Read(int fd, byte[] buffer, int offset, int count)
        {
            var stream = GetStreamFromFd(fd);
            if (stream == null) throw new InvalidOperationException("Invalid file descriptor");
            return stream.Read(buffer, offset, count);
        }

        // Other system call methods...
    }
}