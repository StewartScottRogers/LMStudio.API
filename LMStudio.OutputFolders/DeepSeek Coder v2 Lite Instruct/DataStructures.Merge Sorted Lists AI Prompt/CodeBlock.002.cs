using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedListsLib
{
    public class Merger : IMergeableList<int>
    {
        public IEnumerable<int> Merge(IEnumerable<IEnumerable<int>> lists)
        {
            var priorityQueue = new SortedSet<(int Value, int ListIndex)>();
            var resultList = new List<int>();
            var seen = new HashSet<int>();

            foreach (var list in lists)
            {
                if (list.Any())
                {
                    priorityQueue.Add((list.First(), lists.ToList().IndexOf(list)));
                }
            }

            while (priorityQueue.Count > 0)
            {
                var (value, listIndex) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                if (!seen.Contains(value))
                {
                    resultList.Add(value);
                    seen.Add(value);
                }

                var nextElement = lists.ElementAt(listIndex).SkipWhile(x => x == value).FirstOrDefault();
                if (nextElement != default)
                {
                    priorityQueue.Add((nextElement, listIndex));
                }
            }

            return resultList;
        }
    }
}