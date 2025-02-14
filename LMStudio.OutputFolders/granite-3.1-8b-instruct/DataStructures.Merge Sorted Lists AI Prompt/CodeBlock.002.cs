using System.Collections.Generic;

namespace MergedListLibrary
{
    public static class MergeStrategy
    {
        public static IMergedList<int> MergeLists(IEnumerable<IMergedList<int>> mergedLists)
        {
            if (mergedLists == null)
                throw new ArgumentNullException(nameof(mergedLists));

            var result = new MergedList();
            foreach (var list in mergedLists)
            {
                result.Add(list);
            }

            return result;
        }
    }
}