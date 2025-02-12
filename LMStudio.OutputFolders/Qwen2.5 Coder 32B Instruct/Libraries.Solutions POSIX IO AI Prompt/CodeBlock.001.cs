// IFileSystem.cs
public interface IFileSystem
{
    int Open(string path, FileModeEnum mode);
    int Close(int fileDescriptor);
    int Read(int fileDescriptor, byte[] buffer, int count);
    int Write(int fileDescriptor, byte[] buffer, int count);
    long Seek(int fileDescriptor, long offset, SeekOrigin origin);
}