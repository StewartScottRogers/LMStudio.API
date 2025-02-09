[TestClass]
public class FileSystemManagerTests
{
    private readonly IFileSystemManager fileSystemManager;

    public FileSystemManagerTests()
    {
        fileSystemManager = new FileSystemManager();
    }

    [TestMethod]
    public void Open_ShouldCreateNewFileDescriptor()
    {
        var fdId = fileSystemManager.Open("testfile.txt", OpenFlags.ReadWrite);
        Assert.IsTrue(fdId >= 3); // First three are standard streams
    }

    [TestMethod]
    public void WriteAndRead_ShouldPersistData()
    {
        var fdId = fileSystemManager.Open("testfile.txt", OpenFlags.ReadWrite);
        byte[] writeData = { 1, 2, 3, 4 };
        fileSystemManager.Write(fdId, writeData, 0, writeData.Length);

        byte[] readBuffer = new byte[writeData.Length];
        var bytesRead = fileSystemManager.Read(fdId, readBuffer, 0, readBuffer.Length);
        Assert.AreEqual(writeData.Length, bytesRead);
        CollectionAssert.AreEqual(writeData, readBuffer);
    }

    [TestMethod]
    public void Seek_ShouldChangeCurrentPosition()
    {
        var fdId = fileSystemManager.Open("testfile.txt", OpenFlags.ReadWrite);
        byte[] writeData = { 1, 2, 3, 4 };
        fileSystemManager.Write(fdId, writeData, 0, writeData.Length);

        fileSystemManager.Seek(fdId, 1, SeekOrigin.Begin);
        byte[] readBuffer = new byte[2];
        var bytesRead = fileSystemManager.Read(fdId, readBuffer, 0, readBuffer.Length);
        Assert.AreEqual(2, bytesRead);
        CollectionAssert.AreEqual(new byte[] { 2, 3 }, readBuffer);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Close_InvalidFileDescriptor_ShouldThrow()
    {
        fileSystemManager.Close(-1);
    }

    // Add more tests for edge cases
}