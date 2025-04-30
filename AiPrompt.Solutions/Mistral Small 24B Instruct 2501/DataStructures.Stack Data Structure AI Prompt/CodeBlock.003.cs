using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackImplementationTests
    {
        private readonly IStackOperations<int> stack;

        public StackImplementationTests()
        {
            this.stack = new Implementations.StackImplementation<int>(3);
        }

        [TestMethod]
        public void IsEmpty_ShouldReturnTrue_WhenStackIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty, "The stack should be empty.");
        }

        [TestMethod]
        public void Push_ShouldAddItemToTopOfStack()
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty, "The stack should not be empty after pushing an item.");
            Assert.AreEqual(1, stack.Peek(), "The top of the stack should be 1.");
        }

        [TestMethod]
        public void Pop_ShouldRemoveItemFromTopOfStack()
        {
            stack.Push(2);
            var resultTuple = stack.PopTuple();

            Assert.IsTrue(stack.IsEmpty, "The stack should be empty after popping the last item.");
            Assert.AreEqual(2, resultTuple.Value, "The popped value should be 2.");
        }

        [TestMethod]
        public void Peek_ShouldReturnTopItemWithoutRemoving()
        {
            stack.Push(3);

            var peekValue = stack.Peek();

            Assert.IsFalse(stack.IsEmpty, "The stack should not be empty after peaking an item.");
            Assert.AreEqual(3, peekValue, "The top of the stack should still be 3.");
        }

        [TestMethod]
        public void IsFull_ShouldReturnTrue_WhenStackIsFull()
        {
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Assert.IsTrue(stack.IsFull, "The stack should be full.");
        }

        [TestMethod]
        public void Push_ShouldThrowException_WhenStackIsFull()
        {
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);

            var exception = Assert.ThrowsException<InvalidOperationException>(() => stack.Push(10));

            Assert.AreEqual("The stack is full.", exception.Message, "Pushing to a full stack should throw InvalidOperationException.");
        }

        [TestMethod]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => stack.PopTuple());

            Assert.AreEqual("The stack is empty.", exception.Message, "Popping from an empty stack should throw InvalidOperationException.");
        }
    }
}