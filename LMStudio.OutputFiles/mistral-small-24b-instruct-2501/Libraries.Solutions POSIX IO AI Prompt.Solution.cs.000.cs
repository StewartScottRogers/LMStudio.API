using System;
using System.Collections.Generic;

public interface IFileDescriptor : IDisposable
{
    int Read(byte[] buffer, int offset, int count);
    int Write(byte[] buffer, int offset, int count);
    void Close();
}

public class FileDescriptor : IFileDescriptor
{
    private readonly byte[] fileData;
    private readonly object lockObject = new();

    public FileDescriptor(int size)
    {
        fileData = new byte[size];
    }

    public int Read(byte[] buffer, int offset, int count)
    {
        lock (lockObject)
        {
            if (offset + count > fileData.Length)
                throw new ArgumentOutOfRangeException(nameof(count), "Count exceeds buffer length.");

            Buffer.BlockCopy(fileData, 0, buffer, offset, count);
            return count;
        }
    }

    public int Write(byte[] buffer, int offset, int count)
    {
        lock (lockObject)
        {
            if (offset + count > fileData.Length)
                throw new ArgumentOutOfRangeException(nameof(count), "Count exceeds buffer length.");

            Buffer.BlockCopy(buffer, 0, fileData, 0, count);
            return count;
        }
    }

    public void Close()
    {
        // Implementation for closing the file descriptor
    }

    public void Dispose()
    {
        Close();
    }
}