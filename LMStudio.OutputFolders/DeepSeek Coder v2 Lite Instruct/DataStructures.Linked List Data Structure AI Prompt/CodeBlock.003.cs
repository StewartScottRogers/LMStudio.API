using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListApp.Tests
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void InsertAtBeginning_ShouldAddNodeToEmptyList()
        {
            var list = new SinglyLinkedList<int>();
            list.InsertAtBeginning(1);
            Assert.IsTrue(list.Search(1));
        }

        [TestMethod]
        public void Search_ShouldReturnFalseForNonExistentValue()
        {
            var list = new SinglyLinkedList<int>();
            list.InsertAtBeginning(1);
            Assert.IsFalse(list.Search(2));
        }

        [TestMethod]
        public void Delete_ShouldRemoveExistingNode()
        {
            var list = new SinglyLinkedList<int>();
            list.InsertAtBeginning(1);
            list.InsertAtBeginning(2);
            Assert.IsTrue(list.Delete(1));
            Assert.IsFalse(list.Search(1));
        }
    }
}