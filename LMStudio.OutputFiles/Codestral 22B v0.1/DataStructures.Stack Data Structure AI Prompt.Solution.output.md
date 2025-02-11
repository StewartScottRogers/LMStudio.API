Here's a simple implementation in C# that follows your guidelines. This library creates an integer stack with fixed size and implements basic operations such as push, pop, peek, isEmpty, and isFull.

First, let's create the interface for our stack.

```csharp
// IStackInterface.cs
public interface IStackInterface<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty();
    bool IsFull();
}
```

Next, let's create the Stack class that implements this interface.

```csharp
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
```

Now, let's write some unit tests for our stack implementation.

```csharp
// StackUnitTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StackUnitTests
{
    [TestMethod]
    public void TestPushAndPop()
    {
        var stack = new StackClass<int>(5);
        stack.Push(1);
        Assert.AreEqual(1, stack.Pop());
    }

    // More tests for isEmpty, isFull, peek, etc.
}
```

This implementation should be enough to get you started. It's a good practice to expand on this and include more functionality or error handling as needed.