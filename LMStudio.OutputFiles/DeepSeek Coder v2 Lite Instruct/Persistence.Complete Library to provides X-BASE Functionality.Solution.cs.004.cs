[TestClass]
public class DatabaseServiceTests
{
    [TestMethod]
    public void CreateTable_AddsNewTableToList()
    {
        var dbService = new DatabaseService();
        dbService.CreateTable("Customers");
        Assert.AreEqual(1, dbService._tables.Count);
    }
}