public class LinkedList
{
    private Node? head;

    public bool IsEmpty => head == null;

    public void InsertAtBeginning(int value)
    {
        var newNode = new Node(value, head);
        head = newNode;
    }

    public (bool Success, int Value) SearchElement(int targetValue)
    {
        var currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.Value == targetValue)
                return (true, currentNode.Value);

            currentNode = currentNode.Next;
        }
        return (false, default);
    }

    public bool DeleteElement(int valueToDelete)
    {
        if (head == null) return false;

        if (head.Value == valueToDelete)
        {
            head = head.Next;
            return true;
        }

        var previousNode = head;
        while (previousNode.Next != null && previousNode.Next.Value != valueToDelete)
        {
            previousNode = previousNode.Next;
        }

        if (previousNode.Next == null) return false;

        previousNode.Next = previousNode.Next.Next;
        return true;
    }
}