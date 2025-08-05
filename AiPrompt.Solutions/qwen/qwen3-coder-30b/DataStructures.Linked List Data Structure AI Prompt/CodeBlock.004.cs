using LinkedList.Core;
using LinkedList.Core.Interfaces;

namespace LinkedList.Tests;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void InsertAtBeginning_EmptyList_AddsElement()
    {
        // Arrange
        var list = new LinkedList<int>();
        
        // Act
        list.InsertAtBeginning(10);
        
        // Assert
        Assert.AreEqual(1, list.Count);
        CollectionAssert.AreEqual(new[] { 10 }, list.GetAllElements());
    }

    [TestMethod]
    public void InsertAtBeginning_NonEmptyList_AddsElementToBeginning()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        
        // Act
        list.InsertAtBeginning(20);
        
        // Assert
        Assert.AreEqual(2, list.Count);
        CollectionAssert.AreEqual(new[] { 20, 10 }, list.GetAllElements());
    }

    [TestMethod]
    public void Search_ElementExists_ReturnsFoundAndPosition()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        
        // Act
        var result = list.Search(10);
        
        // Assert
        Assert.IsTrue(result.Found);
        Assert.AreEqual(1, result.Position);
    }

    [TestMethod]
    public void Search_ElementDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        
        // Act
        var result = list.Search(30);
        
        // Assert
        Assert.IsFalse(result.Found);
        Assert.AreEqual(-1, result.Position);
    }

    [TestMethod]
    public void Delete_ElementExists_RemovesElement()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        list.InsertAtBeginning(30);
        
        // Act
        var result = list.Delete(20);
        
        // Assert
        Assert.IsTrue(result.Deleted);
        Assert.AreEqual(1, result.Position);
        CollectionAssert.AreEqual(new[] { 30, 10 }, list.GetAllElements());
    }

    [TestMethod]
    public void Delete_ElementDoesNotExist_ReturnsNotDeleted()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        
        // Act
        var result = list.Delete(30);
        
        // Assert
        Assert.IsFalse(result.Deleted);
        Assert.AreEqual(-1, result.Position);
    }

    [TestMethod]
    public void Delete_FirstElement_RemovesFirstElement()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        list.InsertAtBeginning(30);
        
        // Act
        var result = list.Delete(30);
        
        // Assert
        Assert.IsTrue(result.Deleted);
        Assert.AreEqual(0, result.Position);
        CollectionAssert.AreEqual(new[] { 20, 10 }, list.GetAllElements());
    }

    [TestMethod]
    public void Contains_ElementExists_ReturnsTrue()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        
        // Act & Assert
        Assert.IsTrue(list.Contains(10));
    }

    [TestMethod]
    public void Contains_ElementDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        
        // Act & Assert
        Assert.IsFalse(list.Contains(30));
    }

    [TestMethod]
    public void GetAllElements_EmptyList_ReturnsEmptyArray()
    {
        // Arrange
        var list = new LinkedList<int>();
        
        // Act
        var result = list.GetAllElements();
        
        // Assert
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void GetAllElements_NonEmptyList_ReturnsAllElements()
    {
        // Arrange
        var list = new LinkedList<string>();
        list.InsertAtBeginning("C");
        list.InsertAtBeginning("B");
        list.InsertAtBeginning("A");
        
        // Act
        var result = list.GetAllElements();
        
        // Assert
        CollectionAssert.AreEqual(new[] { "A", "B", "C" }, result);
    }

    [TestMethod]
    public void Count_IncreasesWhenAddingElements()
    {
        // Arrange
        var list = new LinkedList<int>();
        
        // Act & Assert
        Assert.AreEqual(0, list.Count);
        
        list.InsertAtBeginning(10);
        Assert.AreEqual(1, list.Count);
        
        list.InsertAtBeginning(20);
        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void Count_DecreasesWhenDeletingElements()
    {
        // Arrange
        var list = new LinkedList<int>();
        list.InsertAtBeginning(10);
        list.InsertAtBeginning(20);
        list.InsertAtBeginning(30);
        
        // Act & Assert
        Assert.AreEqual(3, list.Count);
        
        list.Delete(20);
        Assert.AreEqual(2, list.Count);
        
        list.Delete(10);
        Assert.AreEqual(1, list.Count);
    }
}