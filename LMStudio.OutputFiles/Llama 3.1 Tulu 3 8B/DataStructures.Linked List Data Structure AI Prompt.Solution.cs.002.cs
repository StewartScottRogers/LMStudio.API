// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        var list = new LinkedList<int>();

        // Add some items to the list.
        list.AddFirst(10);
        list.AddFirst(20);
        list.AddFirst(30);

        Console.WriteLine("Initial List:");
        PrintList(list._head);

        // Insert an item after a specific value
        list.InsertAfter(20, 25);
        Console.WriteLine("\nList After Insertion (after 20):");
        PrintList(list._head);

        // Delete an item from the list.
        if (list.Delete(30))
            Console.WriteLine("\nList After Deletion (30):");
        else
            Console.WriteLine("Failed to delete 30.");

        PrintList(list._head);
        
        // Check if list contains a certain value.
        Console.WriteLine($"\nDoes List Contain 25? {list.Contains(25)}");

        Console.ReadKey();
    }

    static void PrintList(ListNode<int>? node)
    {
        while (node != null)
        {
            Console.Write(node.Item + " ");
            node = node.NextNode;
        }
        Console.WriteLine();
    }
}