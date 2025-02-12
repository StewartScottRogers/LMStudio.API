using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System;

namespace DataStructures.UnitTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Push_ValidItem_AddsToStack()
        {
            var stack = new Stack<int>(5);
            stack.Push(10);
            Assert.AreEqual(10, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_FullStack_ThrowsException()
        {
            var stack = new Stack<int>(1);
            stack.Push(10);
            stack.Push(20); // This should throw an exception
        }

        [TestMethod]
        public void Pop_RemovesItemFromStack()
        {
            var stack = new Stack<int>(5);
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new Stack<int>(5);
            stack.Pop(); // This should throw an exception
        }

        [TestMethod]
        public void Peek_ReturnsTopItemWithoutRemovingIt()
        {
            var stack = new Stack<int>(5);
            stack.Push(10);
            Assert.AreEqual(10, stack.Peek());
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ThrowsException()
        {
            var stack = new Stack<int>(5);
            stack.Peek(); // This should throw an exception
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrueForNewStack()
        {
            var stack = new Stack<int>(5);
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ReturnsFalseForNewStack()
        {
            var stack = new Stack<int>(1);
            Assert.IsFalse(stack.IsFull());
        }
    }
}