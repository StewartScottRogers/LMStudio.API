// Interface defining a merge strategy for sorted lists
public interface IMergeStrategy<T>
{
    IEnumerable<T> MergeLists(IEnumerable<IEnumerable<T>> sortedLists);
}