using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackTests
{
    [TestClass]
    public class StackTests
    {
        private readonly StackLibrary.Stack<int> stack = new StackLibrary.Stack<int>();

        [TestMethod]
        public void Push_AddsItemToStack()
        {
            stack.Push(5);
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(5, stack.Peek());
        }

        [TestMethod]
        public void Pop_RemovesTopItemFromStack()
        {
            stack.Push(5);
            var item = stack.Pop();
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(5, item);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowsExceptionOnEmptyStack()
        {
            stack.Pop(); // This should throw an InvalidOperationException
        }

        [TestMethod]
        public void Peek_ReturnsTopItemWithoutRemovingIt()
        {
            stack.Push(5);
            var item = stack.Peek();
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(5, item);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ThrowsExceptionOnEmptyStack()
        {
            stack.Peek(); // This should throw an InvalidOperationException
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrueForNewStack()
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void IsFull_ReturnsFalseForUnderCapacityStack()
        {
            for (int i = 0; i < stack.Capacity - 1; i++)
            {
                stack.Push(i);
            }
            Assert.IsFalse(stack.IsFull);
        }

        [TestMethod]
        public void IsFull_ReturnsTrueWhenCapacityIsReached()
        {
            for (int i = 0; i < stack.Capacity; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_ThrowsExceptionOnFullStack()
        {
            for (int i = 0; i < stack.Capacity + 1; i++) // Adding one more item than the capacity
            {
                stack.Push(i); // This should throw an InvalidOperationException on last push
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            while (!stack.IsEmpty)
            {
                stack.Pop();
            }
        }
    }
}