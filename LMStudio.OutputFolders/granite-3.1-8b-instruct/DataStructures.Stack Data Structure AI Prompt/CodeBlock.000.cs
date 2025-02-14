public record Stack<T>
{
    private readonly List<T> _elements;

    public Stack(int capacity)
    {
        _elements = new List<T>(capacity);
    }
    
    public void Push(T item)
    {
        _elements.Add(item);
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot pop from an empty stack.");

        var topItem = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        return topItem;
    }
    
    public bool IsEmpty => _elements.Count == 0;

    public bool IsFull => _elements.Count >= _elements.Capacity;

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot peek at an empty stack.");

        return _elements[_elements.Count - 1];
    }
}