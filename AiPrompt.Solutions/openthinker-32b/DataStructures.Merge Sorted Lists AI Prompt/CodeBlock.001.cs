using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListsMerger
{
    public class MergedListProcessor : IMergedListProcessor
    {
        public List<int> MergeSortedLists(IEnumerable<IEnumerable<int>> sortedLists)
        {
            if (sortedLists == null) throw new ArgumentNullException(nameof(sortedLists));

            var mergedList = new HashSet<int>(); // To avoid duplicates

            foreach (var list in sortedLists)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        mergedList.Add(item);
                    }
                }
            }

            return mergedList.ToList().OrderBy(x => x).ToList();
        }
    }
}