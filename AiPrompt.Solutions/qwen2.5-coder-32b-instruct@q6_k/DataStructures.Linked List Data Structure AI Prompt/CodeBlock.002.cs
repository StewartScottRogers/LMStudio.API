using System;

class Program
{
    static void Main(string[] args)
    {
        var list = new LinkedList();

        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        list.InsertAtBeginning(30);

        Console.WriteLine("List created. Searching for 20...");
        var searchResultTuple = list.SearchElement(20);
        if (searchResultTuple.Success)
            Console.WriteLine($"Found value: {searchResultTuple.Value}");
        else
            Console.WriteLine("Value not found.");

        Console.WriteLine("Deleting 20 from the list...");
        var deleteResult = list.DeleteElement(20);
        Console.WriteLine(deleteResult ? "Deleted successfully." : "Deletion failed.");

        Console.WriteLine("Searching for 20 after deletion...");
        searchResultTuple = list.SearchElement(20);
        if (searchResultTuple.Success)
            Console.WriteLine($"Found value: {searchResultTuple.Value}");
        else
            Console.WriteLine("Value not found.");
    }
}