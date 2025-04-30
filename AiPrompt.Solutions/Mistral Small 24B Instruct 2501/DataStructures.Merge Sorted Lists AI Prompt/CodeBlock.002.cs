using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MergedLibrary.Tests
{
    [TestClass]
    public class SortedListMergerTests
    {
        private readonly SortedListMerger<int> merger = new();

        [TestMethod]
        public void Merge_TwoSortedLists_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = merger.Add(list1).Add(list2).Merge();

            Assert.AreEqual(6, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void Merge_WithNullList_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            merger.Add(list1).Add(null);

            var result = merger.Merge();

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 3, 5 }, result);
        }

        [TestMethod]
        public void Merge_WithEmptyList_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var emptyList = new List<int>();

            var result = merger.Add(list1).Add(emptyList).Merge();

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 3, 5 }, result);
        }

        [TestMethod]
        public void Merge_WithDuplicateValues_ReturnsUnique()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = merger.Add(list1).Add(list2).Merge();

            Assert.AreEqual(5, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 6 }, result);
        }

        [TestMethod]
        public void Merge_WithNegativeNumbers_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { -3, -1, 1 };
            var list2 = new List<int> { -2, 0, 2 };

            var result = merger.Add(list1).Add(list2).Merge();

            Assert.AreEqual(6, result.Count);
            CollectionAssert.AreEqual(new List<int> { -3, -2, -1, 0, 1, 2 }, result);
        }
    }
}