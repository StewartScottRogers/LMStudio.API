using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStackProject.Models;

namespace MyStackProject.UnitTests
{
    [TestClass]
    public class MyStackUnitTest
    {
        private readonly MyStack<int> stack = new(5);

        [TestMethod]
        public void Push_ShouldAddItemToStack()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        public void Pop_ShouldRemoveItemFromStack()
        {
            stack.Push(1);
            var item = stack.Pop();
            Assert.AreEqual(1, item);
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_ShouldReturnTrueForNewStack()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ShouldReturnFalseWhenStackIsNotFull()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsFull(5));
        }

        [TestMethod]
        public void IsFull_ShouldReturnTrueWhenStackIsFull()
        {
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull(5));
        }

        [TestMethod]
        public void Peek_ShouldReturnTopItemWithoutRemovingIt()
        {
            stack.Push(1);
            var item = stack.Peek();
            Assert.AreEqual(1, item);
            Assert.AreEqual(1, stack.Peek());
        }
    }
}