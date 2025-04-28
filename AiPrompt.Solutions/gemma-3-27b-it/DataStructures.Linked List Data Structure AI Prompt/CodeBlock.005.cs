// LinkedListTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListDataStructure;

namespace LinkedListDataStructureTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void InsertAtBeginning_EmptyList()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();

            // Act
            linkedList.InsertAtBeginning(10);

            // Assert
            Assert.AreEqual(10, linkedList.Head?.Data);
        }

        [TestMethod]
        public void InsertAtBeginning_NonEmptyList()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(20);

            // Act
            linkedList.InsertAtBeginning(10);

            // Assert
            Assert.AreEqual(10, linkedList.Head?.Data);
            Assert.AreEqual(20, linkedList.Head?.Next?.Data);
        }

        [TestMethod]
        public void DeleteElement_EmptyList()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();

            // Act
            linkedList.DeleteElement(10);

            // Assert
            Assert.IsNull(linkedList.Head);
        }

        [TestMethod]
        public void DeleteElement_FirstElement()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);

            // Act
            linkedList.DeleteElement(10);

            // Assert
            Assert.IsNull(linkedList.Head);
        }

        [TestMethod]
        public void DeleteElement_MiddleElement()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(30);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);

            // Act
            linkedList.DeleteElement(20);

            // Assert
            Assert.AreEqual(10, linkedList.Head?.Data);
            Assert.AreEqual(30, linkedList.Head?.Next?.Data);
        }

        [TestMethod]
        public void DeleteElement_LastElement()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);

            // Act
            linkedList.DeleteElement(10);

            // Assert
            Assert.IsNull(linkedList.Head);
        }

        [TestMethod]
        public void SearchElement_EmptyList()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();

            // Act & Assert
            Assert.IsFalse(linkedList.SearchElement(10));
        }

        [TestMethod]
        public void SearchElement_Present()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(30);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);

            // Act
            bool found = linkedList.SearchElement(20);

            // Assert
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void SearchElement_Absent()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(30);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);

            // Act
            bool found = linkedList.SearchElement(40);

            // Assert
            Assert.IsFalse(found);
        }
    }
}