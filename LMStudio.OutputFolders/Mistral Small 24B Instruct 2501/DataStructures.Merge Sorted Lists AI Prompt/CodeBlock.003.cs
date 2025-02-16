using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortedListMerger.Tests
{
    [TestClass]
    public class SortedListMergerTests
    {
        private readonly IMergeableList sortedListMerger = new SortedListMerger();

        /// <summary>
        /// Tests merging of multiple sorted lists.
        /// </summary>
        [TestMethod]
        public void TestMergeSortedLists()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var list3 = new List<int> { 0, 7, 8 };

            var lists = new List<IEnumerable<int>> { list1, list2, list3 };
            var result = sortedListMerger.MergeSortedLists(lists);

            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, result.MergedList);
            Assert.IsTrue(result.Success);
        }

        /// <summary>
        /// Tests merging of empty lists.
        /// </summary>
        [TestMethod]
        public void TestMergeEmptyLists()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var lists = new List<IEnumerable<int>> { list1, list2 };
            var result = sortedListMerger.MergeSortedLists(lists);

            CollectionAssert.AreEqual(new List<int>(), result.MergedList);
            Assert.IsTrue(result.Success);
        }

        /// <summary>
        /// Tests merging of null lists.
        /// </summary>
        [TestMethod]
        public void TestMergeNullLists()
        {
            var list1 = new List<int>();
            IEnumerable<int> nullList = null;

            var lists = new List<IEnumerable<int>> { list1, nullList };
            var result = sortedListMerger.MergeSortedLists(lists);

            CollectionAssert.AreEqual(new List<int>(), result.MergedList);
            Assert.IsTrue(result.Success);
        }

    }
}