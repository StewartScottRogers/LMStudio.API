// Solution File: MergeSortedLists.sln

// Project File: MergeSortedLists.csproj
// <Project Sdk="Microsoft.NET.Sdk">
//   <PropertyGroup>
//     <OutputType>Library</OutputType>
//     <TargetFramework>net9.0</TargetFramework>
//     <ImplicitUsings>disable</ImplicitUsings>
//     <Nullable>disable</Nullable>
//   </PropertyGroup>
// </Project>

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeSortedListsLibrary
{
    public interface ISortedListMerger
    {
        List<int> Merge(List<List<int>> sortedLists);
    }

    public class SortedListMerger : ISortedListMerger
    {
        private readonly List<List<int>> inputSortedLists;

        public SortedListMerger(List<List<int>> sortedLists)
        {
            inputSortedLists = sortedLists ?? new List<List<int>>();
        }

        public List<int> Merge(List<List<int>> sortedLists)
        {
            // Check for null or empty input lists.
            if (sortedLists == null || sortedLists.Count == 0)
            {
                return new List<int>();
            }

            // Use a min-heap to efficiently merge the sorted lists.
            var heap = new SortedListHeap();

            foreach (var list in sortedLists)
            {
                if (list != null && list.Count > 0)
                {
                    heap.Add(new HeapNode(list, 0)); // Add the first element of each list to the heap.
                }
            }

            var mergedList = new List<int>();
            HashSet<int> seenValues = new HashSet<int>();

            while (heap.Count > 0)
            {
                HeapNode node = heap.Pop();
                int value = node.List[node.Index];

                // Skip duplicate values.
                if (!seenValues.Contains(value))
                {
                    mergedList.Add(value);
                    seenValues.Add(value);
                }

                // Add the next element from the same list to the heap, if available.
                if (node.Index + 1 < node.List.Count)
                {
                    heap.Add(new HeapNode(node.List, node.Index + 1));
                }
            }

            return mergedList;
        }

        private class HeapNode : IComparable<HeapNode>
        {
            public readonly List<int> List;
            public readonly int Index;

            public HeapNode(List<int> list, int index)
            {
                List = list;
                Index = index;
            }

            public int CompareTo(HeapNode other)
            {
                return List[Index].CompareTo(other.List[other.Index]);
            }
        }

        private class SortedListHeap
        {
            private readonly List<HeapNode> heapNodes = new List<HeapNode>();

            public int Count => heapNodes.Count;

            public void Add(HeapNode node)
            {
                heapNodes.Add(node);
                heapNodes.Sort((x, y) => x.CompareTo(y)); // Maintain min-heap property.
            }

            public HeapNode Pop()
            {
                if (heapNodes.Count == 0)
                {
                    throw new InvalidOperationException("Heap is empty.");
                }

                HeapNode node = heapNodes[0];
                heapNodes.RemoveAt(0);
                return node;
            }
        }
    }

    // Unit Tests
    [TestClass]
    public class SortedListMergerTests
    {
        [TestMethod]
        public void Merge_EmptyInput()
        {
            var merger = new SortedListMerger(null);
            List<int> result = merger.Merge(new List<List<int>>());
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Merge_SingleList()
        {
            var list1 = new List<int>() { 1, 3, 5 };
            var merger = new SortedListMerger(new List<List<int>>() { list1 });
            List<int> result = merger.Merge(new List<List<int>>() { list1 });
            CollectionAssert.AreEqual(list1, result);
        }

        [TestMethod]
        public void Merge_MultipleLists()
        {
            var list1 = new List<int>() { 1, 3, 5 };
            var list2 = new List<int>() { 2, 4, 6 };
            var merger = new SortedListMerger(new List<List<int>>() { list1, list2 });
            List<int> result = merger.Merge(new List<List<int>>() { list1, list2 });
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void Merge_ListsWithDuplicates()
        {
            var list1 = new List<int>() { 1, 3, 5, 5 };
            var list2 = new List<int>() { 2, 4, 6, 6 };
            var merger = new SortedListMerger(new List<List<int>>() { list1, list2 });
            List<int> result = merger.Merge(new List<List<int>>() { list1, list2 });
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void Merge_ListsWithEmptyLists()
        {
            var list1 = new List<int>() { 1, 3, 5 };
            var list2 = new List<int>();
            var merger = new SortedListMerger(new List<List<int>>() { list1, list2 });
            List<int> result = merger.Merge(new List<List<int>>() { list1, list2 });
            CollectionAssert.AreEqual(list1, result);
        }

        [TestMethod]
        public void Merge_LargeLists()
        {
            var list1 = Enumerable.Range(0, 1000).ToList();
            var list2 = Enumerable.Range(500, 1000).ToList();
            var merger = new SortedListMerger(new List<List<int>>() { list1, list2 });
            List<int> result = merger.Merge(new List<List<int>>() { list1, list2 });

            for (int i = 0; i < result.Count; ++i)
            {
                Assert.AreEqual(i, result[i]);
            }
        }
    }
}