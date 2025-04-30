using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class IsFullOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(2);
        }

        [TestMethod]
        public void IsFull_ReturnsFalse_WhenNewlyCreated()
        {
            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_ReturnsFalse_AfterPushingOneElement()
        {
            stack.Push(10);

            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_ReturnsTrue_AfterPushingAllElements()
        {
            stack.Push(10);
            stack.Push(20);

            Assert.IsTrue(stack.IsFull());
        }
    }
}