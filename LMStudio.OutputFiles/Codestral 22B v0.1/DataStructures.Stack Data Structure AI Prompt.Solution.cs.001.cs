// StackClass.cs
public class StackClass<T> : IStackInterface<T>
{
    private readonly T[] _stackArray;
    private int _topIndex;
    public int Size { get; }

    public StackClass(int size)
    {
        Size = size;
        _stackArray = new T[Size];
        _topIndex = -1;
    }

    public bool IsEmpty() => _topIndex < 0;

    public bool IsFull() => _topIndex >= Size - 1;

    public void Push(T item)
    {
        if (IsFull()) throw new StackOverflowException();
        _stackArray[++_topIndex] = item;
    }

    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
        return _stackArray[_topIndex--];
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
        return _stackArray[_topIndex];
    }
}