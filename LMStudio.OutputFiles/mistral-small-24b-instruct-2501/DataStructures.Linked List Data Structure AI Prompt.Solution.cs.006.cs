using LinkedListDataStructure.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListDataStructure.Tests
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        private readonly SinglyLinkedList<int> linkedList = new();

        [TestMethod]
        public void TestInsertAtBeginning()
        {
            linkedList.InsertAtBeginning(10);
            var dataTuple = (int, int)GetDataFromList();
            Assert.AreEqual(dataTuple.Item2, 1); // Expecting only one element
            Assert.AreEqual(dataTuple.Item1[0], 10);
        }

        [TestMethod]
        public void TestDeleteElement()
        {
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);

            var dataTuple = (int, int)GetDataFromList();
            Assert.AreEqual(dataTuple.Item2, 2); // Expecting two elements

            linkedList.DeleteElement(10);
            var newDataTuple = (int, int)GetDataFromList();
            Assert.AreEqual(newDataTuple.Item2, 1); // Expecting one element
            Assert.AreEqual(newDataTuple.Item1[0], 20);
        }

        [TestMethod]
        public void TestSearchElement()
        {
            linkedList.InsertAtBeginning(10);
            Assert.IsTrue(linkedList.SearchElement(10));
            Assert.IsFalse(linkedList.SearchElement(5));
        }

        private var GetDataFromListTuple()
        {
            int index = 0;
            var dataList = new List<int>();
            var currentNode = linkedList.Head;

            while (currentNode != null)
            {
                dataList.Add(currentNode.Data);
                currentNode = currentNode.Next as LinkedListNode<int>;
                index++;
            }

            return (dataList, index);
        }
    }
}