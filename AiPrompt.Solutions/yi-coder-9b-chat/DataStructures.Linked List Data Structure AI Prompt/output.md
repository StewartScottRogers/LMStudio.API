Here's how you could implement this in C#:

## LinkedListNode Class
```C#
public class LinkedListNode<T> 
{
  public T Value {get; set;}
  public LinkedListNode<T> Next { get; set; }

  public LinkedListNode(T value)
  {
    Value = value;
  }
}
```
## LinkedList Class
```C#
public class LinkedList<T> 
{
  public LinkedListNode<T> Head {get; private set;}
  public LinkedListNode<T> Tail {get; private set;}
  
  public void Add(T value) 
  {
    var node = new LinkedListNode<T>(value);
  
    if (Head == null)
      Head = Tail = node;
    else
    {
      Tail.Next = node;
      Tail = node;
    }
  }

  public void Delete(T value) 
  {
    LinkedListNode<T> previous = null;
    LinkedListNode<T> current = Head;

    while (current != null)
    {
      if (EqualityComparer<T>.Default.Equals(current.Value, value))
      {
        if (previous != null)
          previous.Next = current.Next;
        else
          Head = current.Next;

        if (ReferenceEquals(Tail, current))
          Tail = previous;

        break;
      }

      previous = current;
      current = current.Next;
    }
  }

  public LinkedListNode<T> Search(T value) 
  {
    LinkedListNode<T> current = Head;

    while (current != null)
    {
      if (EqualityComparer<T>.Default.Equals(current.Value, value))
        return current;

      current = current.Next;
    }

    return null;
  }
}
```
These classes provide the basic functionality you asked for: adding elements to the list (inserting at the end), deleting specified items and searching for an item in the list. 
Please note that this is a simple implementation and doesn't include validation or error handling which should be added if the code will be used in production environment. Also it doesn’t handle cases when the value type T implements non-trivial equality comparer (like custom type with overridden Equals method).