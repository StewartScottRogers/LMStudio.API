public class SortedListMerger<T> : ISortedListMerger<T> where T : IComparable<T>
{
    public IOrderedEnumerable<T> Merge(params IEnumerable<T>[] lists)
    {
        // Implementation details omitted for brevity
    }
}