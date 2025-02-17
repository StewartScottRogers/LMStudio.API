[TestClass]
public class MergableListTests
{
    [TestMethod]
    public void Merge_ReturnsSingleSortedList_WithAllElements()
    {
        // Arrange
        var lists = new List<IEnumerable<int>>()
        {
            Enumerable.Range(1, 5),
            Enumerable.Range(6, 3)
        };
        
        // Act
        var mergedList = new MergeableList<int>().Merge(lists);
        
        // Assert
        // Add assertions to validate the output.
    }
}