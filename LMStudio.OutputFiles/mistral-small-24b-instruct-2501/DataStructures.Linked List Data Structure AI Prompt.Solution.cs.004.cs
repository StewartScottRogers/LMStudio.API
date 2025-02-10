using System;
using LinkedList.DataStructures;

class Program
{
    static void Main(string[] args)
    {
        var linkedList = new LinkedList<int>();

        // Insert elements at the beginning of the list
        linkedList.InsertAtBeginning(3);
        linkedList.InsertAtBeginning(2);
        linkedList.InsertAtBeginning(1);

        // Display all elements
        Console.WriteLine("All Elements: " + string.Join(", ", linkedList.GetAllElements()));

        // Search for an element
        bool found = linkedList.Search(2);
        Console.WriteLine($"Element 2 found: {found}");

        // Delete an element
        bool deleted = linkedList.Delete(2);
        Console.WriteLine($"Element 2 deleted: {deleted}");

        // Display all elements after deletion
        Console.WriteLine("All Elements after Deletion: " + string.Join(", ", linkedList.GetAllElements()));
    }
}