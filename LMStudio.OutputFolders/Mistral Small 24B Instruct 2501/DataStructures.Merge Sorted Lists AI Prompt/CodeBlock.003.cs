using System;

namespace SortedListMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            var mergeService = new MergeService();

            // Example usage:
            var inputLists = new[]
            {
                new[] { 1, 3, 5 },
                new[] { 2, 4, 6 },
                new[] { 0, 7 }
            };

            var resultTuple = mergeService.MergeSortedListsTuple(inputLists);
            Console.WriteLine("Merged List: " + string.Join(", ", resultTuple.MergedList));
        }
    }
}