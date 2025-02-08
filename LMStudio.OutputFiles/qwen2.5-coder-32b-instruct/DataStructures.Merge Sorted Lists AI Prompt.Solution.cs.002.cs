using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class SortedListMergerTests
{
    [TestMethod]
    public void MergeSortedLists_TwoSortedLists_ReturnsMergedSortedUniqueList()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 2, 4, 6 };

        var lists = new List<List<int>> { list1, list2 };
        
        var result = SortedListMerger.Instance.MergeSortedLists(lists);

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result.ToList());
    }

    [TestMethod]
    public void MergeSortedLists_EmptyLists_ReturnsEmptyList()
    {
        var lists = new List<List<int>> { new List<int>(), new List<int>() };
        
        var result = SortedListMerger.Instance.MergeSortedLists(lists);

        CollectionAssert.AreEqual(new List<int>(), result.ToList());
    }

    [TestMethod]
    public void MergeSortedLists_NullInput_ReturnsEmptyList()
    {
        List<int> list1 = null;
        List<int> list2 = new List<int> { 2, 4, 6 };

        var lists = new List<List<int>> { list1, list2 };
        
        var result = SortedListMerger.Instance.MergeSortedLists(lists);

        CollectionAssert.AreEqual(new List<int> { 2, 4, 6 }, result.ToList());
    }

    [TestMethod]
    public void MergeSortedLists_WithDuplicates_ReturnsUniqueValues()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 1, 2, 4, 6 };

        var lists = new List<List<int>> { list1, list2 };
        
        var result = SortedListMerger.Instance.MergeSortedLists(lists);

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result.ToList());
    }
}