using System;
using LinkedListDataStructure.Classes;

namespace LinkedListDataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new SinglyLinkedList<int>();

            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);

            Console.WriteLine("Linked List:");
            linkedList.PrintList();

            Console.WriteLine($"Search 20: {linkedList.SearchElement(20)}");
            Console.WriteLine($"Delete 20: {linkedList.DeleteElement(20)}");

            Console.WriteLine("Linked List after deletion:");
            linkedList.PrintList();
        }
    }
}