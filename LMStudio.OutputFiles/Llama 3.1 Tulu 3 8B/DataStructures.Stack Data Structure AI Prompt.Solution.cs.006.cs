using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackLibraryTests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Push_Pop_Test()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        // Add more tests as needed...
    }
}