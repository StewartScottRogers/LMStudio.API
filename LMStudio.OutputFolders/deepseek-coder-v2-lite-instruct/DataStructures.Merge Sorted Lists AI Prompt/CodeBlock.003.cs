// Program.cs
using System;
using System.Collections.Generic;
using InMemoryLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var merger = new Merger<int>();
            var fluentMerger = new MergerFluentWrapper<int>(merger);

            List<List<int>> lists = new List<List<int>>
            {
                new List<int> { 1, 4, 7 },
                new List<int> { 2, 5, 8 },
                new List<int> { 3, 6, 9 }
            };

            var result = fluentMerger.AddList(lists[0]).AddList(lists[1]).AddList(lists[2]).Merge();

            Console.WriteLine("Merged List:");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}