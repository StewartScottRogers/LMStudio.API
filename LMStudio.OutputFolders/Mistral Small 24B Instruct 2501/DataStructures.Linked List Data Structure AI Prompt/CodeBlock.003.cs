using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinkedListProject.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private readonly LinkedList linkedList = new();

        // Test to insert elements and check the list.
        [TestMethod]
        public void TestInsertAtBeginning()
        {
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);

            var expectedValues = new List<int> { 2, 1 };

            var actualValues = new List<int>();
            var currentNode = linkedList.Head;
            while (currentNode != null)
            {
                actualValues.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        // Test to delete an element and check the list.
        [TestMethod]
        public void TestDeleteElement()
        {
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);

            linkedList.DeleteElement(1);

            var expectedValues = new List<int> { 2 };

            var actualValues = new List<int>();
            var currentNode = linkedList.Head;
            while (currentNode != null)
            {
                actualValues.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        // Test to search for an element.
        [TestMethod]
        public void TestSearchElement()
        {
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);

            Assert.IsTrue(linkedList.SearchElement(1));
            Assert.IsFalse(linkedList.SearchElement(3));
        }
    }
}