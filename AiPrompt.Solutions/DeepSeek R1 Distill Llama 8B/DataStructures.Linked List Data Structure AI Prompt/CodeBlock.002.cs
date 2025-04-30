using LinkedListLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTest
    {
        private readonly LinkedList linkedList = new();

        [TestMethod]
        public void InsertAtBeginning_InsertsElement_CanBeFound()
        {
            int elementToInsert = 42;
            linkedList.InsertAtBeginning(elementToInsert);
            Assert.IsTrue(linkedList.SearchElement(elementToInsert), "Inserted element should be found in the list.");
        }

        [TestMethod]
        public void SearchElement_FindsExistingElement_ReturnsTrue()
        {
            int existingElement = 10;
            linkedList.InsertAtBeginning(existingElement);
            bool isFound = linkedList.SearchElement(existingElement);
            Assert.IsTrue(isFound, "Existing element should be found in the list.");
        }

        [TestMethod]
        public void SearchElement_DoesntFindNonexistentElement_ReturnsFalse()
        {
            int nonexistentElement = 99;
            bool isFound = linkedList.SearchElement(nonexistentElement);
            Assert.IsFalse(isFound, "Nonexistent element should not be found in the list.");
        }

        [TestMethod]
        public void DeleteElement_DeletesExistingElement_CannotBeFound()
        {
            int elementToDelete = 10;
            linkedList.InsertAtBeginning(elementToDelete);
            bool isDeleted = linkedList.DeleteElement(elementToDelete);
            Assert.IsTrue(isDeleted, "Element should be deleted from the list.");
            Assert.IsFalse(linkedList.SearchElement(elementToDelete), "Deleted element should not be found in the list.");
        }

        [TestMethod]
        public void DeleteElement_TriesToDeleteNonexistentElement_ReturnsFalse()
        {
            int nonexistentElement = 99;
            bool isDeleted = linkedList.DeleteElement(nonexistentElement);
            Assert.IsFalse(isDeleted, "Trying to delete a nonexistent element should return false.");
        }
    }
}