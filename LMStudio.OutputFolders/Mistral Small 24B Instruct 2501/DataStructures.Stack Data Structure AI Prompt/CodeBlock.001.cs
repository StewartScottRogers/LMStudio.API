using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        private Stack<int> stack;

        [TestInitialize]
        public void Setup()
        {
            stack = new Stack<int>();
        }

        [TestMethod]
        public void TestPushAndPop()
        {
            stack.Push(1);
            var (success, element) = stack.PopElementTuple;
            Assert.IsTrue(success);
            Assert.AreEqual(1, element);

            stack.Push(2);
            stack.Push(3);
            var (_, poppedElement) = stack.PopElementTuple;
            Assert.AreEqual(3, poppedElement);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());

        }

        [TestMethod]
        public void TestPeek()
        {
            stack.Push(42);
            var (success, peekedElement) = stack.PeekElementTuple;
            Assert.IsTrue(success);
            Assert.AreEqual(42, peekedElement);

            // Peeking again should still return 42
            var (_, secondPeekedElement) = stack.PeekElementTuple;
            Assert.AreEqual(42, secondPeekedElement);
        }
    }
}