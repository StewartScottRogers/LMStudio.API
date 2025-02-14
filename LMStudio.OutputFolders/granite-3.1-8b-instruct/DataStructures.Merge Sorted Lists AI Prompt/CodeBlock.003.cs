using System.Collections.Generic;

namespace MergedListLibrary
{
    public static class MergeStrategyTuple
    {
        public static (IMergedList<int> Result, IEnumerable<IMergedList<int>> InputLists) Merge(IEnumerable<IMergedList<int>> inputLists)
        {
            if (inputLists == null)
                throw new ArgumentNullException(nameof(inputLists));

            var mergedResult = MergeStrategy.MergeLists(inputLists);
            return (mergedResult, inputLists);
        }
    }
}