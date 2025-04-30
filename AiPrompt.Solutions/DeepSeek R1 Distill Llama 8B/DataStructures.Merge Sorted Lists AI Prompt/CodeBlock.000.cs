namespace InMemoryLibrary
{
    public interface IMergeService
    {
        List<int> MergeSortedLists(params List<int>[] sortedLists);
    }
}