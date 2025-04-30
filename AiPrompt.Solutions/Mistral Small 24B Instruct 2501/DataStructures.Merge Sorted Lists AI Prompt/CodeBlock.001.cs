using System;
using System.Collections.Generic;

namespace MergedLibrary
{
    public class SortedListMerger<T> where T : IComparable<T>
    {
        private readonly List<List<T>> lists = new();

        public SortedListMerger<T> Add(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            lists.Add(list);
            return this;
        }

        public List<T> Merge()
        {
            var mergedList = new List<T>();
            foreach (var list in lists)
            {
                mergedList.AddRange(list);
            }

            mergedList.Sort();
            RemoveDuplicates(mergedList);

            return mergedList;
        }

        private void RemoveDuplicates(List<T> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(list[i - 1]) == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}