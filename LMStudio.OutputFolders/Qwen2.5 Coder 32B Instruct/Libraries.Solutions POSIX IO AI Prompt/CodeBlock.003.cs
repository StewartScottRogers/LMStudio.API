// FileSystem.cs
using System.Collections.Generic;
using System.IO;

public class FileSystem : IFileSystem
{
    private readonly Dictionary<int, FileDescriptorRecord> fileDescriptors = new();
    private int nextFileDescriptor = 3; // Starting from 3, as 0, 1, 2 are reserved

    public int Open(string path, FileModeEnum mode)
    {
        byte[] dataBuffer = mode == FileModeEnum.ReadOnly ? File.ReadAllBytes(path) : new byte[0];
        var fileDescriptorRecord = new FileDescriptorRecord(nextFileDescriptor++, path, mode, dataBuffer, 0);
        fileDescriptors.Add(fileDescriptorRecord.FileDescriptor, fileDescriptorRecord);
        return fileDescriptorRecord.FileDescriptor;
    }

    public int Close(int fileDescriptor)
    {
        if (!fileDescriptors.ContainsKey(fileDescriptor))
            throw new ArgumentException("Invalid file descriptor");

        fileDescriptors.Remove(fileDescriptor);
        return 1; // Simulate success
    }

    public int Read(int fileDescriptor, byte[] buffer, int count)
    {
        if (!fileDescriptors.TryGetValue(fileDescriptor, out var record) || record.Mode == FileModeEnum.WriteOnly)
            throw new ArgumentException("Invalid file descriptor or mode");

        int bytesRead = Math.Min(count, (int)(record.DataBuffer.Length - record.CurrentPosition));
        Buffer.BlockCopy(record.DataBuffer, (int)record.CurrentPosition, buffer, 0, bytesRead);
        var updatedRecord = record with { CurrentPosition = record.CurrentPosition + bytesRead };
        fileDescriptors[fileDescriptor] = updatedRecord;
        return bytesRead;
    }

    public int Write(int fileDescriptor, byte[] buffer, int count)
    {
        if (!fileDescriptors.TryGetValue(fileDescriptor, out var record) || record.Mode == FileModeEnum.ReadOnly)
            throw new ArgumentException("Invalid file descriptor or mode");

        if (record.CurrentPosition + count > record.DataBuffer.Length)
        {
            Array.Resize(ref record.DataBuffer, (int)(record.CurrentPosition + count));
        }

        Buffer.BlockCopy(buffer, 0, record.DataBuffer, (int)record.CurrentPosition, count);
        var updatedRecord = record with { CurrentPosition = record.CurrentPosition + count };
        fileDescriptors[fileDescriptor] = updatedRecord;
        return count;
    }

    public long Seek(int fileDescriptor, long offset, SeekOrigin origin)
    {
        if (!fileDescriptors.TryGetValue(fileDescriptor, out var record))
            throw new ArgumentException("Invalid file descriptor");

        long newPosition;

        switch (origin)
        {
            case SeekOrigin.Begin:
                newPosition = offset;
                break;
            case SeekOrigin.Current:
                newPosition = record.CurrentPosition + offset;
                break;
            case SeekOrigin.End:
                newPosition = record.DataBuffer.Length - offset;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(origin));
        }

        if (newPosition < 0 || newPosition > record.DataBuffer.Length)
            throw new IOException("Invalid seek position");

        var updatedRecord = record with { CurrentPosition = newPosition };
        fileDescriptors[fileDescriptor] = updatedRecord;
        return newPosition;
    }
}