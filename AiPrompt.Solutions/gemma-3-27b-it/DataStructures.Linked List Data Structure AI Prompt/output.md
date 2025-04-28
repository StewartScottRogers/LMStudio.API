```csharp
// Solution File: LinkedListSolution.sln

// Project File: LinkedListLibrary.csproj
// Target Framework: net9.0

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListLibrary
{
    // Node Class for the Linked List
    public class Node
    {
        private readonly int data;
        private Node nextNode;

        public Node(int newData)
        {
            data = newData;
            nextNode = null;
        }

        public int Data
        {
            get { return data; }
        }

        public Node NextNode
        {
            get { return nextNode; }
            set { nextNode = value; }
        }
    }

    // Linked List Class
    public class LinkedList
    {
        private Node headNode;

        public LinkedList()
        {
            headNode = null;
        }

        // Method to insert a new element at the beginning of the linked list.
        public void InsertAtBeginning(int newData)
        {
            Node newNode = new Node(newData);
            newNode.NextNode = headNode;
            headNode = newNode;
        }

        // Method to search for a specific element in the linked list.
        public bool SearchElement(int key)
        {
            Node currentNode = headNode;

            while (currentNode != null)
            {
                if (currentNode.Data == key)
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }

            return false;
        }

        // Method to delete an element from the linked list.
        public void DeleteElement(int key)
        {
            Node currentNode = headNode;
            Node previousNode = null;

            // If the element to be deleted is at the beginning of the list
            if (currentNode != null && currentNode.Data == key)
            {
                headNode = currentNode.NextNode; // Change head
                return;
            }

            // Search for the key to be deleted, keeping track of the previous node as we go.
            while (currentNode != null && currentNode.Data != key)
            {
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            // If the key was not present in linked list
            if (currentNode == null)
            {
                return;
            }

            // Unlink the node from linked list
            previousNode.NextNode = currentNode.NextNode;
        }

        // Method to display the linked list elements.  For testing/debugging purposes.
        public void DisplayList()
        {
            Node currentNode = headNode;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " ");
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine();
        }
    }

    // Unit Tests for the Linked List Class
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestInsertAtBeginning()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);

            // Assert that the list contains the elements in the correct order (30, 20, 10)
            Node currentNode = linkedList.headNode;
            int index = 0;
            while (currentNode != null)
            {
                Assert.AreEqual(40 - (index * 10), currentNode.Data);
                currentNode = currentNode.NextNode;
                index++;
            }
        }

        [TestMethod]
        public void TestSearchElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);

            Assert.IsTrue(linkedList.SearchElement(20));
            Assert.IsFalse(linkedList.SearchElement(40));
        }

        [TestMethod]
        public void TestDeleteElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);

            linkedList.DeleteElement(20);

            // Assert that the list contains the elements in the correct order (30, 10)
            Node currentNode = linkedList.headNode;
            int index = 0;
            while (currentNode != null)
            {
                Assert.AreEqual(40 - (index * 10), currentNode.Data);
                currentNode = currentNode.NextNode;
                index++;
            }

            linkedList.DeleteElement(30);
            linkedList.DeleteElement(10);

            // Assert that the list is empty after deleting all elements
            Assert.IsNull(linkedList.headNode);
        }

        [TestMethod]
        public void TestDeleteNonExistentElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);

            linkedList.DeleteElement(30); // Delete a non-existent element

            // Assert that the list remains unchanged
            Node currentNode = linkedList.headNode;
            int index = 0;
            while (currentNode != null)
            {
                Assert.AreEqual(30 - (index * 10), currentNode.Data);
                currentNode = currentNode.NextNode;
                index++;
            }
        }

        [TestMethod]
        public void TestDeleteFirstElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);

            linkedList.DeleteElement(10);

            // Assert that the list is empty after deleting the first element
            Assert.IsNull(linkedList.headNode);
        }
    }
}
```
