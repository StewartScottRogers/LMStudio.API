// Solution File: LinkedListSolution.sln

// Project File: LinkedListLibrary/LinkedListLibrary.csproj
// <Project Sdk="Microsoft.NET.Sdk">
//   <PropertyGroup>
//     <OutputType>Library</OutputType>
//     <TargetFramework>net9.0</TargetFramework>
//     <ImplicitUsings>disable</ImplicitUsings>
//     <Nullable>disable</Nullable>
//   </PropertyGroup>
// </Project>

// File: LinkedListNode.cs
using System;

namespace LinkedListLibrary
{
    public class LinkedListNode
    {
        private readonly int dataValue;
        private LinkedListNode? nextNode;

        public LinkedListNode(int data)
        {
            dataValue = data;
            nextNode = null;
        }

        public int DataValue
        {
            get { return dataValue; }
        }

        public LinkedListNode? NextNode
        {
            get { return nextNode; }
            set { nextNode = value; }
        }
    }
}

// File: LinkedList.cs
using System;

namespace LinkedListLibrary
{
    public class LinkedList
    {
        private LinkedListNode? headNode;

        public LinkedList()
        {
            headNode = null;
        }

        public bool IsEmpty
        {
            get { return headNode == null; }
        }

        // Method to insert an element at the beginning of the linked list.
        public void InsertAtBeginning(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.NextNode = headNode;
            headNode = newNode;
        }

        // Method to delete an element from the linked list.
        public bool DeleteElement(int data)
        {
            if (IsEmpty)
            {
                return false; // List is empty, cannot delete.
            }

            if (headNode!.DataValue == data)
            {
                headNode = headNode.NextNode;
                return true; // Deleted the first element.
            }

            LinkedListNode? currentNode = headNode;
            while (currentNode?.NextNode != null)
            {
                if (currentNode.NextNode.DataValue == data)
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    return true; // Deleted the element.
                }
                currentNode = currentNode.NextNode;
            }

            return false; // Element not found in the list.
        }

        // Method to search for a specific element in a linked list.
        public (bool Found, int? Data) SearchElement(int data)
        {
            LinkedListNode? currentNode = headNode;

            while (currentNode != null)
            {
                if (currentNode.DataValue == data)
                {
                    return (true, currentNode.DataValue); // Element found.
                }
                currentNode = currentNode.NextNode;
            }

            return (false, null); // Element not found.
        }

        // Method to display the linked list elements.  For testing purposes.
        public string DisplayList()
        {
            string resultString = "";
            LinkedListNode? currentNode = headNode;

            while (currentNode != null)
            {
                resultString += currentNode.DataValue + " ";
                currentNode = currentNode.NextNode;
            }

            return resultString.Trim(); // Return the list as a string.
        }
    }
}

// File: LinkedListTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListLibrary;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestIsEmpty_EmptyList()
        {
            LinkedList linkedList = new LinkedList();
            Assert.IsTrue(linkedList.IsEmpty);
        }

        [TestMethod]
        public void TestInsertAtBeginning_FirstElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            Assert.IsFalse(linkedList.IsEmpty);
            var (found, data) = linkedList.SearchElement(10);
            Assert.IsTrue(found);
            Assert.AreEqual(10, data);
        }

        [TestMethod]
        public void TestInsertAtBeginning_MultipleElements()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);
            var (found1, data1) = linkedList.SearchElement(10);
            Assert.IsTrue(found1);
            Assert.AreEqual(10, data1);

            var (found2, data2) = linkedList.SearchElement(20);
            Assert.IsTrue(found2);
            Assert.AreEqual(20, data2);
        }

        [TestMethod]
        public void TestDeleteElement_FirstElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            Assert.IsTrue(linkedList.DeleteElement(10));
            Assert.IsTrue(linkedList.IsEmpty);
        }

        [TestMethod]
        public void TestDeleteElement_MiddleElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);
            Assert.IsTrue(linkedList.DeleteElement(10));
            var (found, data) = linkedList.SearchElement(10);
            Assert.IsFalse(found);

            var (found2, data2) = linkedList.SearchElement(20);
            Assert.IsTrue(found2);
            Assert.AreEqual(20, data2);
        }

        [TestMethod]
        public void TestDeleteElement_LastElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            Assert.IsTrue(linkedList.DeleteElement(10));
            Assert.IsTrue(linkedList.IsEmpty);
        }

        [TestMethod]
        public void TestDeleteElement_NotFound()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            Assert.IsFalse(linkedList.DeleteElement(20));
            var (found, data) = linkedList.SearchElement(10);
            Assert.IsTrue(found);
            Assert.AreEqual(10, data);
        }

        [TestMethod]
        public void TestSearchElement_Found()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);
            var (found, data) = linkedList.SearchElement(10);
            Assert.IsTrue(found);
            Assert.AreEqual(10, data);
        }

        [TestMethod]
        public void TestSearchElement_NotFound()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);
            var (found, data) = linkedList.SearchElement(30);
            Assert.IsFalse(found);
            Assert.IsNull(data);
        }

        [TestMethod]
        public void TestDisplayList_EmptyList()
        {
            LinkedList linkedList = new LinkedList();
            Assert.AreEqual("", linkedList.DisplayList());
        }

        [TestMethod]
        public void TestDisplayList_SingleElement()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(10);
            Assert.AreEqual("10", linkedList.DisplayList());
        }

        [TestMethod]
        public void TestDisplayList_MultipleElements()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(10);
            Assert.AreEqual("10 20", linkedList.DisplayList());
        }
    }
}