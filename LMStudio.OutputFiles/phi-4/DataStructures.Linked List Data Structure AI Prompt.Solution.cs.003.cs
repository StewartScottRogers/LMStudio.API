using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListDataStructure.Tests
{
    [TestClass]
    public class LinkedListTests<T>
    {
        private readonly ILinkedList<T> linkedList = new LinkedList<T>();

        [TestMethod]
        public void InsertAtBeginning_ShouldInsertValue()
        {
            linkedList.InsertAtBeginning(1);
            Assert.IsTrue(linkedList.Search(1));
        }

        [TestMethod]
        public void Search_ShouldReturnTrueForExistingValue()
        {
            linkedList.InsertAtBeginning(2);
            bool result = linkedList.Search(2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete_ShouldRemoveFirstOccurrence()
        {
            linkedList.InsertAtBeginning(3);
            linkedList.Delete(3);
            Assert.IsFalse(linkedList.Search(3));
        }

        // Additional tests for boundary conditions
    }
}