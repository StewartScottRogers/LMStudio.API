using System;
using System.Collections.Generic;

namespace InMemoryLibrary
{
    public class MergeService : IMergeService
    {
        public List<int> MergeSortedLists(params List<int>[] sortedLists)
        {
            var mergedList = new List<int>();
            var iterators = new List<IEnumerator<int>>();
            
            foreach (var list in sortedLists)
            {
                if (list != null && list.Count > 0)
                {
                    iterators.Add(list.GetEnumerator());
                }
            }

            while (iterators.Count > 0)
            {
                int minValue = int.MaxValue;
                int indexToRemove = -1;
                
                for (int i = 0; i < iterators.Count; i++)
                {
                    if (!iterators[i].MoveNext())
                    {
                        iterators.RemoveAt(i);
                        i--;
                        continue;
                    }

                    if (iterators[i].Current < minValue)
                    {
                        minValue = iterators[i].Current;
                        indexToRemove = i;
                    }
                }

                // Avoid duplicates
                if (mergedList.Count == 0 || mergedList[mergedList.Count - 1] != minValue)
                {
                    mergedList.Add(minValue);
                }

                if (indexToRemove >= 0 && !iterators[indexToRemove].MoveNext())
                {
                    iterators.RemoveAt(indexToRemove);
                }
            }
            
            return mergedList;
        }
    }
}