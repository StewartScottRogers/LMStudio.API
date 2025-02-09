using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class XBaseTableTests
{
    private XBaseTable _table;
    
    [TestInitialize]
    public void SetUp()
    {
        _table = new XBaseTable();
    }

    [TestMethod]
    public void TestCreateReadRecord()
    {
        var id1 = Guid.NewGuid();
        _table.CreateRecord(new XBaseRecord("Field1", "Field2", 123));
        
        var record = _table.ReadRecord(id1);
        Assert.IsNotNull(record);
        Assert.AreEqual("Field1", record.Field1);
    }

    [TestMethod]
    public void TestUpdateDeleteRecord()
    {
        var id2 = Guid.NewGuid();
        var initialRecord = new XBaseRecord("Initial", "Data", 456);
        _table.CreateRecord(initialRecord);

        var updatedRecord = new XBaseRecord("Updated", "Data", 789);
        _table.UpdateRecord(id2, updatedRecord);
        
        var recordAfterUpdate = _table.ReadRecord(id2);
        Assert.AreEqual("Updated", recordAfterUpdate.Field1);

        _table.DeleteRecord(id2);
        var deletedRecord = _table.ReadRecord(id2);
        Assert.IsNull(deletedRecord);
    }
}