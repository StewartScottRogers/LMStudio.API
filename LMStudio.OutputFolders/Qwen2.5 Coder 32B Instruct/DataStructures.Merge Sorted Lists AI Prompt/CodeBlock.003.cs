using SortedListsMergeLibrary;
using System.Collections.Generic;

var list1 = new List<int> { 1, 3, 5 };
var list2 = new List<int> { 2, 4, 6 };

var mergedList = new List<IEnumerable<int>> { list1, list2 }.Merge().ToMergeResult();

// Output: [1, 2, 3, 4, 5, 6]
Console.WriteLine(string.Join(", ", mergedList.Result));