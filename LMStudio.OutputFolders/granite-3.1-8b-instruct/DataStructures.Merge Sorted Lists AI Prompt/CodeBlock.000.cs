namespace MergedListLibrary
{
    public interface IMergedList<T> where T : struct, IEquatable<T>, IComparable<T>
    {
        IMergedList<T> Add(IEnumerable<T> list);
    }
}