// File: SortedMergerTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MergingLibrary;
using System.Collections.Generic;

namespace MergingLibrary.Tests
{
    [TestClass]
    public class SortedMergerTests
    {
        [TestMethod]
        public void Test_EmptyAndNullInputs()
        {
            var merger = new SortedMerger();
            var result = merger.Merge();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Test_SingleListWithElements()
        {
            var list1 = new List<int> { 3, 5 };
            var merger = new SortedMerger().Add(list1);
            var result = merger.Merge();
            CollectionAssert.AreEqual(new List<int> { 3, 5 }, result);
        }

        [TestMethod]
        public void Test_MultipleLists()
        {
            var list1 = new List<string> { "10", "2" };
            var list2 = new List<int> { 1, 5 };
            var merger = new SortedMerger().Add(list1).Add(list2);
            var result = merger.Merge();
            CollectionAssert.AreEqual(new List<int> { 1, 2, 5, 10 }, result);
        }

        [TestMethod]
        public void Test_Duplicates()
        {
            var list1 = new List<int> { 3 };
            var list2 = new List<string> { "3" };
            var merger = new SortedMerger().Add(list1).Add(list2);
            var result = merger.Merge();
            CollectionAssert.AreEqual(new List<int> { 3 }, result);
        }

        [TestMethod]
        public void Test_LargeInputs()
        {
            int count = 1000;
            var list1 = new List<int>(Enumerable.Range(1, count));
            var list2 = new List<int>(Enumerable.Range(count + 1, count));
            var merger = new SortedMerger().Add(list1).Add(list2);
            var result = merger.Merge();
            Assert.IsTrue(result.Count == 2 * count);
        }
    }
}