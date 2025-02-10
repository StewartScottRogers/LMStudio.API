using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PosixIoLibrary.Tests
{
    [TestClass]
    public class FileDescriptorTests
    {
        private readonly IFileDescriptor fileDescriptor = new FileDescriptor();

        [TestMethod]
        public void Open_ShouldReturnValidFd()
        {
            var fd = fileDescriptor.Open("test.txt");
            Assert.IsTrue(fd >= 3);
        }

        [TestMethod]
        public void Read_ShouldReadData()
        {
            var fd = fileDescriptor.Open("test.txt");
            var data = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
            fileDescriptor.Write(fd, data);
            fileDescriptor.Read(fd, out var readData);
            CollectionAssert.AreEqual(data, readData);
        }

        [TestMethod]
        public void Write_ShouldWriteData()
        {
            var fd = fileDescriptor.Open("test.txt");
            var data = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
            fileDescriptor.Write(fd, data);
            fileDescriptor.Read(fd, out var readData);
            CollectionAssert.AreEqual(data, readData);
        }

        [TestMethod]
        public void Close_ShouldRemoveFileDescriptor()
        {
            var fd = fileDescriptor.Open("test.txt");
            fileDescriptor.Close(fd);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fileDescriptor.Read(fd, out _));
        }
    }
}