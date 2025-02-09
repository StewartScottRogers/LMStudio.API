var lists = new List<IEnumerable<int>>
{
    new List<int> {1, 3, 5},
    new List<int> {2, 4, 6}
};

var mergedList = ListMerger.Merge(lists).ToList();