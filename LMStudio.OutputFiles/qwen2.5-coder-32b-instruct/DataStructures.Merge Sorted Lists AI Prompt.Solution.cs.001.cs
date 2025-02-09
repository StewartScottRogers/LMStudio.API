using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MergeSortedListsLib.Tests
{
    [TestClass]
    public class MergeUtilityTests
    {
        [TestMethod]
        public void MergeSortedLists_WithMultipleLists_ReturnsMergedSortedUniqueList()
        {
            // Arrange
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var list3 = new List<int> { 0, 7, 8 };

            // Act
            var result = MergeSortedListsLib.MergeUtility.MergeSortedLists(new List<List<int>> { list1, list2, list3 });

            // Assert
            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void MergeSortedLists_WithDuplicates_ReturnsMergedSortedUniqueList()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 2 };
            var list2 = new List<int> { 2, 3, 4 };

            // Act
            var result = MergeSortedListsLib.MergeUtility.MergeSortedLists(new List<List<int>> { list1, list2 });

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void MergeSortedLists_WithEmptyAndNullLists_ReturnsEmptyList()
        {
            // Arrange
            var list1 = new List<int> { };
            var list2 = (List<int>)null;

            // Act
            var result = MergeSortedListsLib.MergeUtility.MergeSortedLists(new List<List<int>> { list1, list2 });

            // Assert
            CollectionAssert.AreEqual(new List<int> { }, result);
        }

        [TestMethod]
        public void MergeSortedLists_WithLargeLists_ReturnsMergedSortedUniqueList()
        {
            // Arrange
            var largeList1 = Enumerable.Range(0, 500).ToList();
            var largeList2 = Enumerable.Range(250, 500).ToList();

            // Act
            var result = MergeSortedListsLib.MergeUtility.MergeSortedLists(new List<List<int>> { largeList1, largeList2 });

            // Assert
            CollectionAssert.AreEqual(Enumerable.Range(0, 750).ToList(), result);
        }

        [TestMethod]
        public void Merge_FluentInterface_ReturnsMergedSortedUniqueList()
        {
            // Arrange
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            // Act
            var result = new List<IEnumerable<int>> { list1, list2 }.Merge();

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }
    }
}