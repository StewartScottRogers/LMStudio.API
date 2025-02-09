// LinkedList.cs
public class LinkedList<T>
{
    private ListNode<T>? _head;

    // Constructor initializes the list.
    public LinkedList()
    {
        _head = null;
    }

    // Adds an element at the beginning of the list.
    public void AddFirst(T item)
    {
        _head = new ListNode<T>(item, _head);
    }
    
    // Inserts a node after a given key.
    public void InsertAfter(T key, T newItem)
    {
        var currentNode = _head;
        while (currentNode is not null && currentNode.Item != key)
            currentNode = currentNode.NextNode;

        if(currentNode != null)
            currentNode.NextNode = new ListNode<T>(newItem, currentNode.NextNode);
    }

    // Deletes a node with the given value.
    public bool Delete(T item)
    {
        if (_head is null) return false;

        if (_head.Item.Equals(item))
        {
            _head = _head.NextNode;
            return true;
        }

        var prevNode = _head;
        var currentNode = _head?.NextNode;

        while (currentNode != null && !currentNode.Item.Equals(item))
        {
            prevNode = currentNode;
            currentNode = currentNode.NextNode;
        }
        
        if (currentNode is not null)
        {
            prevNode.NextNode = currentNode.NextNode;
            return true;
        }

        return false;
    }

    // Searches for an item in the list.
    public bool Contains(T item)
    {
        var currentNode = _head;
        while (currentNode != null && !currentNode.Item.Equals(item))
            currentNode = currentNode.NextNode;

        return currentNode is not null;
    }
}