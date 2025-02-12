using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MergeSortedLists.Tests
{
    [TestClass]
    public class MergeSortedListsTests
    {
        private IMergeSortedLists _mergeSortedLists;

        [TestInitialize]
        public void Initialize()
        {
            _mergeSortedLists = new MergeSortedLists();
        }

        [TestMethod]
        public void TestMerge_TwoLists()
        {
            var lists = new List<List<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 2, 4, 6 }
            };

            var result = _mergeSortedLists.Merge(lists);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void TestMerge_NullInput()
        {
            var lists = new List<List<int>> { null };

            Assert.ThrowsException<ArgumentException>(() => _mergeSortedLists.Merge(lists));
        }

        // Add more tests for different scenarios and edge cases...
    }
}