using System;
using System.Collections.Generic;

namespace MergeSortedLists
{
    /// <summary>
    /// Main program demonstrating usage of the merge sorted lists library
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Merge Sorted Lists Library Demo");
            Console.WriteLine("==================================");

            // Create instance of the merger
            var merger = new MergeSortedLists();

            // Test case 1: Basic merge with duplicates
            var list1 = new List<int> { 1, 3, 5, 7, 9 };
            var list2 = new List<int> { 2, 4, 6, 8, 10 };
            var list3 = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Test Case 1: Basic merge with duplicates");
            var resultTuple1 = merger.MergeSortedListsTuple(new[] { list1, list2, list3 });
            
            Console.WriteLine($"Merged Result: [{string.Join(", ", resultTuple1.Result)}]");
            Console.WriteLine($"Statistics: Lists={resultTuple1.Statistics.TotalLists}, Elements={resultTuple1.Statistics.TotalElements}, Time={resultTuple1.Statistics.ProcessingTimeMs}ms");
            Console.WriteLine();

            // Test case 2: Empty and null lists
            var list4 = new List<int> { 10, 20, 30 };
            var list5 = new List<int>(); // Empty list
            IEnumerable<int> nullList = null; // Null list

            Console.WriteLine("Test Case 2: Handling empty and null lists");
            var resultTuple2 = merger.MergeSortedListsTuple(new[] { list4, list5, nullList });
            
            Console.WriteLine($"Merged Result: [{string.Join(", ", resultTuple2.Result)}]");
            Console.WriteLine($"Statistics: Lists={resultTuple2.Statistics.TotalLists}, Elements={resultTuple2.Statistics.TotalElements}, Time={resultTuple2.Statistics.ProcessingTimeMs}ms");
            Console.WriteLine();

            // Test case 3: Large lists
            var largeList1 = Enumerable.Range(1, 1000).Select(x => x * 2).ToList();
            var largeList2 = Enumerable.Range(1, 1000).Select(x => x * 3).ToList();

            Console.WriteLine("Test Case 3: Large lists");
            var resultTuple3 = merger.MergeSortedListsTuple(new[] { largeList1, largeList2 });
            
            Console.WriteLine($"Merged Result (first 10 elements): [{string.Join(", ", resultTuple3.Result.Take(10))}]...");
            Console.WriteLine($"Statistics: Lists={resultTuple3.Statistics.TotalLists}, Elements={resultTuple3.Statistics.TotalElements}, Time={resultTuple3.Statistics.ProcessingTimeMs}ms");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}