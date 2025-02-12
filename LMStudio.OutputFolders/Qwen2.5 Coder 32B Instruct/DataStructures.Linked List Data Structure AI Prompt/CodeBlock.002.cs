namespace DataStructures;

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T> head;
    public readonly int Count;

    public LinkedList()
    {
        head = null;
        Count = 0;
    }

    public void InsertAtBeginning(T value)
    {
        var newNode = new Node<T>(value, head);
        head = newNode;
    }

    public bool DeleteElement(T value)
    {
        if (head == null) return false;

        if (head.Value.Equals(value))
        {
            head = head.Next;
            return true;
        }

        var current = head;
        while (current.Next != null && !current.Next.Value.Equals(value))
        {
            current = current.Next;
        }

        if (current.Next == null) return false;

        current.Next = current.Next.Next;
        return true;
    }

    public Node<T> SearchElement(T value)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value.Equals(value)) return current;
            current = current.Next;
        }
        return null;
    }

    public int Count
    {
        get
        {
            int count = 0;
            var current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}