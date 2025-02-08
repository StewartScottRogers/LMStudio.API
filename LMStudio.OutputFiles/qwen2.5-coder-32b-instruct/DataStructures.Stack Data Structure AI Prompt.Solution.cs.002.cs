using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDataStructureLibrary;

namespace StackDataStructureTests
{
    [TestClass]
    public class StackTests
    {
        private IStack<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<int>(5);
        }

        [TestMethod]
        public void Push_AddsElementToStack()
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        public void Pop_ReturnsTopElementAndRemovesIt()
        {
            stack.Push(2);
            int topElement = stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(2, topElement);
        }

        [TestMethod]
        public void Peek_ReturnsTopElementWithoutRemovingIt()
        {
            stack.Push(3);
            int topElement = stack.Peek();

            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(3, topElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowsWhenStackIsEmpty()
        {
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ThrowsWhenStackIsEmpty()
        {
            stack.Peek();
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrueForNewStack()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ReturnsFalseWhenCapacityNotReached()
        {
            for (int i = 0; i < 4; i++)
                stack.Push(i);

            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_ReturnsTrueWhenCapacityIsReached()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);

            Assert.IsTrue(stack.IsFull());
        }
    }
}