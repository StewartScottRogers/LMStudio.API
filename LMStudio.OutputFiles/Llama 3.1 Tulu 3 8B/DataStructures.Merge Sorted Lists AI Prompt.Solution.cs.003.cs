[TestClass]
public class SortedListMergerUnitTests
{
    [TestMethod]
    public void Merge_SortedLists_WithoutDuplicates()
    {
        // Arrange
        var merger = new SortedListMerger<int>();
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 2, 4, 6 };

        // Act
        var result = merger.Merge(list1, list2).ToList();

        // Assert
        CollectionAssert.AreEquivalent(new []{1, 2, 3, 4, 5, 6}, result);
    }

    [TestMethod]
    public void Merge_EmptyLists_ReturnsEmptyList()
    {
        // Arrange
        var merger = new SortedListMerger<int>();
        var list1 = new List<int>();
        var list2 = new List<int>();

        // Act
        var result = merger.Merge(list1, list2).ToList();

        // Assert
        CollectionAssert.IsEmpty(result);
    }
}