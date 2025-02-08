public interface ISortedListMerger<T> where T : IComparable<T>
{
    IOrderedEnumerable<T> Merge(params IEnumerable<T>[] lists);
}