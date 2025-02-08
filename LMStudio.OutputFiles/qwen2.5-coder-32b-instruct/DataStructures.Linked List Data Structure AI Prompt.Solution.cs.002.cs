using System.Collections.Generic;

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T>? head;
    
    public bool IsEmpty => head is null;

    public void InsertAtBeginning(T data)
    {
        var newNode = new Node<T>(data, head);
        head = newNode;
    }

    public bool Search(T data)
    {
        var current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
                return true;

            current = current.Next;
        }
        return false;
    }

    public bool Delete(T data)
    {
        if (head is null)
            return false;

        if (EqualityComparer<T>.Default.Equals(head.Data, data))
        {
            head = head.Next;
            return true;
        }

        var current = head;
        while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, data))
        {
            current = current.Next;
        }

        if (current.Next is null)
            return false;

        current.Next = current.Next.Next;
        return true;
    }

    public IEnumerable<T> Traverse()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}