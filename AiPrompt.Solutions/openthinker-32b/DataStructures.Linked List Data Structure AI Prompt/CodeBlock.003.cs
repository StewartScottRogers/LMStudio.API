using System;

namespace LinkedListSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);

            var (found, value) = linkedList.FindElement(10);
            if (found)
                Console.WriteLine($"Element found: {value}");
            else
                Console.WriteLine("Element not found");

            bool deletionResult = linkedList.DeleteElement(20);
            Console.WriteLine(deletionResult ? "Element deleted successfully" : "Deletion failed");
        }
    }
}