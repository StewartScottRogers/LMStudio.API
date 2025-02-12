using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListNamespace;

namespace LinkedListApp.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddFirst_ShouldAddNodeAtBeginning()
        {
            var list = new LinkedList<int>();
            list.AddFirst(1);
            Assert.AreEqual(1, list.Head.Data);
        }

        // Write more tests for other functionalities...
    }
}