using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PosixIoSimulator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOpen()
        {
            // Arrange
            var fileSystem = new FileSystem();

            // Act
            var fd = SystemCalls.Open("testfile");

            // Assert
            Assert.IsTrue(fd > -1, "File descriptor should be valid.");
        }

        [TestMethod]
        public void TestReadWrite()
        {
            // Arrange
            var fileDescriptor = new FileDescriptor(1024);
            byte[] buffer = new byte[10];
            buffer = Encoding.UTF8.GetBytes("Hello World");

            // Act
            SystemCalls.Write(fileDescriptor, buffer, 0, buffer.Length);

            var readTuple = SystemCalls.ReadTuple(fileDescriptor, buffer, 0, buffer.Length);

            // Assert
            Assert.AreEqual(buffer.Length, readTuple.BytesRead);
        }
    }
}