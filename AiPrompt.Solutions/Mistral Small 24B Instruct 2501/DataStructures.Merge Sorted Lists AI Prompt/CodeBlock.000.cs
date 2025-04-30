using System;
using System.Collections.Generic;

namespace MergedLibrary
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var list3 = new List<int> { 0, 7, 8 };

            var result = new SortedListMerger<int>().Add(list1).Add(list2).Add(list3).Merge();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}