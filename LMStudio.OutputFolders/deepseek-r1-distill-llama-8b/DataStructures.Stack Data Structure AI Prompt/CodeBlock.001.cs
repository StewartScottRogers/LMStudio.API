using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> _stack = new Stack<int>();

        [TestInitialize]
        public void InitializeStack()
        {
            // Initialize stack for each test.
            _stack = new Stack<int>();
        }

        [TestCleanup]
        public void CleanupStack()
        {
            // Clean up after each test.
            if (_stack != null)
                _stack.Dispose();
        }

        #region Test Cases

        #region Basic Operations
        [TestMethod]
        public void TestAddItem_ShouldIncreaseCount()
        {
            int item = 1;
            _stack.AddItem(item);
            Assert.AreEqual(1, _stack.Count, "Stack count should be 1 after add.");
        }

        [TestMethod]
        public void TestRemoveItem_ShouldDecreaseCount()
        {
            int? result = _stack.PeekItem();
            Assert.AreEqual(1, _stack.Count, "Stack count should be 1 before remove.");

            try
            {
                _stack.RemoveItem();
                Assert.AreEqual(0, _stack.Count, "Stack count should be 0 after remove.");
            }
            catch (InvalidOperationException)
            {
                // Expected exception when trying to remove from empty stack.
            }
        }

        [TestMethod]
        public void TestPeekItem_ShouldReturnCorrectValue()
        {
            int item = 1;
            _stack.AddItem(item);
            Assert.AreEqual(item, _stack.PeekItem(), "Peek should return the top item.");
        }

        #endregion

        #region Boundary Conditions
        [TestMethod]
        public void TestStackIsFull_WhenMaxCapacityReached()
        {
            try
            {
                _stack.MaxCapacity = 2;
                _stack.AddItem(1);
                _stack.AddItem(2);

                // Attempting to add third item should throw exception.
                _stack.AddItem(3);
                Assert.Fail("Stack should be full and throw exception on add.");
            }
            catch (InvalidOperationException)
            {
                // Expected exception when stack is full.
            }
        }

        [TestMethod]
        public void TestStackIsEmpty_WhenCountIsZero()
        {
            Assert.IsTrue(_stack.IsEmpty, "Stack count should be 0 when empty.");
        }

        #endregion
    }
}