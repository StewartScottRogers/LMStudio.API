using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class XBaseTableTests
{
    private XBaseTable table;

    [TestInitialize]
    public void Setup()
    {
        table = new XBaseTable("TestTable");
        var field1 = new XBaseField("Name", typeof(string));
        var field2 = new XBaseField("Age", typeof(int));

        table.AddField(field1);
        table.AddField(field2);

        table.AddRecord(new XBaseRecord(new List<object> { "Alice", 30 }));
        table.AddRecord(new XBaseRecord(new List<object> { "Bob", 25 }));
    }

    [TestMethod]
    public void TestAddField()
    {
        Assert.AreEqual(2, table.Fields.Count);
    }

    [TestMethod]
    public void TestAddRecord()
    {
        Assert.AreEqual(2, table.Records.Count);
    }

    [TestMethod]
    public void TestQueryRecords()
    {
        var result = table.QueryRecords("Age > 25");
        Assert.AreEqual(1, result.Count());
    }
}