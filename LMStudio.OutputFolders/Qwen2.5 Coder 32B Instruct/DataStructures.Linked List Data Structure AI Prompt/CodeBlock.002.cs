using LinkedListLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        private readonly LinkedList linkedList = new LinkedList();

        [TestInitialize]
        public void Setup()
        {
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);
        }

        [TestMethod]
        public void TestInsertAtBeginning()
        {
            linkedList.InsertAtBeginning(40);
            Assert.IsTrue(linkedList.DisplayList() == "40 -> 30 -> 20 -> 10");
        }

        [TestMethod]
        public void TestDeleteElementSuccess()
        {
            var result = linkedList.DeleteElement(20);
            Assert.IsTrue(result && linkedList.DisplayList() == "30 -> 10");
        }

        [TestMethod]
        public void TestDeleteElementFailure()
        {
            var result = linkedList.DeleteElement(50);
            Assert.IsFalse(result && linkedList.DisplayList() == "30 -> 20 -> 10");
        }

        [TestMethod]
        public void TestSearchElementSuccess()
        {
            var searchTuple = linkedList.SearchElement(20);
            Assert.IsTrue(searchTuple.Success && searchTuple.Message == "Element found.");
        }

        [TestMethod]
        public void TestSearchElementFailure()
        {
            var searchTuple = linkedList.SearchElement(50);
            Assert.IsFalse(searchTuple.Success && searchTuple.Message == "Element not found.");
        }
    }
}