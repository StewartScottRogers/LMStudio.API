// IntegerListMerger/IntegerListMergerTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IntegerListMerger
{
    [TestClass]
    public class IntegerListMergerTests
    {
        private readonly IntegerListMergerClass integerListMerger = new IntegerListMergerClass();

        [TestMethod]
        public void MergeSortedLists_EmptyInput_ReturnsEmptyList()
        {
            // Arrange
            IEnumerable<List<int>> inputLists = null;

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            Assert.AreEqual(0, mergedListTuple.MergedListTuple.Count);
        }

        [TestMethod]
        public void MergeSortedLists_SingleEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var inputLists = new List<List<int>> { new List<int>() };

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            Assert.AreEqual(0, mergedListTuple.MergedListTuple.Count);
        }

        [TestMethod]
        public void MergeSortedLists_MultipleEmptyLists_ReturnsEmptyList()
        {
            // Arrange
            var inputLists = new List<List<int>> { new List<int>(), new List<int>(), new List<int>() };

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            Assert.AreEqual(0, mergedListTuple.MergedListTuple.Count);
        }

        [TestMethod]
        public void MergeSortedLists_SingleList_ReturnsSameList()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3 };
            var inputLists = new List<List<int>> { inputList };

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            CollectionAssert.AreEqual(inputList, mergedListTuple.MergedListTuple);
        }

        [TestMethod]
        public void MergeSortedLists_MultipleListsNoDuplicates_ReturnsMergedAndSortedList()
        {
            // Arrange
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var inputLists = new List<List<int>> { list1, list2 };

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, mergedListTuple.MergedListTuple);
        }

        [TestMethod]
        public void MergeSortedLists_MultipleListsWithDuplicates_ReturnsMergedAndSortedListWithoutDuplicates()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3, 3 };
            var list2 = new List<int> { 2, 4, 5, 5 };
            var inputLists = new List<List<int>> { list1, list2 };

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, mergedListTuple.MergedListTuple);
        }

        [TestMethod]
        public void MergeSortedLists_LargeLists_ReturnsCorrectResult()
        {
            // Arrange
            var list1 = Enumerable.Range(0, 1000).ToList();
            var list2 = Enumerable.Range(500, 1000).ToList();
            var inputLists = new List<List<int>> { list1, list2 };

            // Act
            var (mergedListTuple) = integerListMerger.MergeSortedLists(inputLists);

            // Assert
            Assert.IsNotNull(mergedListTuple);
            Assert.AreEqual(1999, mergedListTuple.MergedListTuple.Count);
            for (int i = 0; i < mergedListTuple.MergedListTuple.Count; ++i)
            {
                Assert.AreEqual(i, mergedListTuple.MergedListTuple[i]);
            }
        }
    }
}