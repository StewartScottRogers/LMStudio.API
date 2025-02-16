using System;
using System.Collections.Generic;

namespace StackLibrary
{
    public record StackRecord<T>
    {
        private T? Head { get; set; }
        private int Count { get; }
    }

    public interface IStack<T>
    {
        void Push(T element);
        T? Pop();
        bool IsEmpty();
        bool IsFull();
        T? Peek();
    }

    public class StackImpl<T> : IStack<T>
    {
        private StackRecord<T> _stack;

        public StackImpl()
        {
            _stack = new StackRecord<T>();
        }

        public void Push(T element)
        {
            if (_stack.Count >= _stack.Head is not null ? (int)_stack.Head + 1 : 0)
            {
                throw new InvalidOperationException("Stack is Full");
            }
            
            _stack.Head = element;
            _stack.Count++;
        }

        public T? Pop()
        {
            if (_stack.IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }

            var result = _stack.Head;
            _stack.Head = default;
            _stack.Count--;
            return result;
        }

        public bool IsEmpty()
        {
            return _stack.Head == default && _stack.Count == 0;
        }

        public bool IsFull()
        {
            int capacity = typeof(T).IsValueType ? (int)Math.Pow(2, Math.Log10(MaxValue)) : MaxValue;
            return _stack.Count >= capacity;
        }

        public T? Peek()
        {
            if (_stack.IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return _stack.Head;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTests
{
    [TestClass]
    public class StackTests<T>
    {
        private IStack<T> _stack;

        public StackTests()
        {
            _stack = new StackImpl<T>();
        }

        [TestInitialize]
        public void InitializeStack()
        {
            _stack = new StackImpl<T>();
        }

        [TestMethod]
        public void TestPush()
        {
            var stack = new StackRecord<T>(_stack);
            int initialCount = _stack.Count;

            _stack.Push(1);
            Assert.AreNotEqual(initialCount, _stack.Count);

            _stack.Push("Test");
            Assert.AreEqual(initialCount + 2, _stack.Count);
        }

        [TestMethod]
        public void TestPop()
        {
            var stack = new StackRecord<T>(_stack);
            int initialCount = _stack.Count;

            _stack.Push(1);
            _stack.Push("Test");

            var result = _stack.Pop();
            
            Assert.AreEqual(result, 1);
            Assert.AreNotEqual(initialCount, _stack.Count);

            var finalResult = _stack.Pop();
            Assert.AreEqual("Test", finalResult);
            Assert.AreEqual(initialCount, _stack.Count);
        }

        [TestMethod]
        public void TestPeek()
        {
            _stack.Push(1);
            
            var peekResult = _stack.Peek();
            Assert.AreEqual(1, peekResult);

            _stack.Push("Test");
            var another PeekResult = _stack.Peek();
            Assert.AreEqual("Test", another PeekResult);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(_stack.IsEmpty());
            
            _stack.Push(1);
            Assert.IsFalse(_stack.IsEmpty());
        }

        [TestMethod]
        public void TestIsFull()
        {
            if (typeof(T) == typeof(int))
            {
                int maxInt = int.MaxValue;
                int capacity = (int)Math.Pow(2, Math.Log10(maxInt)) + 1;
                _stack.Push(1);
                
                for (int i = 0; i < capacity - 1; i++)
                {
                    _stack.Push(i);
                }

                Assert.IsTrue(_stack.IsFull());
            }
        }
    }
}