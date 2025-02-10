namespace PosixIoLibrary
{
    public interface IFileDescriptor
    {
        int Open(string fileName);
        int Read(int fd, out byte[] data);
        int Write(int fd, byte[] data);
        void Close(int fd);
        int Lseek(int fd, long offset);
    }
}