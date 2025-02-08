[TestClass]
public class XBaseCoreTests
{
    [TestMethod]
    public void TestXBaseFileManager_ReadRecord()
    {
        // Arrange
        var fileManager = new XBaseFileManager(/* setup */);

        // Act
        var record = fileManager.ReadRecord(1);

        // Assert
        Assert.IsNotNull(record);
    }
}