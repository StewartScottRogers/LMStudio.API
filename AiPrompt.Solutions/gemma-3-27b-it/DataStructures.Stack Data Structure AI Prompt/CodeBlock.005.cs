// Unit Test File - StackLibrary\UnitTest1.cs

using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackLibraryTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void IsEmpty_NewStack_ReturnsTrue()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsFull_NewStack_ReturnsFalse()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            bool isFull = stack.IsFull();

            // Assert
            Assert.IsFalse(isFull);
        }

        [TestMethod]
        public void Push_OneElement_IsEmptyReturnsFalse()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            stack.Push(10);

            // Assert
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void Push_FiveElements_IsFullReturnsTrue()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        public void Push_StackOverflow_ThrowsException()
        {
            // Arrange
            var stack = new Stack(2);

            // Act & Assert
            Assert.ThrowsException<StackOverflowException>(() =>
            {
                stack.Push(1);
                stack.Push(2);
                stack.Push(3); // Should throw an exception
            });
        }

        [TestMethod]
        public void Pop_OneElement_IsEmptyReturnsTrue()
        {
            // Arrange
            var stack = new Stack(5);
            stack.Push(10);

            // Act
            int poppedValue = stack.Pop();

            // Assert
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void Pop_StackUnderflow_ThrowsException()
        {
            // Arrange
            var stack = new Stack(5);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Pop(); // Should throw an exception
            });
        }

        [TestMethod]
        public void Peek_OneElement_ReturnsValue()
        {
            // Arrange
            var stack = new Stack(5);
            stack.Push(10);

            // Act
            int peekedValue = stack.Peek();

            // Assert
            Assert.AreEqual(10, peekedValue);
        }

        [TestMethod]
        public void Peek_StackUnderflow_ThrowsException()
        {
            // Arrange
            var stack = new Stack(5);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Peek(); // Should throw an exception
            });
        }
    }
}