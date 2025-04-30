using System;
using System.Collections.Generic;

namespace InMemoryLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var mergeService = new MergeService();
            
            var list1 = new List<int> { 1, 3, 5, 7 };
            var list2 = new List<int> { 0, 2, 6, 8 };
            var list3 = new List<int> { 4, 9 };

            var result = mergeService.MergeSortedLists(list1, list2, list3);

            Console.WriteLine("Merged Sorted List:");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}