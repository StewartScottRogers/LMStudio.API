using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PosixIoSimulation.Tests
{
    [TestClass]
    public class InMemoryFileSystemTests
    {
        private readonly InMemoryFileSystem _fileSystem = new();

        [TestMethod]
        public void TestOpenAndWriteFile()
        {
            var fileDescriptor = _fileSystem.OpenFile("test.txt", FileMode.Create);
            Assert.IsNotNull(fileDescriptor);

            _fileSystem.WriteToFile((int)fileDescriptor, "Test content");
            
            var content = _fileSystem.ReadFile((int)fileDescriptor);
            Assert.AreEqual("Test content", content);

            _fileSystem.CloseFile((int)fileDescriptor);
        }

        [TestMethod]
        public void TestInvalidFileDescriptor()
        {
            int invalidDescriptor = 999;
            Assert.ThrowsException<InvalidOperationException>(() => 
                _fileSystem.WriteToFile(invalidDescriptor, "Should fail"));
        }
    }
}