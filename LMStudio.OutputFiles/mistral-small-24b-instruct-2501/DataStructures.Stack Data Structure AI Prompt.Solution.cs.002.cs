using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        private readonly IStack<int> stack = new Stack<int>(5);

        // Test pushing elements onto the stack.
        [TestMethod]
        public void PushTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
        }

        // Test popping elements from the stack.
        [TestMethod]
        public void PopTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        // Test checking if the stack is empty.
        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        // Test checking if the stack is full.
        [TestMethod]
        public void IsFullTest()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);

            Assert.IsTrue(stack.IsFull());
        }

        // Test peeking at the top element.
        [TestMethod]
        public void PeekTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(2, stack.Pop());  // Should not change the peek value
        }

        // Test bounding conditions.
        [TestMethod]
        public void BoundingConditionsTest()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);

            Assert.ThrowsException<InvalidOperationException>(() => stack.Push(6));

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }
    }
}