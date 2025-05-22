using Microsoft.VisualStudio.TestTools.UnitTesting;
using InMemoryLibrary;
using System.Collections.Generic;

namespace InMemoryLibraryTests
{
    [TestClass]
    public class MergeSortedListsTests
    {
        [TestMethod]
        public void TestMergeSingleList()
        {
            var merge = new MergeSortedLists();
            var result = merge.Merge(new List<IReadOnlyList<int>>() { new List<int>() { 1, 2, 3 } });

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3 }, result);
        }

        [TestMethod]
        public void TestMergeMultipleLists()
        {
            var merge = new MergeSortedLists();
            var result = merge.Merge(new List<IReadOnlyList<int>>() {
                new List<int>(){ 1, 3, 5 },
                new List<int>(){ 2, 4, 6 }
            });

            Assert.AreEqual(6, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void TestMergeWithDuplicates()
        {
            var merge = new MergeSortedLists();
            var result = merge.Merge(new List<IReadOnlyList<int>>() {
                new List<int>(){ 1, 2, 3 },
                new List<int>(){ 2, 3, 4 }
            });

            Assert.AreEqual(4, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void TestMergeWithNullOrEmptyLists()
        {
            var merge = new MergeSortedLists();
            var result = merge.Merge(new List<IReadOnlyList<int>>() {
                null,
                new List<int>(),
                new List<int>(){ 1, 3 }
            });

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 3 }, result);
        }

        [TestMethod]
        public void TestMergeFluent()
        {
            var merge = new MergeSortedLists();
            var fluentMerge = merge.MergeFluent(new List<IReadOnlyList<int>>() { new List<int>() { 1, 2 } })
                .Add(new List<int> { 3, 4 });
            var result = fluentMerge.Execute();

            Assert.AreEqual(4, result.Count);
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4 }, result);
        }
    }
}