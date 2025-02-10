using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InMemoryIO.Tests
{
    [TestClass]
    public class OpenFileDescriptorTest
    {
        private IOController _ioController = new IOController();

        [TestMethod]
        public void TestReadFromOpenedFile()
        {
            // Setup
            var file = _ioController.OpenFileDescriptor("r");
            
            // Exercise
            byte[] buffer = new byte[1024];
            int bytesRead = file.Read(buffer);
            
            // Assert
            Assert.AreEqual(1024, bytesRead);
            CollectionAssert.AreEqual(new byte[0], buffer); // Initial buffer is empty
        }
    }
}