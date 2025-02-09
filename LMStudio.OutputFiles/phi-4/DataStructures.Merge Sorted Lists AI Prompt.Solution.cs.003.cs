using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class IntegerMergerTests
{
    private readonly IMergeStrategy<int> _merger = new IntegerMerger();

    [TestMethod]
    public void Merge_EmptyLists_ReturnsEmptyList()
    {
        var result = _merger.With(new List<IEnumerable<int>> { null, Array.Empty<int>() });
        CollectionAssert.AreEqual(Array.Empty<int>(), result.ToArray());
    }

    [TestMethod]
    public void Merge_SingleNonEmptyList_ReturnsSortedUniqueList()
    {
        var lists = new List<IEnumerable<int>>
        {
            new[] { 1, 2, 3 }
        };

        var result = _merger.With(lists);
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray());
    }

    [TestMethod]
    public void Merge_MultipleLists_ReturnsSortedUniqueList()
    {
        var lists = new List<IEnumerable<int>>
        {
            new[] { 1, 4, 5 },
            new[] { 1, 2, 6 }
        };

        var result = _merger.With(lists);
        CollectionAssert.AreEqual(new[] { 1, 2, 4, 5, 6 }, result.ToArray());
    }

    [TestMethod]
    public void Merge_WithDuplicates_ReturnsUniqueList()
    {
        var lists = new List<IEnumerable<int>>
        {
            new[] { 1, 1, 3 },
            new[] { 2, 2 }
        };

        var result = _merger.With(lists);
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ToArray());
    }

    [TestMethod]
    public void Merge_ManyLists_ReturnsCorrectResult()
    {
        // Testing with multiple lists
        var lists = new List<IEnumerable<int>>
        {
            Enumerable.Range(1, 1000),
            Enumerable.Range(500, 1500),
            Enumerable.Range(2000, 500)
        };

        var result = _merger.With(lists);
        
        CollectionAssert.AreEqual(
            Enumerable.Range(1, 2500).Distinct().OrderBy(x => x).ToArray(),
            result.ToArray());
    }
}