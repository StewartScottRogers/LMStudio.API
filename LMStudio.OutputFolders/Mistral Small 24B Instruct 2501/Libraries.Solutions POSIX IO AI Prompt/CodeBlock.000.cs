using System;

namespace InMemoryPosixIoLibrary.Core.Interfaces
{
    public interface IFileDescriptor : IDisposable
    {
        int Read(byte[] buffer, long offset);
        void Write(byte[] data);
        void Close();
    }
}