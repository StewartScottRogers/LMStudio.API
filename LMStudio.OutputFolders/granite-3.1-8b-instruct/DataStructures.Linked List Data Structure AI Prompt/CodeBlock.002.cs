using Microsoft.VisualStudio.TestTools.UnitTesting;

public class LinkedList : ILinkedList<int>
{
    private readonly Node _head;

    public LinkedList() => _head = null;

    public bool Search(int item, out Node? foundNode)
    {
        var current = _head;
        foundNode = null;

        while (current != null)
        {
            if (current.data == item)
            {
                foundNode = current;
                return true;
            }

            current = current.next;
        }

        foundNode = null;
        return false;
    }

    public void InsertAtBeginning(int item)
    {
        _head = new Node(item, _head);
    }

    public void Delete(Node nodeToDelete)
    {
        if (nodeToDelete == _head)
            _head = nodeToDelete.next;

        var current = _head;
        while (current.next != null && current.next != nodeToDelete)
            current = current.next;

        current.next = nodeToDelete.next;
    }
}