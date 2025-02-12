using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedListsLib.Tests
{
    [TestClass]
    public class MergerTests
    {
        private Merger _merger = new Merger();

        [TestMethod]
        public void TestMergeTwoLists()
        {
            var lists = new List<IEnumerable<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 2, 4, 6 }
            };

            var result = _merger.Merge(lists);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result.ToList());
        }

        [TestMethod]
        public void TestMergeEmptyLists()
        {
            var lists = new List<IEnumerable<int>>
            {
                new List<int>(),
                new List<int>()
            };

            var result = _merger.Merge(lists);
            CollectionAssert.AreEqual(new List<int>(), result.ToList());
        }

        [TestMethod]
        public void TestMergeNullLists()
        {
            var lists = new List<IEnumerable<int>>
            {
                null,
                null
            };

            var result = _merger.Merge(lists);
            CollectionAssert.AreEqual(new List<int>(), result.ToList());
        }
    }
}