using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStack;
using System;

namespace StackTests
{
    [TestClass]
    public class UnitTest1
    {
        private Stack stack;

        [TestInitialize]
        public void Setup()
        {
            stack = new Stack(5);
        }

        [TestMethod]
        public void TestPushPop()
        {
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopEmptyStack()
        {
            stack.Pop();
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void TestIsFull()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushFullStack()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);
            stack.Push(6);
        }

        [TestMethod]
        public void TestPeek()
        {
            stack.Push(22);
            Assert.AreEqual(22, stack.Peek());
            Assert.IsFalse(stack.IsEmpty()); // Ensure peek doesn't affect the stack being empty
        }
    }
}