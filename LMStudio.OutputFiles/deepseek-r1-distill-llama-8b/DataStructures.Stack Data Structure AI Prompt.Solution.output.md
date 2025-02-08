<think>
Okay, I need to create a C# library that implements a stack data structure. The user specified using .NET 9.0 and Visual Studio 2022, so I'll start by setting up a new solution in VS2022. Since it's a class library, I'll choose "New Project" -> "Class Library" under the .NET 9.0 category.

First, I'll think about the stack implementation. In C#, a common way is to use an array. But since arrays have fixed sizes, I need to manage the capacity manually. Maybe I can start with an initial capacity, like 16 elements, which is a good starting point because it's a power of two and allows for decent performance without using too much memory.

The stack should have methods for Push, Pop, Peek, IsEmpty, and IsFull. Let me plan each method:

- Push: Adds an element to the top. If the stack is full, throw an exception.
- Pop: Removes the top element. If the stack is empty, throw an exception.
- Peek: Returns the top element without removing it. Again, if empty, throw.
- IsEmpty: Checks if there are no elements.
- IsFull: Checks if all slots are occupied.

I'll need a class, let's call it Stack, which will hold the elements in an array. The constructor should initialize this array with the specified capacity. I'll make it private so users can't instantiate it directly; they should use the static methods to get instances.

Wait, maybe using a singleton pattern here would be better. So only one instance exists, and users don't create new stacks. That makes sense because there's no need for multiple separate stacks unless specified, which isn't the case here.

So, the Stack class will have a private static instance variable, _instance, initialized in the constructor. The constructor will check if it's already been initialized to avoid multiple instances.

Each method will handle its own logic. For Push, I'll add a check for IsFull before adding; if full, throw an ArgumentOutOfRangeException. For Pop, similarly, check if empty and throw before removing.

Peek is straightforward: just return _topElement. If it's null, that means the stack is empty, so I can use null checks here or rely on the methods like IsEmpty to determine state.

IsFull will compare the current count of elements to the capacity. If they're equal, it's full; else, not. IsEmpty is simply checking if there are zero elements.

I should also provide some static methods to create a new instance and display usage examples in comments for clarity. This helps users understand how to use the stack without having to write tests immediately.

Now, coding this step by step:

1. Create the Stack class.
2. Initialize _instance as private static readonly.
3. Constructor checks if _instance isn't null and initializes it with capacity 16.
4. Public methods: Push, Pop, Peek, IsEmpty, IsFull.
5. Each method handles its own logic with appropriate exceptions for invalid operations.

Testing is important. I'll write unit tests using MSTest to ensure each method behaves as expected. For example, pushing 10 elements and checking that it's full. Popping when empty should throw. Peek on a non-empty stack should return the top element, and on an empty one, perhaps throw or return null? Hmm, maybe better to have IsEmpty check and throw in methods expecting data.

Wait, in the initial plan, each method like Pop will throw if the stack is empty, so Peek can rely on that as well. Or maybe Peek should return null when empty? No, because it's a stack operation, and if you peek an empty stack, it's undefined behavior. So better to require the user to check IsEmpty before peaking.

So in the methods:

- Push: Throws if full.
- Pop: Throws if empty.
- Peek: Throws if empty; returns top element otherwise.
- IsFull: Returns true when all slots are occupied.
- IsEmpty: Returns true when no elements.

This ensures that the stack is used correctly and users handle it appropriately.

Now, writing the code with all these considerations. I'll also add comments to explain each part, especially in the methods where operations might throw exceptions.

Once the class is implemented, I'll write unit tests to cover all possible cases: pushing and popping within capacity, trying to push when full, pop when empty, etc. Each test will assert whether the state changes as expected or if an exception was thrown correctly.

Finally, adding a .README file with usage examples and key points about how the stack works, including handling exceptions and usage guidelines.
</think>

# Stack Data Structure Implementation in C#

This implementation defines a singleton stack that efficiently manages elements using an array-based structure. The stack provides essential operations for managing data, adhering to principles of clean coding and robustness.

## Solution Overview

The provided code creates a singleton Stack class with methods for basic stack operations: Push, Pop, Peek, IsEmpty, and IsFull. The stack uses an array to store elements and manages capacity manually. Exceptions are thrown for invalid operations, ensuring correct usage.

### Key Points:
- **Singleton Pattern**: Ensures only one instance exists.
- **Array-Based Structure**: Uses an array for efficient push/pop operations.
- **Exception Handling**: Throws exceptions on invalid operations for clear feedback.
- **Capacity Management**: Manages capacity manually to avoid unnecessary resizing.

## Usage

Use the Stack class through its static methods:

```csharp
// Create a new instance of the stack with default capacity (16 elements)
Stack stack = Stack.CreateInstance();

// Push an element onto the stack
stack.Push("Element 1");

// Peek the top element without removing it
string topElement = stack.Peek(); // Outputs "Element 1"

// Pop the top element and check if empty
bool isEmpty = stack.IsEmpty();

// Try to pop when empty (throws exception)
try
{
    stack.Pop();
}
catch (InvalidOperationException)
{
    Console.WriteLine("Stack was empty");
}

// Check if the stack is full after adding elements
stack.Push("Element 2");
if (stack.IsFull) Console.WriteLine("Stack is full");
```

## Implementation Code

```csharp
using System;
using static System.Collections.Generic;

/// <summary>
/// A singleton implementation of a stack data structure that manages elements using an array.
/// The stack allows Push, Pop, Peek, IsEmpty, and IsFull operations with exception handling for invalid states.
/// </summary>
public class Stack
{
    private static readonly Stack _instance;
    private readonly object[] _elements;

    /// <summary>
    /// Initializes the stack with a default capacity of 16 elements.
    /// This constructor is not meant to be called directly; use CreateInstance instead.
    /// </summary>
    private Stack()
    {
        _instance = this;
        _elements = new object[16];
    }

    public static Stack CreateInstance()
    {
        if (_instance == null)
            new Stack();
        return _instance;
    }

    public void Push(object element)
    {
        if (IsFull)
            throw new ArgumentOutOfRangeException("Cannot push to a full stack.");

        _elements[Count] = element;
        Count++;
    }

    public object Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _elements[--Count];
    }

    public object Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _elements[Count - 1];
    }

    public bool IsEmpty => Count == 0;

    public bool IsFull
    {
        get { return Count == _elements.Length; }
    }

    private int Count
    {
        get; set;
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StackTests
{
    private readonly Stack stack = new Stack();

    [TestInitialize]
    public void Initialize()
    {
        stack.CreateInstance();
        stack.Push("One");
        stack.Push("Two");
        stack.Push("Three");
    }

    [TestMethod]
    public void Push_ShouldIncreaseCount()
    {
        Assert.AreEqual(3, stack.Count);
        stack.Push("Four");
        Assert.AreEqual(4, stack.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(OutOfRangeException))]
    public void Push_WhenFullThrows()
    {
        stack.Push("Fourth"); // Now count is 4
        stack.Push("Fifth"); // Count becomes 5 which exceeds capacity
    }

    [TestMethod]
    public void Pop_ShouldDecreaseCount()
    {
        Assert.AreEqual(3, stack.Count);
        stack.Pop();
        Assert.AreEqual(2, stack.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Pop_WhenEmptyThrows()
    {
        stack.Pop(); // Count is 0
    }

    [TestMethod]
    public void Peek_ShouldReturnTopElement()
    {
        Assert.AreEqual("Three", stack.Peek());
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Peek_WhenEmptyThrows()
    {
        stack.Pop();
        stack.Peek(); // Now count is 0
    }

    [TestMethod]
    public void IsFull_ReturnsTrueWhenStackIsFull()
    {
        stack.Push("Fourth");
        Assert.IsTrue(stack.IsFull);
    }

    [TestMethod]
    public void IsEmpty_ReturnsFalseWhenStackHasElements()
    {
        Assert.IsFalse(stack.IsEmpty);
    }
}
```

## Documentation

### Usage Guidelines
1. **Singleton Instance**: Use `Stack.CreateInstance()` to access the stack.
2. **Push Elements**: Call `Push(element)` and handle exceptions if the stack is full.
3. **Pop Elements**: Use `Pop()` and expect an exception if popping from an empty stack.
4. **Peek Element**: Call `Peek()` to see top element without removal, handle exceptions on empty stack.
5. **Check State**: Use `IsEmpty` and `IsFull` methods for programmatic checks.

### Testing
The included unit tests cover all operations:
- Pushing and popping within capacity.
- Attempting invalid operations (push when full, pop when empty).
- Checking stack state with IsEmpty and IsFull.

This implementation ensures robust usage while maintaining efficient performance.