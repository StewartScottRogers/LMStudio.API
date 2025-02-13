using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

namespace InMemoryPosixIoLibrary.Core.Classes
{
    public class FileDescriptorManager : IDisposable
    {
        private readonly ConcurrentDictionary<int, FileDescriptorRecord> fileDescriptors = new();
        public static readonly int StandardInputFileDescriptor = 0;
        public static readonly int StandardOutputFileDescriptor = 1;
        public static readonly int StandardErrorFileDescriptor = 2;

        public void Open(int fileDescriptorId)
        {
            if (!fileDescriptors.ContainsKey(fileDescriptorId))
            {
                fileDescriptors[fileDescriptorId] = new FileDescriptorRecord(fileDescriptorId, new List<byte>());
            }
        }

        public IFileDescriptor GetFileDescriptor(int fileDescriptorId) => new InMemoryFileDescriptor(this, fileDescriptorId);

        public void Dispose()
        {
            foreach (var fd in fileDescriptors.Values)
            {
                // Close each file descriptor
                fd.Data.Clear();
            }
        }

        private class InMemoryFileDescriptor : IFileDescriptor
        {
            private readonly FileDescriptorManager manager;
            private readonly int fileDescriptorId;

            public InMemoryFileDescriptor(FileDescriptorManager manager, int fileDescriptorId)
            {
                this.manager = manager ?? throw new ArgumentNullException(nameof(manager));
                this.fileDescriptorId = fileDescriptorId;
            }

            public int Read(byte[] buffer, long offset)
            {
                var fdRecord = manager.fileDescriptors[fileDescriptorId];
                if (fdRecord.Data.Count == 0) return 0; // EOF

                var bytesToRead = Math.Min(buffer.Length - (int)offset, fdRecord.Data.Count);
                Array.Copy(fdRecord.Data.ToArray(), 0, buffer, (int)offset, bytesToRead);

                return bytesToRead;
            }

            public void Write(byte[] data)
            {
                var fdRecord = manager.fileDescriptors[fileDescriptorId];
                fdRecord.Data.AddRange(data);
            }

            public void Close()
            {
                // Implement close logic if needed
            }

            public void Dispose() => Close();
        }
    }
}