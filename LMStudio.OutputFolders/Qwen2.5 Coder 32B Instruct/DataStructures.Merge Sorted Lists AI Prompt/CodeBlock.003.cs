// MergeServiceTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MergedSortedLists.Interfaces;
using MergedSortedLists.Services;

namespace MergedSortedLists.Tests
{
    [TestClass]
    public class MergeServiceTests
    {
        private readonly IMergeService mergeService = new MergeService();

        [TestMethod]
        public void TestMerge_TwoSortedLists()
        {
            // Arrange
            List<List<int>> sortedLists = new List<List<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 2, 4, 6 }
            };

            // Act
            var result = mergeService.Merge(sortedLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void TestMerge_MultipleSortedLists()
        {
            // Arrange
            List<List<int>> sortedLists = new List<List<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 2, 4, 6 },
                new List<int> { 0, 7, 8 }
            };

            // Act
            var result = mergeService.Merge(sortedLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void TestMerge_WithDuplicates()
        {
            // Arrange
            List<List<int>> sortedLists = new List<List<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 1, 2, 4, 6 },
                new List<int> { 0, 7, 8 }
            };

            // Act
            var result = mergeService.Merge(sortedLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void TestMerge_WithNullLists()
        {
            // Arrange
            List<List<int>> sortedLists = new List<List<int>>
            {
                null,
                new List<int> { 1, 2, 4, 6 },
                null
            };

            // Act
            var result = mergeService.Merge(sortedLists);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 4, 6 }, result);
        }

        [TestMethod]
        public void TestMerge_EmptyLists()
        {
            // Arrange
            List<List<int>> sortedLists = new List<List<int>>
            {
                new List<int>(),
                new List<int>()
            };

            // Act
            var result = mergeService.Merge(sortedLists);

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void TestMerge_NoInput()
        {
            // Arrange
            List<List<int>> sortedLists = null;

            // Act
            var result = mergeService.Merge(sortedLists);

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }
    }
}