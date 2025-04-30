using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortedListsMerger.Tests
{
    [TestClass]
    public class MergedListProcessorTests
    {
        private readonly IMergedListProcessor processor = new MergedListProcessor();

        [TestMethod]
        public void MergeSortedLists_WithMultipleLists_ReturnsMergedAndSortedUniqueList()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var list3 = new List<int> { 0, 7, 8 };

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2, list3 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void MergeSortedLists_WithNullLists_ReturnsEmptyList()
        {
            var result = processor.MergeSortedLists(null);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithEmptyLists_ReturnsEmptyList()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithNullAndEmptyLists_ReturnsEmptyList()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { null, list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithLargeLists_ReturnsMergedAndSortedUniqueList()
        {
            // Simulating large lists
            var list1 = Enumerable.Range(0, 500).ToList();
            var list2 = Enumerable.Range(500, 500).ToList();

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(Enumerable.Range(0, 1000).ToList(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithDuplicateElements_ReturnsMergedAndSortedUniqueList()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 2, 3, 4 };

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result);
        }
    }
}