var list1 = new[] { 1, 2, 3 };
var list2 = new[] { 2, 4, 6 };
var list3 = new[] { 3, 5, 7 };

var mergedList = new SortedListMerger()
    .AddList(list1)
    .AddList(list2)
    .AddList(list3)
    .GetMergedList();