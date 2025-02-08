using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class InMemoryFileSystemTests
{
    private readonly IFileSystem fileSystem;

    public InMemoryFileSystemTests()
    {
        fileSystem = new InMemoryFileSystem();
    }

    [TestMethod]
    public void Test_OpenFile()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        Assert.IsTrue(fd >= 3, "File descriptor should be greater than or equal to 3.");
    }

    [TestMethod]
    public void Test_WriteToFile()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        byte[] dataToWrite = System.Text.Encoding.UTF8.GetBytes("Hello, World!");
        int bytesWritten = fileSystem.Write(fd, dataToWrite, dataToWrite.Length);

        Assert.AreEqual(dataToWrite.Length, bytesWritten, "Bytes written should match the length of the input.");
    }

    [TestMethod]
    public void Test_ReadFromFile()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        byte[] dataToWrite = System.Text.Encoding.UTF8.GetBytes("Hello, World!");
        int bytesWritten = fileSystem.Write(fd, dataToWrite, dataToWrite.Length);

        fileSystem.Seek(fd, 0, SeekWhenceEnum.Begin);
        byte[] readBuffer = new byte[dataToWrite.Length];
        int bytesRead = fileSystem.Read(fd, readBuffer, dataToWrite.Length);

        Assert.AreEqual(dataToWrite.Length, bytesRead, "Bytes read should match the length of the input.");
        Assert.IsTrue(readBuffer.SequenceEqual(dataToWrite), "Read buffer content should match written data.");
    }

    [TestMethod]
    public void Test_SeekInFile()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        byte[] dataToWrite = System.Text.Encoding.UTF8.GetBytes("Hello, World!");
        int bytesWritten = fileSystem.Write(fd, dataToWrite, dataToWrite.Length);

        fileSystem.Seek(fd, 7, SeekWhenceEnum.Begin);
        Assert.AreEqual(7, fileSystem.Read(fd, new byte[1], 1));

        fileSystem.Seek(fd, -5, SeekWhenceEnum.Current);
        Assert.AreEqual(2, fileSystem.Read(fd, new byte[2], 2));
    }

    [TestMethod]
    public void Test_CloseFile()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        fileSystem.Close(fd);

        try
        {
            fileSystem.Read(fd, new byte[1], 1);
            Assert.Fail();
        }
        catch (InvalidOperationException ex)
        {
            Assert.IsNotNull(ex, "Exception should be thrown when accessing a closed file.");
        }
    }

    [TestMethod]
    public void Test_ReadPastEndOfFile()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        byte[] dataToWrite = System.Text.Encoding.UTF8.GetBytes("Hello");
        int bytesWritten = fileSystem.Write(fd, dataToWrite, dataToWrite.Length);

        fileSystem.Seek(fd, 0, SeekWhenceEnum.Begin);
        byte[] readBuffer = new byte[dataToWrite.Length + 10];
        int bytesRead = fileSystem.Read(fd, readBuffer, readBuffer.Length);

        Assert.AreEqual(dataToWrite.Length, bytesRead, "Bytes read should match the length of the input.");
    }

    [TestMethod]
    public void Test_WriteReadWithSeek()
    {
        var fd = fileSystem.Open("test.txt", FileModeEnum.Write);
        byte[] dataToWrite1 = System.Text.Encoding.UTF8.GetBytes("Hello");
        byte[] dataToWrite2 = System.Text.Encoding.UTF8.GetBytes(", World!");

        int bytesWritten1 = fileSystem.Write(fd, dataToWrite1, dataToWrite1.Length);
        fileSystem.Seek(fd, 5, SeekWhenceEnum.Begin);
        int bytesWritten2 = fileSystem.Write(fd, dataToWrite2, dataToWrite2.Length);

        fileSystem.Seek(fd, 0, SeekWhenceEnum.Begin);
        byte[] readBuffer = new byte[dataToWrite1.Length + dataToWrite2.Length];
        int bytesRead = fileSystem.Read(fd, readBuffer, readBuffer.Length);

        Assert.AreEqual(dataToWrite1.Length + dataToWrite2.Length, bytesRead, "Bytes read should match the length of the input.");
        var resultString = System.Text.Encoding.UTF8.GetString(readBuffer);
        Assert.AreEqual("Hello, World!", resultString, "Read buffer content should match written data.");
    }

    [TestMethod]
    public void Test_ReadWithInvalidDescriptor()
    {
        try
        {
            fileSystem.Read(99, new byte[1], 1);
            Assert.Fail();
        }
        catch (InvalidOperationException ex)
        {
            Assert.IsNotNull(ex, "Exception should be thrown when accessing a non-existent file descriptor.");
        }
    }

    [TestMethod]
    public void Test_WriteWithInvalidDescriptor()
    {
        try
        {
            fileSystem.Write(99, new byte[1], 1);
            Assert.Fail();
        }
        catch (InvalidOperationException ex)
        {
            Assert.IsNotNull(ex, "Exception should be thrown when accessing a non-existent file descriptor.");
        }
    }

    [TestMethod]
    public void Test_SeekWithInvalidDescriptor()
    {
        try
        {
            fileSystem.Seek(99, 0, SeekWhenceEnum.Begin);
            Assert.Fail();
        }
        catch (InvalidOperationException ex)
        {
            Assert.IsNotNull(ex, "Exception should be thrown when accessing a non-existent file descriptor.");
        }
    }

    [TestMethod]
    public void Test_CloseWithInvalidDescriptor()
    {
        try
        {
            fileSystem.Close(99);
            Assert.Fail();
        }
        catch (InvalidOperationException ex)
        {
            Assert.IsNotNull(ex, "Exception should be thrown when closing a non-existent file descriptor.");
        }
    }
}