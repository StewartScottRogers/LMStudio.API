// Program.cs
using System;

namespace LinkedListDataStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);

            Console.WriteLine("Linked list after insertions:");
            linkedList.DisplayList(); // Output: 30 20 10

            Console.WriteLine("Searching for 20: " + linkedList.SearchElement(20)); // Output: True
            Console.WriteLine("Searching for 40: " + linkedList.SearchElement(40)); // Output: False

            linkedList.DeleteElement(20);

            Console.WriteLine("Linked list after deleting 20:");
            linkedList.DisplayList(); // Output: 30 10
        }
    }
}