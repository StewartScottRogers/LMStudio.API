var merger = new MergeSortedLists();
var resultTuple = merger.MergeSortedListsTuple(new[] 
{ 
    new List<int> { 1, 3, 5 }, 
    new List<int> { 2, 4, 6 } 
});

// Access result and statistics
var mergedResult = resultTuple.Result;
var stats = resultTuple.Statistics;