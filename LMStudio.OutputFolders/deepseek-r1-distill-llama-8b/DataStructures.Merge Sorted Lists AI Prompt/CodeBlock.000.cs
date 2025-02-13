// Usage Example: Merging Multiple Lists
var builder = new SortedListMergerBuilder();

// Add three sorted lists
builder.Merge(new List<int> { 1, 3, 5 });
builder.Merge(new List<int> { 2, 4, 6 });
builder.Merge(new List<int> { 7, 8, 9 });

// Build the final merged list
var result = builder.Build();

// Output: 1, 2, 3, 4, 5, 6, 7, 8, 9
foreach (int num in result.MergedList)
{
    Console.WriteLine(num);
}