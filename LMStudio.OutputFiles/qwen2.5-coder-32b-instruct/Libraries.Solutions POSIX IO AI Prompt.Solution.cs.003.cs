public interface IFileSystem
{
    int Open(string name, FileModeEnum mode);
    int Read(int fileDescriptor, byte[] buffer, int count);
    int Write(int fileDescriptor, byte[] buffer, int count);
    void Close(int fileDescriptor);
    void Seek(int fileDescriptor, long offset, SeekWhenceEnum whence);
}