using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class PopOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
        }

        [TestMethod]
        public void Pop_RemovesElementFromTop_WhenNotEmpty()
        {
            var resultTuple = (topValue: stack.Pop(), topIndex: stack.Top);

            Assert.AreEqual(30, resultTuple.topValue);
            Assert.AreEqual(1, resultTuple.topIndex);
        }

        [TestMethod]
        public void Pop_RemovesMultipleElementsFromTop_WhenNotEmpty()
        {
            var firstPopResult = stack.Pop();
            var secondPopResult = stack.Pop();

            Assert.AreEqual(30, firstPopResult);
            Assert.AreEqual(20, secondPopResult);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void Pop_ThrowsException_WhenEmpty()
        {
            stack.Pop();
            stack.Pop();
            stack.Pop();

            try
            {
                stack.Pop();
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Stack is empty", ex.Message);
            }
        }
    }
}