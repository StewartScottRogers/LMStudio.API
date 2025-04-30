using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        private const int Capacity = 3;
        private IStack<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            this.stack = new Stack<int>(Capacity);
        }

        [TestMethod]
        public void Push_AddsElementToStack()
        {
            // Arrange and Act
            stack.Push(1);

            // Assert
            Assert.AreEqual(1, stack.Peek());
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void Pop_RemovesTopElementFromStack()
        {
            // Arrange
            stack.Push(1);
            stack.Push(2);

            // Act
            var poppedValue = stack.Pop();

            // Assert
            Assert.AreEqual(2, poppedValue);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrueWhenStackIsEmpty()
        {
            // Arrange and Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsFull_ReturnsTrueWhenStackIsFull()
        {
            // Arrange
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            bool isFull = stack.IsFull();

            // Assert
            Assert.IsTrue(isFull);
        }

        [TestMethod]
        public void Peek_ReturnsTopElementWithoutRemovingIt()
        {
            // Arrange
            stack.Push(1);

            // Act
            var topValue = stack.Peek();

            // Assert
            Assert.AreEqual(1, topValue);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_ThrowsExceptionWhenStackIsFull()
        {
            // Arrange
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act & Assert
            stack.Push(4);  // This should throw InvalidOperationException
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowsExceptionWhenStackIsEmpty()
        {
            // Arrange and Act & Assert
            stack.Pop();  // This should throw InvalidOperationException
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ThrowsExceptionWhenStackIsEmpty()
        {
            // Arrange and Act & Assert
            stack.Peek();  // This should throw InvalidOperationException
        }
    }
}