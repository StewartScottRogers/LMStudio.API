using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestPushAndPeek()
        {
            var stack = new StackRecord<int>(3);
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
            Assert.IsFalse(stack.IsFull());

            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            Assert.IsFalse(stack.IsFull());

            stack.Push(3);
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        public void TestPop()
        {
            var stack = new StackRecord<int>(3);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());

            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void TestIsFull()
        {
            var stack = new StackRecord<int>(2);
            stack.Push(1);
            stack.Push(2);

            Assert.IsTrue(stack.IsFull());
            Assert.ThrowsException<InvalidOperationException>(() => stack.Push(3));
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            var stack = new StackRecord<int>(2);
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());

            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}