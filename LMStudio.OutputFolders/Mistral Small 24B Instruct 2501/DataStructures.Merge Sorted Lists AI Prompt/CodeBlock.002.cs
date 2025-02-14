using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class SortedListsMergeServiceTests
{
    private readonly ISortedListsMergeService _service = new SortedListsMergeService();

    [TestMethod]
    public void MergeSortedLists_NoDuplicates_ReturnsSingleSortedList()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 2, 4, 6 };

        var mergedList = _service.MergeSortedLists(list1, list2);

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, mergedList);
    }

    [TestMethod]
    public void MergeSortedLists_WithDuplicates_ReturnsSingleSortedListWithoutDuplicates()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 1, 4, 6 };

        var mergedList = _service.MergeSortedLists(list1, list2);

        CollectionAssert.AreEqual(new List<int> { 1, 3, 4, 5, 6 }, mergedList);
    }

    [TestMethod]
    public void MergeSortedLists_EmptyAndNull_ReturnsEmptyList()
    {
        var mergedList = _service.MergeSortedLists(null, new List<int>(), null);

        CollectionAssert.AreEqual(new List<int>(), mergedList);
    }
}