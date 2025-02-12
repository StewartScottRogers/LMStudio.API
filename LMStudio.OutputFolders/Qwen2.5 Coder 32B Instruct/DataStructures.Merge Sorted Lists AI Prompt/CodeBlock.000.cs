namespace SortedListsMergeLibrary
{
    public static class MergeUtility
    {
        public static MergedCollection<T> Merge<T>(this IEnumerable<IEnumerable<T>> collections) where T : IComparable<T>
            => new MergedCollection<T>(collections);
    }
}