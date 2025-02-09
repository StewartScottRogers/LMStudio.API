[TestClass]
public class FileDescriptorTests
{
    [TestMethod]
    public void OpenReadWriteCloseTest()
    {
        // Arrange
        var fd = Open("someFile", FileAccess.ReadWrite);
        
        // Act
        byte[] readData = Read(fd, new byte[10], 0, 10); // Simulating a read operation
        Write(fd, new byte[] {1, 2, 3}); // Writing some data

        // Assert
        // Add assertions here...
    }
}