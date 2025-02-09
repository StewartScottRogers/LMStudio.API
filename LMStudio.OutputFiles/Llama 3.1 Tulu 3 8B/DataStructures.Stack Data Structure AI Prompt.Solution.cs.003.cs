public T Peek()
{
    if (_topIndex == -1) ThrowEmptyException();
    return _items[_topIndex];
}