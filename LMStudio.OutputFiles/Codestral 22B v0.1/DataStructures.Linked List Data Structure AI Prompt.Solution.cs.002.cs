[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void Search_ElementExists_ReturnsTrue()
    {
        // Arrange
        var linkedList = new LinkedList();
        linkedList.Insert(1);
        linkedList.Insert(2);

        // Act
        var result = linkedList.Search(2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Insert_AddsElementAtBeginning()
    {
        // Arrange
        var linkedList = new LinkedList();
        linkedList.Insert(1);

        // Act & Assert
        Assert.IsTrue(linkedList.Search(1));
    }

    [TestMethod]
    public void Delete_RemovesElementIfExists()
    {
        // Arrange
        var linkedList = new LinkedList();
        linkedList.Insert(1);
        linkedList.Insert(2);

        // Act
        var result = linkedList.Delete(1);

        // Assert
        Assert.IsTrue(result);
        Assert.IsFalse(linkedList.Search(1));
    }
}