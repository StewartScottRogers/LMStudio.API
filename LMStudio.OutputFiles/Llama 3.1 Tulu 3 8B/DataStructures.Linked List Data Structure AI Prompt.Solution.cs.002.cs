using System;
using System.Collections.Generic;

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T> _head;

    public void AddFirst(T item) => _head = new Node<T>(item, _head);
    
    public bool Contains(T item)
    {
        var current = _head;
        while (current != default(Node<T>))
        {
            if (Equals(current.Value, item)) return true;
            current = current.Next;
        }
        return false;
    }

    public void Remove(T item)
    {
        if (_head.Value.Equals(item))
        {
            _head = _head.Next;
            return;
        }

        var prev = _head;
        var current = _head.Next;
        while (current != default(Node<T>))
        {
            if (current.Value.Equals(item))
            {
                prev.Next = current.Next;
                return;
            }
            prev = current;
            current = current.Next;
        }
    }

    public int Count
    {
        get
        {
            var count = 0;
            var current = _head;
            while (current != default(Node<T>))
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}