// MergeListsTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortedListsMerger.Tests
{
    [TestClass]
    public class MergeListsTests
    {
        private readonly IMergeLists mergeList = new MergedList();

        [TestMethod]
        public void Merge_TwoSortedLists_ReturnsMergedSortedUniqueList()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = mergeList.Merge(new List<List<int>> { list1, list2 });

            Assert.AreEqual(6, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void Merge_WithDuplicates_ReturnsUniqueElements()
        {
            var list1 = new List<int> { 1, 2, 2, 3 };
            var list2 = new List<int> { 2, 3, 4 };

            var result = mergeList.Merge(new List<List<int>> { list1, list2 });

            Assert.AreEqual(4, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void Merge_EmptyLists_ReturnsEmptyList()
        {
            var emptyList1 = new List<int>();
            var emptyList2 = new List<int>();

            var result = mergeList.Merge(new List<List<int>> { emptyList1, emptyList2 });

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Merge_NullLists_ReturnsEmptyList()
        {
            var nullList1 = new List<int> { 1, 3, 5 };
            var nullList2 = new List<int>();

            var result = mergeList.Merge(new List<List<int>> { nullList1, nullList2 });

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Merge_LargeLists_ReturnsMergedSortedUniqueList()
        {
            var largeList1 = new List<int> { 1, 3, 5, 7, 9 };
            var largeList2 = new List<int> { 2, 4, 6, 8, 10 };

            var result = mergeList.Merge(new List<List<int>> { largeList1, largeList2 });

            Assert.AreEqual(10, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);
        }

        [TestMethod]
        public void Merge_SingleList_ReturnsSameList()
        {
            var singleList = new List<int> { 1, 2, 3 };

            var result = mergeList.Merge(new List<List<int>> { singleList });

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result);
        }
    }
}