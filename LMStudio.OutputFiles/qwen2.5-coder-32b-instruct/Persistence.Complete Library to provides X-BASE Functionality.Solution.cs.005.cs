using Microsoft.VisualStudio.TestTools.UnitTesting;
using XBaseLibrary.Classes;
using XBaseLibrary.Records;

namespace XBaseLibrary.Tests
{
    [TestClass]
    public class XBaseDatabaseTests
    {
        private IXBaseDatabase database;

        [TestInitialize]
        public void Initialize()
        {
            database = new XBaseDatabase();
        }

        [TestMethod]
        public void CreateTable_ShouldReturnTrue_WhenTableDoesNotExist()
        {
            var result = database.CreateTable("NewTable");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteTable_ShouldReturnTrue_WhenTableExists()
        {
            database.CreateTable("NewTable");
            var result = database.DeleteTable("NewTable");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InsertRecord_ShouldReturnTrue_WhenValidRecordAndTable()
        {
            database.CreateTable("NewTable");
            var record = new XBaseRecord { RecordId = "1", Fields = new Dictionary<string, object> { { "Name", "Test" } } };
            var result = database.Insert(record, "NewTable");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateRecord_ShouldReturnTrue_WhenValidRecordAndTable()
        {
            database.CreateTable("NewTable");
            var record = new XBaseRecord { RecordId = "1", Fields = new Dictionary<string, object> { { "Name", "Test" } } };
            database.Insert(record, "NewTable");

            record.Fields["Name"] = "Updated Test";
            var result = database.Update(record, "NewTable");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteRecord_ShouldReturnTrue_WhenValidRecordAndTable()
        {
            database.CreateTable("NewTable");
            var record = new XBaseRecord { RecordId = "1", Fields = new Dictionary<string, object> { { "Name", "Test" } } };
            database.Insert(record, "NewTable");

            var result = database.Delete(record, "NewTable");
            Assert.IsTrue(result);
        }
    }
}