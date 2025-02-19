using System;

public class Program
{
    public static void Main()
    {
        LinkedList list = new LinkedList();
        list.InsertAtBeginning(5);
        list.InsertAtBeginning(10);

        Console.WriteLine("Searching for 5: " + (list.Search(5) ? "Found" : "Not Found"));
        Console.WriteLine("Deleting 10: " + (list.Delete(10) ? "Deleted" : "Not Deleted"));
        Console.WriteLine("Searching for 10 after deletion: " + (list.Search(10) ? "Found" : "Not Found"));
    }
}