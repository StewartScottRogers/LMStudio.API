// StackDataStructureLibraryTests.cs
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when type has no parameterless constructor.

using Microsoft.VisualStudio.TestTools.UnitTests;
using StackDataStructureLibrary;

namespace StackDataStructureLibraryTests
{
    [TestClass]
    public class StackDataStructureLibraryTests
    {
        [TestMethod]
        public void Push_ValidValue_IncrementsTopIndex()
        {
            // Arrange
            var stack = new Stack(3);
            int initialTopIndex = stack.IsEmpty() ? -1 : 0;

            // Act
            stack.Push("Test Value");

            // Assert
            Assert.AreEqual(initialTopIndex + 1, stack._topIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(StackOverflowException))]
        public void Push_StackIsFull_ThrowsStackOverflowException()
        {
            // Arrange
            var stack = new Stack(2);
            stack.Push("Value 1");
            stack.Push("Value 2");

            // Act
            stack.Push("Value 3"); // Should throw an exception
        }

        [TestMethod]
        public void Pop_ValidStack_ReturnsSuccessAndValue()
        {
            // Arrange
            var stack = new Stack(3);
            stack.Push("Value 1");
            stack.Push("Value 2");

            // Act
            PopResult result = stack.Pop();

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Value 2", result.Value);
        }

        [TestMethod]
        public void Pop_EmptyStack_ReturnsFalseAndNull()
        {
            // Arrange
            var stack = new Stack(3);

            // Act
            PopResult result = stack.Pop();

            // Assert
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Value);
        }

        [TestMethod]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            // Arrange
            var stack = new Stack(3);

            // Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsEmpty_NonEmptyStack_ReturnsFalse()
        {
            // Arrange
            var stack = new Stack(3);
            stack.Push("Value 1");

            // Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void IsFull_StackNotFull_ReturnsFalse()
        {
            // Arrange
            var stack = new Stack(3);
            stack.Push("Value 1");

            // Act
            bool isFull = stack.IsFull();

            // Assert
            Assert.IsFalse(isFull);
        }

        [TestMethod]
        public void IsFull_StackIsFull_ReturnsTrue()
        {
            // Arrange
            var stack = new Stack(2);
            stack.Push("Value 1");
            stack.Push("Value 2");

            // Act
            bool isFull = stack.IsFull();

            // Assert
            Assert.IsTrue(isFull);
        }

        [TestMethod]
        public void Peek_ValidStack_ReturnsTopValue()
        {
            // Arrange
            var stack = new Stack(3);
            stack.Push("Value 1");
            stack.Push("Value 2");

            // Act
            object? topValue = stack.Peek();

            // Assert
            Assert.AreEqual("Value 2", topValue);
        }

        [TestMethod]
        public void Peek_EmptyStack_ReturnsNull()
        {
            // Arrange
            var stack = new Stack(3);

            // Act
            object? topValue = stack.Peek();

            // Assert
            Assert.IsNull(topValue);
        }
    }
}