using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListSolution;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new LinkedList<int>();
        }

        [TestMethod]
        public void InsertAtBeginning_AddsElementAtHead()
        {
            list.InsertAtBeginning(1);
            Assert.AreEqual(true, list.Search(1));
        }

        [TestMethod]
        public void Search_ReturnsTrueIfFound()
        {
            list.InsertAtBeginning(1);
            Assert.IsTrue(list.Search(1));
        }

        [TestMethod]
        public void Search_ReturnsFalseIfNotFound()
        {
            Assert.IsFalse(list.Search(1));
        }

        [TestMethod]
        public void Delete_RemovesElementIfExists()
        {
            list.InsertAtBeginning(1);
            Assert.IsTrue(list.Delete(1));
            Assert.IsFalse(list.Search(1));
        }

        [TestMethod]
        public void Delete_ReturnsFalseIfNotFound()
        {
            Assert.IsFalse(list.Delete(1));
        }
    }
}