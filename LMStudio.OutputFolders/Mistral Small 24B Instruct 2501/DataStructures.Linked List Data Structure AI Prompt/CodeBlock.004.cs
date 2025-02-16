using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;

namespace UnitTestsProject
{
    [TestClass]
    public class LinkedListTests
    {
        private readonly ILinkedList<int> linkedList = new LinkedList<int>();

        [TestMethod]
        public void TestInsertAtBeginning()
        {
            // Arrange & Act
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);

            // Assert
            var head = linkedList.SearchElement(2);
            Assert.IsNotNull(head);
            Assert.AreEqual(2, head.Value);
        }

        [TestMethod]
        public void TestDeleteElement()
        {
            // Arrange
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);

            // Act
            bool result = linkedList.DeleteElement(2);

            // Assert
            Assert.IsTrue(result);
            var head = linkedList.SearchElement(2);
            Assert.IsNull(head);
        }

        [TestMethod]
        public void TestSearchElement()
        {
            // Arrange
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);

            // Act
            var element = linkedList.SearchElement(1);

            // Assert
            Assert.IsNotNull(element);
            Assert.AreEqual(1, element.Value);
        }

        [TestMethod]
        public void TestDeleteNonExistentElement()
        {
            // Arrange & Act
            bool result = linkedList.DeleteElement(3);

            // Assert
            Assert.IsFalse(result);
        }
    }
}