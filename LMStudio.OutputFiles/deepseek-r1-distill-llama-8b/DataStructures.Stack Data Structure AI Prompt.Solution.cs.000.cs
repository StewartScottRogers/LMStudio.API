using System;
using System.Collections.Generic;
using System.Text;

namespace StackImplementation
{
    public class StackDataStructure
    {
        private int[] _stackElements = new int[0];
        private int _size;
        public int Size => _size;
        public int CurrentCount { get; private set; }

        public StackDataStructure(int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than zero.");
            
            _size = size;
            _stackElements = new int[size];
            CurrentCount = 0;
        }

        public void Push(int element)
        {
            if (CurrentCount >= Size)
                throw new InvalidOperationException("Stack is full.");

            _stackElements[CurrentCount] = element;
            CurrentCount++;
        }

        public int Pop()
        {
            if (CurrentCount == 0)
                throw new InvalidOperationException("Stack is empty.");

            return _stackElements[--CurrentCount];
        }

        public int Peek()
        {
            if (CurrentCount == 0)
                throw new InvalidOperationException("Stack is empty.");

            return _stackElements[CurrentCount - 1];
        }

        public bool IsEmpty => CurrentCount == 0;

        public bool IsFull => CurrentCount == Size;
    }

    public class StackTests
    {
        [TestClass]
        public class PushOperations
        {
            private readonly StackDataStructure stack = new StackDataStructure(5);

            [TestInitialize]
            public void InitializeStack()
            {
                stack.Push(10);
                stack.Push(20);
                stack.Push(30);
                stack.Push(40);
                stack.Push(50);
            }

            [TestMethod]
            public void PushWhenStackIsEmpty_ThrowsException()
            {
                Assert.Throws<InvalidOperationException>(() => stack.Push(1));
            }

            [TestMethod]
            public void PushWhenStackIsFull_ThrowsException()
            {
                try
                {
                    stack.Push(60); // Stack size is 5, already 5 elements
                }
                catch (InvalidOperationException e)
                {
                    Assert.AreEqual("Stack is full.", e.Message);
                }
            }

            [TestMethod]
            public void PushWithDifferentSizes()
            {
                stack.Push(10);
                Assert.Equal(1, stack.CurrentCount);

                stack.Push(20);
                Assert.Equal(2, stack.CurrentCount);

                stack.Push(30);
                Assert.Equal(3, stack.CurrentCount);
            }
        }

        [TestClass]
        public class PopOperations
        {
            private readonly StackDataStructure stack = new StackDataStructure(3);

            [TestInitialize]
            public void InitializeStackWithElements()
            {
                stack.Push(10);
                stack.Push(20);
                stack.Push(30);
            }

            [TestMethod]
            public void PopWhenStackIsEmpty_ThrowsException()
            {
                Assert.Throws<InvalidOperationException>(() => stack.Pop()));
            }

            [TestMethod]
            public void PopRemovesCorrectElement()
            {
                stack.Push(40);
                int result = stack.Pop();
                Assert.Equal(40, result);
                Assert.Equal(2, stack.CurrentCount);
            }
        }

        [TestClass]
        public class PeekOperations
        {
            private readonly StackDataStructure stack = new StackDataStructure(4);

            [TestInitialize]
            public void InitializeStackWithElements()
            {
                stack.Push(10);
                stack.Push(20);
                stack.Push(30);
            }

            [TestMethod]
            public void PeekWhenStackIsEmpty_ThrowsException()
            {
                Assert.Throws<InvalidOperationException>(() => stack.Peek());
            }

            [TestMethod]
            public void PeekReturnsCorrectValue()
            {
                int top = stack.Peek();
                Assert.Equal(30, top);
                Assert.Equal(3, stack.CurrentCount);
            }
        }

        [TestClass]
        public class IsEmptyAndIsFullTests
        {
            private readonly StackDataStructure stack = new StackDataStructure(1);

            [TestMethod]
            public void NewStackIsEmpty()
            {
                Assert.IsTrue(stack.IsEmpty);
            }

            [TestMethod]
            public void StackWithOneElementIsNotEmpty()
            {
                stack.Push(5);
                Assert.IsFalse(stack.IsEmpty);
            }

            [TestMethod]
            public void FullStackIsFull()
            {
                stack.Push(5);
                Assert.IsTrue(stack.IsFull);
            }

            [TestMethod]
            public void NonFullStackIsNotFull()
            {
                stack.Push(5);
                if (!stack.IsFull)
                    Assert.Fail("Expected stack to be full, but it is not.");
            }
        }
    }
}