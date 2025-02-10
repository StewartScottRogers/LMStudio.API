namespace MergeSortedListsTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using MergeSortedListsLibrary.Interfaces;
    using MergeSortedListsLibrary.Services;

    /// <summary>
    /// Unit tests for the MergeSortedListsService.
    /// </summary>
    [TestClass]
    public class MergeSortedListsTests
    {
        private readonly IMergeSortedLists mergeSortedListsService = new MergeSortedListsService();

        [TestMethod]
        public void TestMergeEmptyLists()
        {
            var result = mergeSortedListsService.MergeSortedLists(new List<IEnumerable<int>>());
            Assert.AreEqual(0, result.TotalElementsMerged);
            CollectionAssert.AllItemsAreUnique(result.MergedList);
        }

        [TestMethod]
        public void TestMergeSingleList()
        {
            var input = new List<int> { 1, 2, 3 };
            var result = mergeSortedListsService.MergeSortedLists(new[] { input });
            CollectionAssert.AreEqual(input, result.MergedList);
            Assert.AreEqual(3, result.TotalElementsMerged);
        }

        [TestMethod]
        public void TestMergeMultipleLists()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 4, 5, 6 };
            var expected = new SortedSet<int> { 1, 2, 3, 4, 5, 6 };

            var result = mergeSortedListsService.MergeSortedLists(new[] { list1, list2 });
            CollectionAssert.AreEqual(expected, result.MergedList);
            Assert.AreEqual(6, result.TotalElementsMerged);
        }

        [TestMethod]
        public void TestMergeListsWithDuplicates()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 3, 4, 5 };
            var expected = new SortedSet<int> { 1, 2, 3, 4, 5 };

            var result = mergeSortedListsService.MergeSortedLists(new[] { list1, list2 });
            CollectionAssert.AreEqual(expected, result.MergedList);
            Assert.AreEqual(5, result.TotalElementsMerged);
        }

        [TestMethod]
        public void TestMergeNullLists()
        {
            var input = new List<IEnumerable<int>> { null };
            var result = mergeSortedListsService.MergeSortedLists(input);

            CollectionAssert.AllItemsAreUnique(result.MergedList);
        }
    }
}