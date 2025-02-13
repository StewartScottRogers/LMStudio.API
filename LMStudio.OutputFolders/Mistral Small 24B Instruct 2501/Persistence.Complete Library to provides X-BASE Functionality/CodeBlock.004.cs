using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace XBaseLibrary.ModelsTest
{
    [TestClass]
    public class XBaseRecordTests
    {
        [TestMethod]
        public void TestCreateXBaseRecord()
        {
            var fields = new Dictionary<string, object>
            {
                { "Name", "John Doe" },
                { "Age", 30 }
            };
            var record = new XBaseRecord(1, fields);

            Assert.AreEqual(1, record.GetRecordId());
            Assert.AreEqual("John Doe", fields["Name"]);
        }

        // More test methods for other operations.
    }
}