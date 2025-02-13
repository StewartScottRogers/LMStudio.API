// Records/MergeResultRecord.cs
namespace MergedSortedLists.Records
{
    public readonly record struct MergeResultRecord(
        List<int> ResultList,
        int TotalElements);
}