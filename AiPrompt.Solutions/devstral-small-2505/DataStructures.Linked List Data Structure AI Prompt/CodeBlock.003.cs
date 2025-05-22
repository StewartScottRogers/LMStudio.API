using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLinkedList.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private readonly LinkedList linkedList = new LinkedList();

        [TestMethod]
        public void TestInsertAtBeginning()
        {
            linkedList.InsertAtBeginning(10);
            Assert.IsTrue(linkedList.Search(10));
        }

        [TestMethod]
        public void TestDelete()
        {
            linkedList.InsertAtBeginning(20);
            linkedList.Delete(20);
            Assert.IsFalse(linkedList.Search(20));
        }

        [TestMethod]
        public void TestSearch()
        {
            linkedList.InsertAtBeginning(30);
            Assert.IsTrue(linkedList.Search(30));
            Assert.IsFalse(linkedList.Search(40));
        }
    }
}