namespace LinkedListLibrary;

public record LinkedListResultTuple(bool Success, string Message);

public class LinkedList
{
    private Node Head;

    public void InsertAtBeginning(int value)
    {
        var newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
    }

    public bool DeleteElement(int value)
    {
        if (Head == null) return false;

        if (Head.Value == value)
        {
            Head = Head.Next;
            return true;
        }

        Node current = Head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next == null) return false;

        current.Next = current.Next.Next;
        return true;
    }

    public LinkedListResultTuple SearchElement(int value)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Value == value)
                return new LinkedListResultTuple(true, "Element found.");
            current = current.Next;
        }
        return new LinkedListResultTuple(false, "Element not found.");
    }

    public string DisplayList()
    {
        var displayString = "";
        Node current = Head;
        while (current != null)
        {
            displayString += current.Value + " -> ";
            current = current.Next;
        }
        return displayString.TrimEnd(' ', '-');
    }
}