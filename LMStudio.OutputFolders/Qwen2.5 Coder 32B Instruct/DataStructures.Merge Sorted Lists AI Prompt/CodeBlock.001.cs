using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class MergeSortedListsTests
{
    [TestMethod]
    public void TestMergeAndRemoveDuplicates()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 2, 4, 6 };
        var list3 = new List<int> { 3, 5, 7 };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, result);
    }

    [TestMethod]
    public void TestNullLists()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = null as List<int>;
        var list3 = new List<int> { 2, 4, 6 };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }

    [TestMethod]
    public void TestEmptyLists()
    {
        var list1 = new List<int> { };
        var list2 = new List<int> { 2, 4, 6 };
        var list3 = new List<int> { };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int> { 2, 4, 6 }, result);
    }

    [TestMethod]
    public void TestAllEmptyLists()
    {
        var list1 = new List<int> { };
        var list2 = new List<int> { };
        var list3 = new List<int> { };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int>(), result);
    }
}