var merger = new IntegerMerger();
var result = merger.With(new List<IEnumerable<int>> {
    new[] { 1, 3, 5 },
    new[] { 2, 4, 6 }
}).ToArray();

// Output: [1, 2, 3, 4, 5, 6]