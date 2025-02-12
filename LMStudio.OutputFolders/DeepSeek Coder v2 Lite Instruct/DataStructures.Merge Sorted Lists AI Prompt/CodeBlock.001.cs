namespace MergeSortedListsLib
{
    public record MergeResult<T>(List<T> SortedList, HashSet<T> UniqueElements);
}