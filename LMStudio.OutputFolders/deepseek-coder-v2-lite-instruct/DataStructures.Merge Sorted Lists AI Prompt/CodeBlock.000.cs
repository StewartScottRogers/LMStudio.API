// IMerger.cs
namespace InMemoryLibrary
{
    public interface IMerger<T> where T : IComparable<T>
    {
        List<T> MergeSortedLists(List<List<T>> lists);
    }
}