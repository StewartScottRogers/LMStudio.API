using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDataStructure;

namespace Tests
{
    [TestClass]
    public class StackTests
    {
        private readonly IStack<int> stack = new StackClass<int>();

        /// <summary>
        /// Tests the Push and Pop methods.
        /// </summary>
        [TestMethod]
        public void TestPushAndPop()
        {
            stack.Push(1);
            var value = stack.Pop();
            Assert.AreEqual(1, value);

            stack.Push(2);
            value = stack.Pop();
            Assert.AreEqual(2, value);
        }

        /// <summary>
        /// Tests the Peek method.
        /// </summary>
        [TestMethod]
        public void TestPeek()
        {
            stack.Push(1);
            var value = stack.Peek();
            Assert.AreEqual(1, value);
        }

        /// <summary>
        /// Tests the IsEmpty method.
        /// </summary>
        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Tests the IsFull method.
        /// </summary>
        [TestMethod]
        public void TestIsFull()
        {
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull());
        }

    }
}