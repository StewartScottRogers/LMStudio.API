using System;
using System.Collections.Generic;
using MergeSortedListsLib;

class Program
{
    static void Main(string[] args)
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 2, 4, 6 };

        var result = MergeUtility.MergeSortedLists(new List<List<int>> { list1, list2 });

        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }
}