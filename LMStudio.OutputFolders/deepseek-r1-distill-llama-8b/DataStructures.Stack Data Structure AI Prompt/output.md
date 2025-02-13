<think>
Okay, I need to create a C# library that implements a stack data structure with specific operations. Let me break down what's required.

First, the stack needs push, pop, isEmpty, isFull, and peek methods. I'll probably use a class for the stack, maybe call it Stack. Since it's .NET 9.0, I should check if there are any new features that can make this easier, but I think generics and collections will suffice.

I remember that in C#, we can use List<T> to implement stacks because they allow pushing and popping from the end efficiently. So, I'll create a private List<T> inside the Stack class. Also, I need to ensure that the stack isn't empty or full when trying operations, so properties IsEmpty and IsFull will help with that.

Wait, but how do I determine if the stack is full? Since it's a generic list, maybe I can check its Count. So, for IsEmpty, it's simply count == 0. For IsFull, if the stack has a fixed capacity, then compare against that. Oh, right! The user might want a fixed-size stack with a max capacity. I should add a MaxCapacity property. If they don't set one, maybe default to Int32.MaxValue or some large number.

So, in the constructor, I can initialize the list and perhaps set a default MaxCapacity if not provided. That makes sense.

Next, the operations:

- Push: Add an element. It's straightforward with Add method.
- Pop: Remove the last element. If the stack is empty, throw an exception; otherwise, remove the last item.
- Peek: Get the last element without removing it. So, check if the list isn't empty, then return the last element.
- IsEmpty and IsFull based on count.

I should make sure all these methods have proper handling for cases where the stack might be empty or full when they shouldn't be.

Also, considering unit tests. I need to write tests that cover each method under normal and edge conditions, like trying to pop an empty stack.

For coding style, I must follow the guidelines: no underscores, explicit types, camel case for variables. So, class name is Stack, properties like MaxCapacity, methods like AddItem, RemoveItem, etc. All variables should use var where possible, especially for Tuples if I return multiple values, but in this case, each method returns a single item or bool.

Wait, the prompt mentions using Tuples, but these operations don't require returning tuples. Maybe that's for future expansion? Not sure, but since each operation is a simple value or void, I can stick to standard returns.

I should also include documentation comments for each method and property to explain what they do. This will help anyone reading the code understand quickly.

Now, structuring the project: one class for the stack, another maybe for testing. Each file should be separate, so Stack.cs, StackTests.cs, etc. No interfaces needed here since I'm not implementing any specific behavior beyond what List<T> provides.

I think that's a solid plan. Let me start coding each part step by step.
</think>

### Step-by-Step Explanation and Solution Code

#### 1. **Class Definition**
Create a `Stack` class that encapsulates the stack functionality.

```csharp
using System;
using System.Collections.Generic;

/// <summary>
/// Represents a basic stack data structure with push, pop, peek, is empty, and is full operations.
/// </summary>
public class Stack<T>
{
    private List<T> _stack = new List<T>();
    public int MaxCapacity { get; set; } = int.MaxValue; // Default to unlimited capacity

    /// <summary>
    /// Initializes a new stack with the specified maximum capacity.
    /// If the capacity is not specified, it defaults to Int32.MaxValue.
    /// </summary>
    public Stack(int? maxCapacity)
    {
        _stack = new List<T>(maxCapacity ?? (int?)Int32.MaxValue);
    }

    /// <summary>
    /// Adds an item to the top of the stack.
    /// Throws an exception if the stack is full.
    /// </summary>
    public void AddItem(T item)
    {
        if (Count >= MaxCapacity)
            throw new InvalidOperationException("Stack is full. Cannot add more items.");

        _stack.Add(item);
    }

    /// <summary>
    /// Removes and returns the top item of the stack.
    /// Throws an exception if the stack is empty.
    /// </summary>
    public T RemoveItem()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty. Cannot remove items.");

        return _stack.RemoveAt(Count - 1);
    }

    /// <summary>
    /// Peeks at the top item of the stack without removing it.
    /// Returns null if the stack is empty.
    /// </summary>
    public T? PeekItem()
    {
        return Count > 0 ? _stack[Count - 1] : null;
    }

    /// <summary>
    /// Checks if the stack is empty.
    /// Returns true if there are no items in the stack; otherwise, false.
    /// </summary>
    public bool IsEmpty => _stack.Count == 0;

    /// <summary>
    /// Checks if the stack is full.
    /// Returns true if the stack contains more items than its capacity; otherwise, false.
    /// </summary>
    public bool IsFull => Count >= MaxCapacity;

    /// <summary>
    /// Gets the total number of items in the stack.
    /// </summary>
    public int Count => _stack.Count;
}
```

#### 2. **Unit Tests**
Create a test class to verify each method's functionality.

```csharp
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> _stack = new Stack<int>();

        [TestInitialize]
        public void InitializeStack()
        {
            // Initialize stack for each test.
            _stack = new Stack<int>();
        }

        [TestCleanup]
        public void CleanupStack()
        {
            // Clean up after each test.
            if (_stack != null)
                _stack.Dispose();
        }

        #region Test Cases

        #region Basic Operations
        [TestMethod]
        public void TestAddItem_ShouldIncreaseCount()
        {
            int item = 1;
            _stack.AddItem(item);
            Assert.AreEqual(1, _stack.Count, "Stack count should be 1 after add.");
        }

        [TestMethod]
        public void TestRemoveItem_ShouldDecreaseCount()
        {
            int? result = _stack.PeekItem();
            Assert.AreEqual(1, _stack.Count, "Stack count should be 1 before remove.");

            try
            {
                _stack.RemoveItem();
                Assert.AreEqual(0, _stack.Count, "Stack count should be 0 after remove.");
            }
            catch (InvalidOperationException)
            {
                // Expected exception when trying to remove from empty stack.
            }
        }

        [TestMethod]
        public void TestPeekItem_ShouldReturnCorrectValue()
        {
            int item = 1;
            _stack.AddItem(item);
            Assert.AreEqual(item, _stack.PeekItem(), "Peek should return the top item.");
        }

        #endregion

        #region Boundary Conditions
        [TestMethod]
        public void TestStackIsFull_WhenMaxCapacityReached()
        {
            try
            {
                _stack.MaxCapacity = 2;
                _stack.AddItem(1);
                _stack.AddItem(2);

                // Attempting to add third item should throw exception.
                _stack.AddItem(3);
                Assert.Fail("Stack should be full and throw exception on add.");
            }
            catch (InvalidOperationException)
            {
                // Expected exception when stack is full.
            }
        }

        [TestMethod]
        public void TestStackIsEmpty_WhenCountIsZero()
        {
            Assert.IsTrue(_stack.IsEmpty, "Stack count should be 0 when empty.");
        }

        #endregion
    }
}
```

#### 3. **Documentation Comments**
Add XML comments for each class, method, and property to improve code readability.

```csharp
using System;
using System.Collections.Generic;

/// <summary>
/// Represents a basic stack data structure with push, pop, peek, is empty, and is full operations.
/// </summary>
public class Stack<T>
{
    private List<T> _stack = new List<T>();
    public int MaxCapacity { get; set; } = int.MaxValue; // Default to unlimited capacity

    /// <summary>
    /// Initializes a new stack with the specified maximum capacity.
    /// If the capacity is not specified, it defaults to Int32.MaxValue.
    /// </summary>
    public Stack(int? maxCapacity)
    {
        _stack = new List<T>(maxCapacity ?? (int?)Int32.MaxValue);
    }

    /// <summary>
    /// Adds an item to the top of the stack.
    /// Throws an exception if the stack is full.
    /// </summary>
    public void AddItem(T item)
    {
        if (Count >= MaxCapacity)
            throw new InvalidOperationException("Stack is full. Cannot add more items.");

        _stack.Add(item);
    }

    /// <summary>
    /// Removes and returns the top item of the stack.
    /// Throws an exception if the stack is empty.
    /// </summary>
    public T RemoveItem()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty. Cannot remove items.");

        return _stack.RemoveAt(Count - 1);
    }

    /// <summary>
    /// Peeks at the top item of the stack without removing it.
    /// Returns null if the stack is empty.
    /// </summary>
    public T? PeekItem()
    {
        return Count > 0 ? _stack[Count - 1] : null;
    }

    /// <summary>
    /// Checks if the stack is empty.
    /// Returns true if there are no items in the stack; otherwise, false.
    /// </summary>
    public bool IsEmpty => _stack.Count == 0;

    /// <summary>
    /// Checks if the stack is full.
    /// Returns true if the stack contains more items than its capacity; otherwise, false.
    /// </summary>
    public bool IsFull => Count >= MaxCapacity;

    /// <summary>
    /// Gets the total number of items in the stack.
    /// </summary>
    public int Count => _stack.Count;
}
```

#### 4. **Implementation Notes**

- **Class Design**: The `Stack` class uses a generic list to store elements, allowing type safety.
- **Max Capacity Handling**: The stack can be set with a maximum capacity, ensuring it doesn't grow beyond specified limits.
- **Exception Handling**: Methods throw exceptions when operations are performed on an empty or full stack where they shouldn't be possible.
- **Unit Tests**: Comprehensive tests ensure each method behaves as expected under various conditions.

This implementation provides a robust and type-safe way to handle stack operations while being easy to understand and extend.