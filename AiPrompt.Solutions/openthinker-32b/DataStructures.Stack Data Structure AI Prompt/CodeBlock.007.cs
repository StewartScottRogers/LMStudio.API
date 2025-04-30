using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class PeekOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
        }

        [TestMethod]
        public void Peek_ReturnsTopElement_WhenNotEmpty()
        {
            stack.Push(10);

            var topValue = stack.Peek();

            Assert.AreEqual(10, topValue);
        }

        [TestMethod]
        public void Peek_DoesNotModifyStack_TopIndexRemainsSame()
        {
            stack.Push(10);
            var initialTopIndex = stack.Top;

            stack.Peek();
            var finalTopIndex = stack.Top;

            Assert.AreEqual(initialTopIndex, finalTopIndex);
        }

        [TestMethod]
        public void Peek_ThrowsException_WhenEmpty()
        {
            try
            {
                stack.Peek();
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Stack is empty", ex.Message);
            }
        }
    }
}