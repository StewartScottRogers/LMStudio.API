// MergerFluentWrapper.cs
namespace InMemoryLibrary
{
    public class MergerFluentWrapper<T> where T : IComparable<T>
    {
        private readonly IMerger<T> _merger;
        private List<List<T>> _lists;

        internal MergerFluentWrapper(IMerger<T> merger)
        {
            _merger = merger;
            _lists = new List<List<T>>();
        }

        public MergerFluentWrapper<T> AddList(List<T> list)
        {
            _lists.Add(list);
            return this;
        }

        public List<T> Merge()
        {
            return _merger.MergeSortedLists(_lists);
        }
    }
}