using System;
using System.Collections.Generic;
using System.Linq;

public class MergeSortLibrary
{
    private readonly List<IList<int>> _inputLists;

    public MergeSortLibrary()
    {
        _inputLists = new List<IList<int>>();
    }

    public MergeSortLibrary AddList(IList<int> list)
    {
        if (list == null)
        {
            _inputLists.Add(new List<int>());
        }
        else
        {
            _inputLists.Add(list);
        }
        return this;
    }

    public IList<int> ToSortedList()
    {
        if (_inputLists.Count == 0) return new List<int>();

        var merged = Merge(_inputLists);

        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int num in merged)
        {
            if (!seen.Contains(num))
            {
                seen.Add(num);
                result.Add(num);
            }
        }

        return result;
    }

    private static IList<int> Merge(List<IList<int>> inputLists)
    {
        if (inputLists.Count == 1) return inputLists[0];

        var first = Merge(inputLists.Take(2));
        var second = Merge(inputLists.Skip(2));

        return MergeTwoSorted Lists(first, second);
    }

    private static IList<int> MergeTwoSorted Lists(IList<int> list1, IList<int> list2)
    {
        int i = 0, j = 0;
        List<int> result = new List<int>();

        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] <= list2[j])
                result.Add(list1[i]);
                i++;
            else
                result.Add(list2[j]);
                j++;
        }

        while (i < list1.Count) result.Add(list1[i++]);
        while (j < list2.Count) result.Add(list2[j++]);

        return result;
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeSortLibrary.Tests
{
    [TestClass]
    public class MergeSortLibraryTests
    {
        private readonly MergeSortLibrary _library = new MergeSortLibrary();

        [TestMethod]
        public void TestMergeSingleList()
        {
            var list = new List<int> { 1, 3, 2 };
            var merged = _library.AddList(list).ToList();
            Assert.AreEqual(new List<int> { 1, 2, 3 }, merged);
        }

        [TestMethod]
        public void TestMergeTwoLists()
        {
            var listA = new List<int> { 1, 5, 8 };
            var listB = new List<int> { 2, 3, 4 };
            var merged = _library.AddList(listA).AddList(listB).ToList();
            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 8 }, merged);
        }

        [TestMethod]
        public void TestMergeWithDuplicates()
        {
            var listA = new List<int> { 1, 2, 2, 3 };
            var listB = new List<int> { 2, 3, 4 };
            var merged = _library.AddList(listA).AddList(listB).ToList();
            Assert.AreEqual(new List<int> { 1, 2, 3, 4 }, merged);
        }

        [TestMethod]
        public void TestHandleNull()
        {
            var nullList = new MergeSortLibrary();
            var result = nullList.AddList(null).AddList(new List<int>())
                .ToList();
            Assert.AreEqual(new List<int>(), result);
        }
    }
}