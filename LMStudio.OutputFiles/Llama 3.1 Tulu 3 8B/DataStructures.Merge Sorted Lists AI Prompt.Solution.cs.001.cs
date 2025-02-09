using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeSortedListsTests
{
    [TestClass]
    public class ListMergerTests
    {
        [TestMethod]
        public void Merge_EmptyInput_ReturnsEmptyList()
        {
            var lists = new List<IEnumerable<int>> { };
            var result = ListMerger.Merge(lists).ToList();
            
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Merge_SingleList_ReturnsSameList()
        {
            var list = new List<int> { 1, 2, 3 };
            var result = ListMerger.Merge(new List<IEnumerable<int>> { list }).ToList();

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEquivalent(list, result);
        }

        [TestMethod]
        public void Merge_MultipleLists_NoDuplicates()
        {
            var lists = new List<IEnumerable<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 2, 4, 6 },
                new List<int> { 3, 5, 7 }
            };

            var result = ListMerger.Merge(lists).ToList();

            Assert.AreEqual(7, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, result);
        }

        [TestMethod]
        public void Merge_SortedLists_ReturnsSortedList()
        {
            var lists = new List<IEnumerable<int>>
            {
                new List<int> { 3, 5, 7 },
                new List<int> { 1, 2, 6 }
            };

            var result = ListMerger.Merge(lists).ToList();

            Assert.AreEqual(7, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 5, 6, 7 }, result);
        }
    }
}