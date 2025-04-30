using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InMemoryLibrary.Tests
{
    [TestClass]
    public class MergeServiceTests
    {
        private readonly IMergeService mergeService = new MergeService();

        [TestMethod]
        public void TestMergeSortedLists()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = mergeService.MergeSortedLists(list1, list2);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void TestMergeWithNullAndEmptyLists()
        {
            var list1 = new List<int>();
            var list2 = (List<int>)null;
            var list3 = new List<int> { 1, 2, 3 };

            var result = mergeService.MergeSortedLists(list1, list2, list3);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result);
        }

        [TestMethod]
        public void TestMergeWithDuplicates()
        {
            var list1 = new List<int> { 1, 2, 2 };
            var list2 = new List<int> { 2, 3, 4 };

            var result = mergeService.MergeSortedLists(list1, list2);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result);
        }
    }
}