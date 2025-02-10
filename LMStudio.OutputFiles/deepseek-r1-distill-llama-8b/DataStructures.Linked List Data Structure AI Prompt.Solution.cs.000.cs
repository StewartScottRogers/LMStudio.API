using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListSolution
{
    public class LinkedList
    {
        private readonly Node head;
        private readonly Node tail;

        public bool InsertAtBeginning(object value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            return true;
        }

        public bool Search(object value)
        {
            Node current = head;
            while (current != null && current.Value != value)
            {
                current = current.Next;
            }
            return current != null;
        }

        public bool DeleteNode(object value)
        {
            Node current = head;
            Node prevNode = null;
            while (current != null && current.Value != value)
            {
                prevNode = current;
                current = current.Next;
            }
            if (current == null) return false;

            if (prevNode == null)
            {
                head = current.Next;
                tail = head;
            }
            else
            {
                prevNode.Next = current.Next;
                if (current.Next == null)
                    tail = prevNode;
            }
            return true;
        }

        public int Length()
        {
            Node current = head;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    public record Node
    {
        public object Value { get; set; }
        public LinkedList<Node> Next { get; set; }
    }

    [TestClass]
    public class LinkedListTests
    {
        private readonly LinkedList list = new LinkedList();

        [TestMethod]
        public void TestInsertAtBeginning()
        {
            bool success = list.InsertAtBeginning(5);
            Assert.IsTrue(success, "Failed to insert at beginning");
        }

        [TestMethod]
        public void TestSearchExistingElement()
        {
            list.InsertAtBeginning(3);
            list.InsertAtBeginning(4);
            list.InsertAtBeginning(5);

            bool found = list.Search(5);
            Assert.IsTrue(found, "Should find existing element");
        }

        [TestMethod]
        public void TestDeleteNode()
        {
            list.InsertAtBeginning(1);
            list.InsertAtBeginning(2);
            list.InsertAtBeginning(3);

            bool deletedThree = list.DeleteNode(3);
            Assert.IsTrue(deletedThree, "Failed to delete node");

            int count = list.Length();
            Assert.AreEqual(2, count, "List should have 2 nodes after deletion");
        }
    }
}