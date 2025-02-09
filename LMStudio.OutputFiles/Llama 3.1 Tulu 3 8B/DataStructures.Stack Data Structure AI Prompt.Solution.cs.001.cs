public void Push(T item)
{
    if (_topIndex == _items.Length - 1) ThrowFullException();
    _items[++_topIndex] = item;
}

private void ThrowFullException()
{
    throw new InvalidOperationException("Stack is full");
}