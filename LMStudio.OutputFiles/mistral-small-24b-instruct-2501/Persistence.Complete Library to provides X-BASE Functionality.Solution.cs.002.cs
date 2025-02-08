using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace XBaseLibrary.Tests
{
    [TestClass]
    public class XBaseRecordTests
    {
        private const string TestFilePath = "test_xbase_records.dat";

        [TestInitialize]
        public void Setup()
        {
            // Ensure the test file is empty before each test
            if (System.IO.File.Exists(TestFilePath))
            {
                System.IO.File.Delete(TestFilePath);
            }
            XBaseRecord.FilePath = TestFilePath;
        }

        [TestMethod]
        public void WriteToFile_Test()
        {
            var record = new XBaseRecord("1", "Value1", "Value2");
            record.WriteToFile();

            var records = XBaseRecord.ReadAllRecords();
            Assert.AreEqual(1, records.Length);
            Assert.AreEqual("1", records[0].RecordId);
            Assert.AreEqual("Value1", records[0].Field1);
            Assert.AreEqual("Value2", records[0].Field2);
        }

        [TestMethod]
        public void ReadAllRecords_Test()
        {
            var record1 = new XBaseRecord("1", "Value1", "Value2");
            var record2 = new XBaseRecord("2", "Value3", "Value4");

            record1.WriteToFile();
            record2.WriteToFile();

            var records = XBaseRecord.ReadAllRecords();
            Assert.AreEqual(2, records.Length);
            Assert.IsTrue(records.Any(r => r.RecordId == "1" && r.Field1 == "Value1" && r.Field2 == "Value2"));
            Assert.IsTrue(records.Any(r => r.RecordId == "2" && r.Field1 == "Value3" && r.Field2 == "Value4"));
        }
    }
}