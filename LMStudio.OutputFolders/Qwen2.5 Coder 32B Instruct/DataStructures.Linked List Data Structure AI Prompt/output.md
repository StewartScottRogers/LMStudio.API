To create a .NET 9.0 solution that meets your requirements, we will need to follow these guidelines carefully. However, it's important to note that as of now (2023), .NET 9.0 does not exist and Visual Studio 2022 does not support it yet. For the purpose of this exercise, I'll create a solution with .NET 6.0, which is compatible with Visual Studio 2022.

Here's how you can structure your project:

### Solution Structure

1. **Solution Name**: LinkedListExample
2. **Projects**:
   - **LinkedListLibrary**
     - Contains the Linked List Data Structure implementation.
   - **UnitTests**
     - Contains unit tests for the Linked List Data Structure.

### Implementation Details

#### 1. LinkedListLibrary Project

- **Node.cs**

```csharp
namespace LinkedListLibrary;

public class Node
{
    public readonly int Value;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}
```

- **LinkedList.cs**

```csharp
namespace LinkedListLibrary;

public record LinkedListResultTuple(bool Success, string Message);

public class LinkedList
{
    private Node Head;

    public void InsertAtBeginning(int value)
    {
        var newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
    }

    public bool DeleteElement(int value)
    {
        if (Head == null) return false;

        if (Head.Value == value)
        {
            Head = Head.Next;
            return true;
        }

        Node current = Head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next == null) return false;

        current.Next = current.Next.Next;
        return true;
    }

    public LinkedListResultTuple SearchElement(int value)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Value == value)
                return new LinkedListResultTuple(true, "Element found.");
            current = current.Next;
        }
        return new LinkedListResultTuple(false, "Element not found.");
    }

    public string DisplayList()
    {
        var displayString = "";
        Node current = Head;
        while (current != null)
        {
            displayString += current.Value + " -> ";
            current = current.Next;
        }
        return displayString.TrimEnd(' ', '-');
    }
}
```

#### 2. UnitTests Project

- **LinkedListTests.cs**

```csharp
using LinkedListLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        private readonly LinkedList linkedList = new LinkedList();

        [TestInitialize]
        public void Setup()
        {
            linkedList.InsertAtBeginning(10);
            linkedList.InsertAtBeginning(20);
            linkedList.InsertAtBeginning(30);
        }

        [TestMethod]
        public void TestInsertAtBeginning()
        {
            linkedList.InsertAtBeginning(40);
            Assert.IsTrue(linkedList.DisplayList() == "40 -> 30 -> 20 -> 10");
        }

        [TestMethod]
        public void TestDeleteElementSuccess()
        {
            var result = linkedList.DeleteElement(20);
            Assert.IsTrue(result && linkedList.DisplayList() == "30 -> 10");
        }

        [TestMethod]
        public void TestDeleteElementFailure()
        {
            var result = linkedList.DeleteElement(50);
            Assert.IsFalse(result && linkedList.DisplayList() == "30 -> 20 -> 10");
        }

        [TestMethod]
        public void TestSearchElementSuccess()
        {
            var searchTuple = linkedList.SearchElement(20);
            Assert.IsTrue(searchTuple.Success && searchTuple.Message == "Element found.");
        }

        [TestMethod]
        public void TestSearchElementFailure()
        {
            var searchTuple = linkedList.SearchElement(50);
            Assert.IsFalse(searchTuple.Success && searchTuple.Message == "Element not found.");
        }
    }
}
```

### How to Build and Run

1. Open Visual Studio 2022.
2. Create a new Solution called `LinkedListExample`.
3. Add a Class Library project named `LinkedListLibrary` with the provided files.
4. Add a Unit Test Project named `UnitTests` with the provided test file.
5. Reference `LinkedListLibrary` in the `UnitTests` project.
6. Build and run your solution.

### Notes
- Replace all instances of `.NET 9.0` with `.NET 6.0` if you are following along.
- Ensure that the coding styles, naming conventions, and other guidelines are strictly followed.
- This example uses basic data types and constructs to fulfill the requirements without additional libraries or frameworks.

This setup provides a robust linked list implementation with unit tests covering insertion, deletion, and search functionalities.