// FileSystemTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

[TestClass]
public class FileSystemTests
{
    private readonly IFileSystem fileSystem = new FileSystem();

    [TestInitialize]
    public void Initialize()
    {
        var testFileContent = "Hello, World!";
        File.WriteAllText("testfile.txt", testFileContent);
    }

    [TestCleanup]
    public void Cleanup()
    {
        if (File.Exists("testfile.txt"))
            File.Delete("testfile.txt");
    }

    [TestMethod]
    public void Open_TestReadMode_FileDescriptorReturned()
    {
        int fd = fileSystem.Open("testfile.txt", FileModeEnum.ReadOnly);
        Assert.IsTrue(fd >= 3, "File descriptor should be valid and >= 3");
    }

    [TestMethod]
    public void Close_ValidFileDescriptor_Successful()
    {
        int fd = fileSystem.Open("testfile.txt", FileModeEnum.ReadOnly);
        int result = fileSystem.Close(fd);
        Assert.AreEqual(1, result, "Close method should return success indicator (1)");
    }

    [TestMethod]
    public void Read_ValidFileDescriptorAndBuffer_ReturnsCorrectData()
    {
        int fd = fileSystem.Open("testfile.txt", FileModeEnum.ReadOnly);
        byte[] buffer = new byte[5];
        int bytesRead = fileSystem.Read(fd, buffer, 5);

        string resultString = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Assert.AreEqual("Hello", resultString, "Read method should return correct data");
    }

    [TestMethod]
    public void Write_ValidFileDescriptorAndBuffer_WritesCorrectData()
    {
        int fd = fileSystem.Open("testfile.txt", FileModeEnum.WriteOnly);
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Goodbye!");
        int bytesWritten = fileSystem.Write(fd, buffer, buffer.Length);

        Assert.AreEqual(buffer.Length, bytesWritten, "Write method should write all provided data");
    }

    // Additional tests for Seek, error handling, boundary conditions, etc.
}