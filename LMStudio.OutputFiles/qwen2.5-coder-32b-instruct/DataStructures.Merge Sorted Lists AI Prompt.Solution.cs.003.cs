var list1 = new List<int> { 1, 3, 5 };
var list2 = new List<int> { 2, 4, 6 };

var listOfLists = new List<List<int>> { list1, list2 };

var mergedList = SortedListMerger.Instance.MergeSortedLists(listOfLists);

foreach (var item in mergedList)
{
    Console.WriteLine(item);
}