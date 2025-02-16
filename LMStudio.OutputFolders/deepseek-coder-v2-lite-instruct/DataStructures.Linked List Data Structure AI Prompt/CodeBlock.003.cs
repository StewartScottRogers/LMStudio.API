using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListApp.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestInsertAtBeginning()
        {
            var list = new LinkedList<int>();
            list.InsertAtBeginning(1);
            Assert.IsTrue(list.Search(1));
        }

        [TestMethod]
        public void TestDeleteElement()
        {
            var list = new LinkedList<int>();
            list.InsertAtBeginning(1);
            list.Delete(1);
            Assert.IsFalse(list.Search(1));
        }

        [TestMethod]
        public void TestSearchExistingElement()
        {
            var list = new LinkedList<int>();
            list.InsertAtBeginning(1);
            Assert.IsTrue(list.Search(1));
        }

        [TestMethod]
        public void TestSearchNonExistingElement()
        {
            var list = new LinkedList<int>();
            list.InsertAtBeginning(1);
            Assert.IsFalse(list.Search(2));
        }
    }
}