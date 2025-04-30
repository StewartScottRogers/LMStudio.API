using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class IsEmptyOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_WhenNewlyCreated()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_ReturnsFalse_AfterPushingElements()
        {
            stack.Push(10);

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_AfterPoppingAllElements()
        {
            stack.Push(10);
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
        }
    }
}