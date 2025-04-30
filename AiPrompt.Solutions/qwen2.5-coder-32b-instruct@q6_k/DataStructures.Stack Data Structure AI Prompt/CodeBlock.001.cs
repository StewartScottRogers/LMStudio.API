using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackLibrary.Tests
{
    [TestClass]
    public class CustomStackTests
    {
        private readonly CustomStack<int> stack;

        public CustomStackTests()
        {
            stack = new CustomStack<int>(5);
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_WhenStackIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ReturnsFalse_WhenStackIsNotFull()
        {
            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void Push_AddsItemToStack()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowsException_WhenStackIsEmpty()
        {
            stack.Pop();
        }

        [TestMethod]
        public void Peek_ReturnsTopItemWithoutRemovingIt()
        {
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(1, stack.stackList.Count);
        }

        [TestMethod]
        public void IsFull_ReturnsTrue_WhenStackIsFull()
        {
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_ThrowsException_WhenStackIsFull()
        {
            for (int i = 0; i <= 5; i++)
            {
                stack.Push(i);
            }
        }
    }
}