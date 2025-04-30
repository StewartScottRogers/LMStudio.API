// LinkedListTest.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListDataStructure;

namespace LinkedListDataStructure
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void InsertAtBeginning_ValidData_InsertsNode()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            Assert.AreEqual(10, linkedList.headNode.Data);
        }

        [TestMethod]
        public void DeleteElement_FirstElement_DeletesCorrectly()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            linkedList.DeleteElement(10);
            Assert.IsNull(linkedList.headNode);
        }

        [TestMethod]
        public void SearchElement_ExistingElement_ReturnsTrue()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            bool result = linkedList.SearchElement(10);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchElement_NonExistingElement_ReturnsFalse()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            bool result = linkedList.SearchElement(20);
            Assert.IsFalse(result);
        }
    }
}