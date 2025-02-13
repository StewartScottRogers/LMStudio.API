// Interfaces/IMergeService.cs
namespace MergedSortedLists.Interfaces
{
    public interface IMergeService
    {
        List<int> Merge(List<List<int>> sortedLists);
    }
}