using Interfaces;
using DataStructure;

namespace LinkedListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            // Insert elements at the beginning
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);
            linkedList.InsertAtBeginning(3);

            // Search for an element
            var searchedElement = linkedList.SearchElement(2);
            System.Console.WriteLine($"Searched Element: {searchedElement.Value}");

            // Delete an element
            bool deletionResult = linkedList.DeleteElement(2);
            System.Console.WriteLine($"Deletion Result: {deletionResult}");
        }
    }
}