namespace MergeSortedListsLib
{
    public interface IMergeableList<T> where T : IComparable<T>
    {
        IEnumerable<T> Merge(IEnumerable<IEnumerable<T>> lists);
    }
}