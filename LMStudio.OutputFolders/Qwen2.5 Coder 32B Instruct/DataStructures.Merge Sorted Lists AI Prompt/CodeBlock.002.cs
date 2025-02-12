using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SortedListsMergeLibrary;

namespace SortedListsMergeLibrary.Tests
{
    [TestClass]
    public class MergeUtilityTests
    {
        [TestMethod]
        public void Merge_TwoSortedLists_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var mergedList = new List<IEnumerable<int>> { list1, list2 }.Merge().ToMergeResult();

            Assert.AreEqual(6, mergedList.Result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, mergedList.Result.ToList());
        }

        [TestMethod]
        public void Merge_MultipleSortedLists_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 5, 9 };
            var list2 = new List<int> { 2, 3, 7 };
            var list3 = new List<int> { 4, 6, 8 };

            var mergedList = new List<IEnumerable<int>> { list1, list2, list3 }.Merge().ToMergeResult();

            Assert.AreEqual(9, mergedList.Result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, mergedList.Result.ToList());
        }

        [TestMethod]
        public void Merge_WithDuplicates_ReturnsUniqueSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 3, 4, 6 };

            var mergedList = new List<IEnumerable<int>> { list1, list2 }.Merge().ToMergeResult();

            Assert.AreEqual(5, mergedList.Result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 3, 4, 5, 6 }, mergedList.Result.ToList());
        }

        [TestMethod]
        public void Merge_NullOrEmptyLists_ReturnsEmpty()
        {
            var list1 = new List<int>();
            var list2 = (List<int>)null;

            var mergedList = new List<IEnumerable<int>> { list1, list2 }.Merge().ToMergeResult();

            Assert.AreEqual(0, mergedList.Result.Count);
        }

        [TestMethod]
        public void Merge_LargeLists_ReturnsMergedAndSorted()
        {
            var largeList1 = Enumerable.Range(1, 500).ToList();
            var largeList2 = Enumerable.Range(501, 500).ToList();

            var mergedList = new List<IEnumerable<int>> { largeList1, largeList2 }.Merge().ToMergeResult();

            Assert.AreEqual(1000, mergedList.Result.Count);
            CollectionAssert.AreEqual(Enumerable.Range(1, 1000), mergedList.Result);
        }
    }
}