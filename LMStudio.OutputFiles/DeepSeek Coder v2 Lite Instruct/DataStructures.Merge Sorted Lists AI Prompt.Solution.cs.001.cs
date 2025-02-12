using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedLists
{
    public class MergeSortedLists : IMergeSortedLists
    {
        public List<int> Merge(List<List<int>> sortedLists)
        {
            if (sortedLists == null || !sortedLists.Any())
                throw new ArgumentException("Input lists must be provided.");

            var result = new SortedSet<int>();

            foreach (var list in sortedLists)
            {
                if (list == null)
                    continue;

                foreach (var item in list)
                {
                    result.Add(item);
                }
            }

            return result.ToList();
        }
    }
}