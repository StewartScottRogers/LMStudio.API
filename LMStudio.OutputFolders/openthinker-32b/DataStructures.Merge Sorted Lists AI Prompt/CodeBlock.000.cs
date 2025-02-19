// File: SortedMerger.cs
using System.Collections.Generic;
using System.Linq;

namespace MergingLibrary
{
    public class SortedMerger
    {
        private readonly List<int> _integers = new List<int>();

        public SortedMerger Add<T>(IEnumerable<T> list)
        {
            if (list == null) return this;
            var convertedList = list.Select(x => Convert.ToInt32(x)).ToList();
            _integers.AddRange(convertedList);
            return this;
        }

        public List<int> Merge()
        {
            // Sort the integers
            _integers.Sort();

            // Deduplicate by checking consecutive elements
            var result = new List<int>();
            int? previous = null;
            foreach (var current in _integers)
            {
                if (!previous.HasValue || current != previous.Value)
                {
                    result.Add(current);
                    previous = current;
                }
            }

            return result;
        }
    }
}