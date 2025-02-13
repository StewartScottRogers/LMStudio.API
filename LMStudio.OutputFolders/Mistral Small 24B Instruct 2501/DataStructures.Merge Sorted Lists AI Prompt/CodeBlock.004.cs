var mergeService = new MergeService();
var inputLists = new[]
{
    new[] { 1, 3, 5 },
    new[] { 2, 4, 6 },
    new[] { 0, 7 }
};
var resultTuple = mergeService.MergeSortedListsTuple(inputLists);
Console.WriteLine("Merged List: " + string.Join(", ", resultTuple.MergedList));