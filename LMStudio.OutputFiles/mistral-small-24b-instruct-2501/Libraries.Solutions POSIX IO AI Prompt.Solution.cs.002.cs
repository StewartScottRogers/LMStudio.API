namespace PosixIoLibrary
{
    public class SystemCallHandler
    {
        private readonly IFileDescriptor fileDescriptor;

        public SystemCallHandler(IFileDescriptor fileDescriptor)
        {
            this.fileDescriptor = fileDescriptor;
        }

        public var OpenTuple(string fileName) => new { Fd = fileDescriptor.Open(fileName), FileName = fileName };
        public var ReadTuple(int fd, out byte[] data) => (fileDescriptor.Read(fd, out data));
        public int Write(int fd, byte[] data) => fileDescriptor.Write(fd, data);
        public void Close(int fd) => fileDescriptor.Close(fd);
    }
}