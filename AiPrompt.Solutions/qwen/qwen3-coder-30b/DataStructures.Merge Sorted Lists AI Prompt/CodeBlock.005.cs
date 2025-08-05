using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedLists.Tests
{
    [TestClass]
    public class MergeSortedListsTests
    {
        private IMergeSortedLists _merger;

        [TestInitialize]
        public void Setup()
        {
            _merger = new MergeSortedLists();
        }

        [TestMethod]
        public void MergeSortedLists_WithValidInput_ReturnsMergedResult()
        {
            // Arrange
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var inputLists = new[] { list1, list2 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, resultTuple.Result);
            Assert.AreEqual(2, resultTuple.Statistics.TotalLists);
            Assert.AreEqual(6, resultTuple.Statistics.TotalElements);
            Assert.IsTrue(resultTuple.Statistics.ProcessingTimeMs >= 0);
        }

        [TestMethod]
        public void MergeSortedLists_WithDuplicates_ReturnsUniqueElements()
        {
            // Arrange
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 1, 2, 3 };
            var inputLists = new[] { list1, list2 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 5 }, resultTuple.Result);
        }

        [TestMethod]
        public void MergeSortedLists_WithEmptyLists_ReturnsCorrectResult()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int>(); // Empty list
            var inputLists = new[] { list1, list2 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, resultTuple.Result);
        }

        [TestMethod]
        public void MergeSortedLists_WithNullInput_ThrowsException()
        {
            // Arrange
            IEnumerable<IEnumerable<int>> nullLists = null;

            // Act & Assert
            Assert.ThrowsException<MergeSortedListsException>(() => 
                _merger.MergeSortedListsTuple(nullLists));
        }

        [TestMethod]
        public void MergeSortedLists_WithNullListInCollection_HandlesGracefully()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3 };
            IEnumerable<int> nullList = null;
            var inputLists = new[] { list1, nullList };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, resultTuple.Result);
        }

        [TestMethod]
        public void MergeSortedLists_WithSingleList_ReturnsSameList()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var inputLists = new[] { list1 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, resultTuple.Result);
        }

        [TestMethod]
        public void MergeSortedLists_WithManyLists_ReturnsCorrectResult()
        {
            // Arrange
            var list1 = new List<int> { 1, 5, 9 };
            var list2 = new List<int> { 2, 6, 10 };
            var list3 = new List<int> { 3, 7, 11 };
            var list4 = new List<int> { 4, 8, 12 };
            var inputLists = new[] { list1, list2, list3, list4 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, resultTuple.Result);
        }

        [TestMethod]
        public void MergeSortedLists_WithNegativeNumbers_ReturnsCorrectResult()
        {
            // Arrange
            var list1 = new List<int> { -5, -3, -1 };
            var list2 = new List<int> { -4, -2, 0 };
            var inputLists = new[] { list1, list2 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { -5, -4, -3, -2, -1, 0 }, resultTuple.Result);
        }

        [TestMethod]
        public void MergeSortedLists_WithLargeData_ReturnsCorrectResult()
        {
            // Arrange
            var list1 = Enumerable.Range(1, 1000).Where(x => x % 2 == 0).ToList();
            var list2 = Enumerable.Range(1, 1000).Where(x => x % 3 == 0).ToList();
            var inputLists = new[] { list1, list2 };

            // Act
            var resultTuple = _merger.MergeSortedListsTuple(inputLists);

            // Assert
            Assert.IsTrue(resultTuple.Result.Count > 0);
            Assert.AreEqual(1, resultTuple.Result.First());
            Assert.IsTrue(resultTuple.Result.Last() <= 1000);
        }
    }
}