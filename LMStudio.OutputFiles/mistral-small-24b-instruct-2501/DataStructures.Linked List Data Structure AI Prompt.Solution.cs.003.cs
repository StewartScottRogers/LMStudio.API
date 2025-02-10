using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList.DataStructures;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private readonly LinkedList<int> linkedList = new LinkedList<int>();

        [TestInitialize]
        public void Setup()
        {
            this.linkedList.InsertAtBeginning(3);
            this.linkedList.InsertAtBeginning(2);
            this.linkedList.InsertAtBeginning(1);
        }

        // Tests for InsertAtBeginning method
        [TestMethod]
        public void TestInsertAtBeginning()
        {
            this.linkedList.InsertAtBeginning(0);
            var elements = this.linkedList.GetAllElements().ToList();
            Assert.AreEqual(4, elements.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3 }, elements);
        }

        // Tests for Delete method
        [TestMethod]
        public void TestDelete()
        {
            bool result = this.linkedList.Delete(2);
            Assert.IsTrue(result);

            var elements = this.linkedList.GetAllElements().ToList();
            CollectionAssert.AreEqual(new[] { 1, 3 }, elements);
        }

        // Tests for Search method
        [TestMethod]
        public void TestSearch()
        {
            bool result = this.linkedList.Search(2);
            Assert.IsTrue(result);

            result = this.linkedList.Search(4);
            Assert.IsFalse(result);
        }

        // Tests for GetAllElements method
        [TestMethod]
        public void TestGetAllElements()
        {
            var elements = this.linkedList.GetAllElements().ToList();
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, elements);
        }
    }
}