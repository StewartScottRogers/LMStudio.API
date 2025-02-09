public T Pop()
{
    if (_topIndex == -1) ThrowEmptyException();
    return _items[_topIndex--];
}

private void ThrowEmptyException()
{
    throw new InvalidOperationException("Stack is empty");
}