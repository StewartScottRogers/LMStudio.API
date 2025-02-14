using System.Collections.Generic;

public class LinkedList : ILinkedList
{
    private Node Head;

    public LinkedList()
    {
        Head = null;
    }

    public void InsertAtBeginning(int value)
    {
        var newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
    }

    public var SearchElement(int value)
    {
        Node currentNode = Head;
        int position = 0;

        while (currentNode != null)
        {
            if (currentNode.Value == value)
            {
                return (position, currentNode) as (int Position, Node NodeTuple);
            }
            currentNode = currentNode.Next;
            position++;
        }

        return (-1, null) as (int Position, Node NodeTuple);
    }

    public DeleteStatus DeleteElement(int value)
    {
        if (Head == null)
            return DeleteStatus.ElementNotFound;

        if (Head.Value == value)
        {
            Head = Head.Next;
            return DeleteStatus.Success;
        }

        Node currentNode = Head;
        while (currentNode.Next != null && currentNode.Next.Value != value)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode.Next == null)
            return DeleteStatus.ElementNotFound;

        currentNode.Next = currentNode.Next.Next;
        return DeleteStatus.Success;
    }
}