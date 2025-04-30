// Program.cs
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);

            Console.WriteLine("Linked list after insertions:");
            linkedList.DisplayList(); // Output: 30 20 10

            Console.WriteLine("Search for 20: " + linkedList.SearchElement(20)); // Output: True
            Console.WriteLine("Search for 40: " + linkedList.SearchElement(40)); // Output: False

            linkedList.DeleteElement(20);

            Console.WriteLine("Linked list after deleting 20:");
            linkedList.DisplayList(); // Output: 30 10

            // Unit Tests
            RunUnitTests();
        }

        static void RunUnitTests()
        {
            LinkedListTest linkedListTest = new LinkedListTest();
            linkedListTest.InsertAtBeginning_ValidData_InsertsNode();
            linkedListTest.DeleteElement_FirstElement_DeletesCorrectly();
            linkedListTest.SearchElement_ExistingElement_ReturnsTrue();
            linkedListTest.SearchElement_NonExistingElement_ReturnsFalse();
        }
    }
}