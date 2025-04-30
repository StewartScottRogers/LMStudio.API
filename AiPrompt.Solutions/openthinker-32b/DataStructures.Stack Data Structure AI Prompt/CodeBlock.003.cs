using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class PushOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
        }

        [TestMethod]
        public void Push_AddsElementToTop_WhenNotEmpty()
        {
            stack.Push(10);
            var resultTuple = (topValue: stack.Peek(), topIndex: stack.Top);

            Assert.AreEqual(10, resultTuple.topValue);
            Assert.AreEqual(0, resultTuple.topIndex);
        }

        [TestMethod]
        public void Push_AddsMultipleElementsToTop_WhenNotEmpty()
        {
            stack.Push(10);
            stack.Push(20);
            var resultTuple = (topValue: stack.Peek(), topIndex: stack.Top);

            Assert.AreEqual(20, resultTuple.topValue);
            Assert.AreEqual(1, resultTuple.topIndex);
        }

        [TestMethod]
        public void Push_ThrowsException_WhenFull()
        {
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            try
            {
                stack.Push(40);
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Stack is full", ex.Message);
            }
        }
    }
}