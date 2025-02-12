using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListsMergeLibrary
{
    public readonly record struct MergeResultTuple(IEnumerable<int> Result);

    public class MergedCollection<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<IEnumerable<T>> collections;

        public MergedCollection(IEnumerable<IEnumerable<T>> collections)
        {
            this.collections = new List<IEnumerable<T>>(collections ?? Enumerable.Empty<IEnumerable<T>>());
        }

        public IEnumerator<T> GetEnumerator()
        {
            var iterators = collections.Select(c => c.GetEnumerator()).ToList();
            var sortedList = new SortedSet<T>();

            bool hasMore;
            do
            {
                hasMore = false;
                foreach (var iterator in iterators)
                {
                    if (iterator.MoveNext())
                    {
                        hasMore = true;
                        sortedList.Add(iterator.Current);
                    }
                }
            } while (hasMore);

            return sortedList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        public MergeResultTuple ToMergeResult()
        {
            var result = this.Select(item => Convert.ToInt32(item)).ToList();
            return new MergeResultTuple(result);
        }
    }
}