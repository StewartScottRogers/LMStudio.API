using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortedListMerger.Tests
{
    [TestClass]
    public class MergeServiceTests
    {
        private readonly IMergeService mergeService = new MergeService();

        [TestMethod]
        public void TestMergeSortedLists_NullInput()
        {
            var resultTuple = mergeService.MergeSortedListsTuple(null);
            Assert.IsTrue(resultTuple.Success);
            CollectionAssert.AreEqual(new List<int>(), resultTuple.MergedList);
        }

        [TestMethod]
        public void TestMergeSortedLists_EmptyInput()
        {
            var resultTuple = mergeService.MergeSortedListsTuple(new List<IEnumerable<int>>());
            Assert.IsTrue(resultTuple.Success);
            CollectionAssert.AreEqual(new List<int>(), resultTuple.MergedList);
        }

        [TestMethod]
        public void TestMergeSortedLists_SingleList()
        {
            var input = new List<IEnumerable<int>> { new List<int> { 1, 2, 3 } };
            var resultTuple = mergeService.MergeSortedListsTuple(input);
            Assert.IsTrue(resultTuple.Success);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, resultTuple.MergedList);
        }

        [TestMethod]
        public void TestMergeSortedLists_MultipleLists()
        {
            var input = new List<IEnumerable<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 2, 4, 6 },
                new List<int> { 0, 7 }
            };
            var resultTuple = mergeService.MergeSortedListsTuple(input);
            Assert.IsTrue(resultTuple.Success);
            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 }, resultTuple.MergedList);
        }

        [TestMethod]
        public void TestMergeSortedLists_WithDuplicates()
        {
            var input = new List<IEnumerable<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 2, 3, 4 }
            };
            var resultTuple = mergeService.MergeSortedListsTuple(input);
            Assert.IsTrue(resultTuple.Success);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, resultTuple.MergedList);
        }

        [TestMethod]
        public void TestMergeSortedLists_LargeInput()
        {
            var largeList1 = Enumerable.Range(1, 1000).ToList();
            var largeList2 = Enumerable.Range(500, 1000).ToList();
            var input = new List<IEnumerable<int>> { largeList1, largeList2 };
            var resultTuple = mergeService.MergeSortedListsTuple(input);
            Assert.IsTrue(resultTuple.Success);
            CollectionAssert.AreEqual(largeList1.Concat(largeList2.Distinct()).Distinct().OrderBy(x => x).ToList(), resultTuple.MergedList);
        }
    }
}