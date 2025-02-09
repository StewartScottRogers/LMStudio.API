using System;
using System.Collections.Generic;

// Main class providing the merge functionality for integers
public class IntegerMerger : IMergeStrategy<int>
{
    private readonly IMergeStrategy<int> _mergeStrategy = new MergeStrategy<int>();

    // Fluent interface entry point for merging sorted integer lists.
    public IEnumerable<int> With(IEnumerable<IEnumerable<int>> sortedLists)
    {
        return _mergeStrategy.MergeLists(sortedLists);
    }
}