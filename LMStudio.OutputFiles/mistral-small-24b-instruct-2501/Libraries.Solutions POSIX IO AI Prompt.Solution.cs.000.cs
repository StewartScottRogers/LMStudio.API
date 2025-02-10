using System;
using System.Collections.Generic;

namespace PosixIoLibrary
{
    public class FileDescriptor : IFileDescriptor
    {
        private readonly Dictionary<int, byte[]> fileDescriptors = new();
        private int nextFd = 3; // Start after stdin (0), stdout (1), and stderr (2)

        public int Open(string fileName)
        {
            if (!fileDescriptors.ContainsKey(nextFd))
            {
                fileDescriptors[nextFd] = new byte[1024]; // Simulate a small buffer
                return nextFd++;
            }
            throw new InvalidOperationException("File descriptor already exists.");
        }

        public int Read(int fd, out byte[] data)
        {
            if (fileDescriptors.TryGetValue(fd, out var buffer))
            {
                data = buffer;
                return buffer.Length;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(fd), "Invalid file descriptor.");
            }
        }

        public int Write(int fd, byte[] data)
        {
            if (fileDescriptors.TryGetValue(fd, out var buffer))
            {
                Array.Copy(data, 0, buffer, 0, Math.Min(buffer.Length, data.Length));
                return data.Length;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(fd), "Invalid file descriptor.");
            }
        }

        public void Close(int fd)
        {
            if (fileDescriptors.ContainsKey(fd))
            {
                fileDescriptors.Remove(fd);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(fd), "Invalid file descriptor.");
            }
        }

        public int Lseek(int fd, long offset)
        {
            // Simulate lseek operation. In-memory buffer doesn't support seek.
            return 0;
        }
    }
}