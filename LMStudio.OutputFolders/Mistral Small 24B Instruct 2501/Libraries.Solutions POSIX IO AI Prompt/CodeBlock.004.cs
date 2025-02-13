using System;
using System.IO;

namespace InMemoryPosixIoLibrary.Core.Classes
{
    public class FileSystemSimulator
    {
        private readonly FileDescriptorManager fileDescriptorManager = new();

        public int Open(string path)
        {
            // Simulate file opening by assigning a unique file descriptor ID
            return GenerateFileDescriptorId(path);
        }

        public void Read(int fileDescriptor, byte[] buffer, long offset)
        {
            var fd = fileDescriptorManager.GetFileDescriptor(fileDescriptor);
            fd.Read(buffer, offset);
        }

        public void Write(int fileDescriptor, byte[] data)
        {
            var fd = fileDescriptorManager.GetFileDescriptor(fileDescriptor);
            fd.Write(data);
        }

        public void Close(int fileDescriptor)
        {
            var fd = fileDescriptorManager.GetFileDescriptor(fileDescriptor);
            fd.Close();
        }

        private int GenerateFileDescriptorId(string path) => path.GetHashCode(); // Simple hash-based ID generation

        public void Lseek(int fileDescriptor, long offset, SeekOrigin origin)
        {
            // Simulate lseek operation
        }
    }
}