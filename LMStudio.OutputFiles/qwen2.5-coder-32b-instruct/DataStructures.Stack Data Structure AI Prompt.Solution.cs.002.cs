using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDataStructure;

namespace StackDataStructure.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const int StackCapacity = 5;
        private readonly IStack<int> stack;

        public UnitTest1()
        {
            stack = new Stack<int>(StackCapacity);
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_WhenStackIsInitialized()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void Push_IncreasesCount()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
            stack.Push(2);
            Assert.AreEqual(2, ((Stack<int>)stack).Items.Count);
        }

        [TestMethod]
        public void Peek_ReturnsTopElement_WithoutRemovingIt()
        {
            stack.Push(5);
            var topItem = stack.Peek();
            Assert.AreEqual(5, topItem);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_OnEmptyStackThrows()
        {
            stack.Pop();
        }

        [TestMethod]
        public void Pop_ReturnsTopElement()
        {
            stack.Push(3);
            var item = stack.Pop();
            Assert.AreEqual(3, item);
        }

        [TestMethod]
        public void IsFull_ReturnsTrue_WhenCapacityIsReached()
        {
            for (int i = 0; i < StackCapacity; i++)
                stack.Push(i);

            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_OnFullStackThrows()
        {
            for (int i = 0; i <= StackCapacity; i++)
                stack.Push(i);
        }
    }
}