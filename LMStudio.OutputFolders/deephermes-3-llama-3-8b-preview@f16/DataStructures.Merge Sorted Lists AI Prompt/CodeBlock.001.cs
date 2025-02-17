public class MergeableList<T> : IMergeableList<T> where T : IComparable<T>
{
    public readonly List<T> MergedList = new();

    public IEnumerable<T> Merge(IEnumerable<IEnumerable<T>> lists)
    {
        // Implementation of the merge process, leveraging T's IComparable interface.
    }
}