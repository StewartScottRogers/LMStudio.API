using System.Collections.Generic;

namespace InMemoryPosixIoLibrary.Core.Records
{
    public record FileDescriptorRecord(int Id, List<byte> Data);
}