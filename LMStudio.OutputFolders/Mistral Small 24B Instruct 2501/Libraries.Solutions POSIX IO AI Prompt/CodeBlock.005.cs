using Microsoft.VisualStudio.TestTools.UnitTesting;
using InMemoryPosixIoLibrary.Core.Classes;
using System;

namespace InMemoryPosixIoLibrary.Tests
{
    [TestClass]
    public class FileSystemSimulatorTests
    {
        private readonly FileSystemSimulator fileSystem = new();

        [TestMethod]
        public void TestOpenAndClose()
        {
            int fd = fileSystem.Open("testfile");
            Assert.AreNotEqual(-1, fd);

            fileSystem.Close(fd);
        }

        [TestMethod]
        public void TestReadWrite()
        {
            byte[] dataToWrite = { 65, 66, 67 }; // "ABC"
            byte[] buffer = new byte[10];

            int fd = fileSystem.Open("testfile");
            fileSystem.Write(fd, dataToWrite);

            fileSystem.Read(fd, buffer, 0);
            CollectionAssert.AreEqual(dataToWrite, buffer.Take(3).ToArray());

            fileSystem.Close(fd);
        }
    }
}