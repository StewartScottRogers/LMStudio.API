using System;
using System.Collections.Generic;
using System.IO;

namespace PosixIoSimulation
{
    public class InMemoryFileSystem
    {
        private readonly Dictionary<int, MemoryStream> _fileDescriptors = new();
        private int _nextFileDescriptor = 3; // Starting from 3 as 0, 1, 2 are reserved

        public int? OpenFile(string fileName, FileMode fileMode)
        {
            var memoryStream = new MemoryStream();
            if (fileMode == FileMode.Create || fileMode == FileMode.Append)
            {
                _fileDescriptors[_nextFileDescriptor] = memoryStream;
                return _nextFileDescriptor++;
            }

            throw new InvalidOperationException("Unsupported file mode for in-memory files.");
        }

        public void WriteToFile(int fileDescriptor, string content)
        {
            if (_fileDescriptors.TryGetValue(fileDescriptor, out var stream))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(content);
                stream.Write(data, 0, data.Length);
            }
            else
            {
                throw new InvalidOperationException("Invalid file descriptor.");
            }
        }

        public string ReadFile(int fileDescriptor)
        {
            if (_fileDescriptors.TryGetValue(fileDescriptor, out var stream))
            {
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

            throw new InvalidOperationException("Invalid file descriptor.");
        }

        public void CloseFile(int fileDescriptor)
        {
            _fileDescriptors.Remove(fileDescriptor);
        }
    }
}