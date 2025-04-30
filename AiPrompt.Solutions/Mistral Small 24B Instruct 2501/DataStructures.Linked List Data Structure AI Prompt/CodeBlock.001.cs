using System.Collections.Generic;

public class LinkedList
{
    private Node head;

    public void InsertAtBeginning(int value)
    {
        var newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
    }

    public bool DeleteElement(int value)
    {
        if (head == null) return false;

        // If the node to be deleted is the head
        if (head.Value == value)
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        // Element not found
        if (current.Next == null) return false;

        // Unlink the node from the linked list
        current.Next = current.Next.Next;
        return true;
    }

    public bool SearchElement(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == value) return true;
            current = current.Next;
        }
        return false;
    }

    public IEnumerable<int> GetAllElements()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
}