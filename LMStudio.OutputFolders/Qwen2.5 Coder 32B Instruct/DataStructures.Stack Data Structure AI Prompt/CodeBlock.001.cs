using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        private readonly int stackCapacity = 3;
        private Stack<int> stack;

        [TestInitialize]
        public void TestInitialize()
        {
            stack = new Stack<int>(stackCapacity);
        }

        [TestMethod]
        public void Push_AddsElementToStack()
        {
            var elementToAdd = 1;

            stack.Push(elementToAdd);

            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
        {
            stack.Pop();
        }

        [TestMethod]
        public void Pop_RemovesTopElementFromStack()
        {
            stack.Push(1);
            stack.Push(2);

            var poppedElement = stack.Pop();

            Assert.AreEqual(2, poppedElement);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        public void Peek_ReturnsTopElementWithoutRemovingIt()
        {
            stack.Push(1);
            stack.Push(2);

            var topElement = stack.Peek();

            Assert.AreEqual(2, topElement);
            Assert.AreEqual(2, stack.Peek());
        }

        [TestMethod]
        public void IsEmpty_ChecksIfStackIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ChecksIfStackIsFull()
        {
            for (int i = 0; i < stackCapacity; i++)
                stack.Push(i);

            Assert.IsTrue(stack.IsFull());

            stack.Pop();

            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_OnFullStack_ThrowsInvalidOperationException()
        {
            for (int i = 0; i < stackCapacity + 1; i++)
                stack.Push(i);
        }
    }
}