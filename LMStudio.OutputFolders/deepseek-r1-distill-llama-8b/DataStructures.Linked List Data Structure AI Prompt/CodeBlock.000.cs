using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList
{
    public class Node
    {
        public Object Data { get; private set; }
        public Node Next { get; private set; }

        public Node(Object data)
        {
            this.Data = data;
        }
    }

    public class LinkedList
    {
        private Node head;

        public LinkedList(Object data)
        {
            if (head == null && data != null)
            {
                head = new Node(data);
            }
        }

        public Node InsertFirst(Object data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            if (head != null)
            {
                head.Previous = newNode;
            }
            return newNode;
        }

        public Node Search(Object data)
        {
            Node current = head;
            while (current != null && !Object.Equals(current.Data, data))
            {
                current = current.Next;
            }
            return current;
        }

        public void Delete(Object data)
        {
            Node current = Search(data);
            if (current != null)
            {
                if (current == head && head.Next != null)
                {
                    head = current.Next;
                }
                else if (current.Next != null)
                {
                    current.Previous.Next = null;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }

                current = null;
            }
        }

        public void ReallocateMemory()
        {
            // This method is optional based on requirements. 
            // For the scope of this task, it's left commented out.
        }
    }

    [TestClass]
    public class LinkedListTests
    {
        private LinkedList list;

        public LinkedListTests()
        {
            list = new LinkedList("Head");
        }

        [TestMethod]
        public void TestInsertFirst()
        {
            Node node = list.InsertFirst("New Head");
            Assert.AreEqual("New Head", node.Data);
            Assert.AreEqual("Head", node.Next.Data);
        }

        [TestMethod]
        public void TestSearch()
        {
            Node foundNode = list.Search("Head");
            Assert.AreEqual("Head", foundNode.Data);
            Assert.IsNull(list.Search("Not Found"));
        }

        [TestMethod]
        public void TestDelete()
        {
            list.Delete("Head");
            Assert.IsNull(list.Search("Head"));
            list.InsertFirst("New Head");
            list.Delete("New Head");
            Assert.IsNull(list.Search("New Head"));
        }
    }

    /// <summary>
    /// A linked list implementation using object nodes with dynamic memory allocation.
    /// Contains methods for insertion at the beginning, searching, deletion,
    /// and dynamic memory reallocation capabilities.
    /// </summary>

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList("Initial Element");
            Console.WriteLine("Linked List created with: " + list.Search("Initial Element").Data);
        }
    }

    /// <summary>
    /// Unit tests using Microsoft's Unit Test Framework to validate linked list operations.
    /// </summary>
}