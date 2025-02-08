public interface IFluentMergeable<T>
{
    IEnumerable<T> MergeSortedLists(IEnumerable<IEnumerable<T>> listOfLists);
}