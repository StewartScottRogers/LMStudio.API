using LinkedList.Core.Interfaces;

namespace LinkedList.Core;

/// <summary>
/// Provides extension methods for the LinkedList class.
/// </summary>
public static class LinkedListExtensions
{
    /// <summary>
    /// Displays all elements in the linked list to the console.
    /// </summary>
    /// <typeparam name="T">The type of elements in the linked list.</typeparam>
    /// <param name="list">The linked list to display.</param>
    public static void Display<T>(this ILinkedList<T> list)
    {
        var elements = list.GetAllElements();
        
        Console.Write("LinkedList: [");
        for (int i = 0; i < elements.Length; i++)
        {
            if (i > 0)
                Console.Write(", ");
            Console.Write(elements[i]);
        }
        Console.WriteLine("]");
    }
}