class Program
{
    static void Main(string[] args)
    {
        var linkedList = new LinkedList();

        // Insert elements at the beginning of the list
        linkedList.InsertAtBeginning(30);
        linkedList.InsertAtBeginning(20);
        linkedList.InsertAtBeginning(10);

        // Search for an element in the list
        bool found = linkedList.SearchElement(20);
        System.Console.WriteLine($"Element 20 found: {found}");

        // Delete an element from the list
        bool deleted = linkedList.DeleteElement(20);
        System.Console.WriteLine($"Element 20 deleted: {deleted}");

        // Get all elements in the list and print them
        foreach (var value in linkedList.GetAllElements())
        {
            System.Console.WriteLine(value);
        }
    }
}