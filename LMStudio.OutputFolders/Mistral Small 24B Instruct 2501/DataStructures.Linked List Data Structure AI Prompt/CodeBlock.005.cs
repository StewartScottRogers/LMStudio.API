using System;

class Program
{
    static void Main(string[] args)
    {
        ILinkedList linkedList = new LinkedList();

        linkedList.InsertAtBeginning(3);
        linkedList.InsertAtBeginning(2);
        linkedList.InsertAtBeginning(1);

        var searchTuple = linkedList.SearchElement(2);
        Console.WriteLine($"Element 2 found at position: {searchTuple.Position}");

        DeleteStatus status = linkedList.DeleteElement(2);
        Console.WriteLine(status == DeleteStatus.Success ? "Deletion successful" : "Element not found");
    }
}