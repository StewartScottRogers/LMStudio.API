using System;
using System.Collections.Generic;
using System.Linq;

namespace MergedListLibrary
{
    public class MergedList : IMergedList<int>
    {
        private readonly SortedSet<int> _result;

        public MergedList()
        {
            _result = new SortedSet<int>();
        }

        public IMergedList<int> Add(IEnumerable<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            foreach (var item in list)
            {
                if (item != null && !_result.Contains(item))
                {
                    _result.Add(item);
                }
            }

            return this;
        }

        public IEnumerable<int> GetResult()
        {
            return _result;
        }
    }
}