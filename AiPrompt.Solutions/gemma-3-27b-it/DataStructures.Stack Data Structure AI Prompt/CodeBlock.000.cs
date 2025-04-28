// Solution File: StackLibrary.sln

// Project File: StackLibrary.csproj
// <Project Sdk="Microsoft.NET.Sdk">
//   <PropertyGroup>
//     <TargetFramework>net9.0</TargetFramework>
//     <ImplicitUsings>disable</ImplicitUsings>
//     <Nullable>disable</Nullable>
//   </PropertyGroup>
// </Project>

// File: IStackInterface.cs
namespace StackLibrary
{
    public interface IStackInterface
    {
        bool Push(int data);
        int Pop();
        bool IsEmpty();
        bool IsFull();
        int Peek();
    }
}

// File: StackClass.cs
namespace StackLibrary
{
    public class StackClass : IStackInterface
    {
        private readonly int[] stackArray;
        private int top;
        private readonly int capacity;

        public StackClass(int size)
        {
            capacity = size;
            stackArray = new int[capacity];
            top = -1; // Initialize top to -1 for an empty stack.
        }

        public bool Push(int data)
        {
            // Check if the stack is full.
            if (IsFull())
            {
                return false; // Stack overflow.
            }

            top++;
            stackArray[top] = data;
            return true;
        }

        public int Pop()
        {
            // Check if the stack is empty.
            if (IsEmpty())
            {
                throw new System.InvalidOperationException("Stack is empty."); // Stack underflow.
            }

            int poppedValue = stackArray[top];
            top--;
            return poppedValue;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == capacity - 1;
        }

        public int Peek()
        {
            // Check if the stack is empty.
            if (IsEmpty())
            {
                throw new System.InvalidOperationException("Stack is empty.");
            }

            return stackArray[top];
        }
    }
}

// File: StackUnitTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackUnitTests
    {
        [TestMethod]
        public void PushAndPop_ValidData()
        {
            // Arrange
            StackClass stack = new StackClass(5);
            stack.Push(10);
            stack.Push(20);

            // Act & Assert
            Assert.AreEqual(20, stack.Pop());
            Assert.AreEqual(10, stack.Pop());
        }

        [TestMethod]
        public void IsEmpty_InitialState()
        {
            // Arrange
            StackClass stack = new StackClass(5);

            // Act & Assert
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_AfterPop()
        {
            // Arrange
            StackClass stack = new StackClass(5);
            stack.Push(10);
            stack.Pop();

            // Act & Assert
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_WhenCapacityReached()
        {
            // Arrange
            StackClass stack = new StackClass(3);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Act & Assert
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_BeforeCapacityReached()
        {
            // Arrange
            StackClass stack = new StackClass(3);
            stack.Push(10);
            stack.Push(20);

            // Act & Assert
            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void Peek_ValidData()
        {
            // Arrange
            StackClass stack = new StackClass(5);
            stack.Push(10);
            stack.Push(20);

            // Act & Assert
            Assert.AreEqual(20, stack.Peek());
            Assert.AreEqual(20, stack.Peek()); // Check peek doesn't remove element
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Peek_EmptyStack()
        {
            // Arrange
            StackClass stack = new StackClass(5);

            // Act
            stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Pop_EmptyStack()
        {
            // Arrange
            StackClass stack = new StackClass(5);

            // Act
            stack.Pop();
        }

        [TestMethod]
        public void Push_FullStackReturnsFalse()
        {
            //Arrange
            StackClass stack = new StackClass(2);
            stack.Push(10);
            stack.Push(20);

            //Act & Assert
            Assert.IsFalse(stack.Push(30));
        }
    }
}