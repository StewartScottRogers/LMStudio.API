// LinkedListTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public sealed class LinkedListTests
{
    private LinkedList linkedList;

    [TestInitialize]
    public void Setup()
    {
        linkedList = new LinkedList();
    }

    [TestMethod]
    public void InsertAtBeginning_ShouldAddElementAtFront()
    {
        linkedList.InsertAtBeginning(10);
        linkedList.InsertAtBeginning(20);

        Assert.IsTrue(linkedList.Search(20));
        Assert.IsTrue(linkedList.Search(10));
    }

    [TestMethod]
    public void Search_ShouldReturnTrueIfValueExists()
    {
        linkedList.InsertAtBeginning(30);
        Assert.IsTrue(linkedList.Search(30));
    }

    [TestMethod]
    public void Search_ShouldReturnFalseIfValueDoesNotExist()
    {
        Assert.IsFalse(linkedList.Search(40));
    }

    [TestMethod]
    public void Delete_ShouldRemoveElementFromList()
    {
        linkedList.InsertAtBeginning(50);
        linkedList.Delete(50);

        Assert.IsFalse(linkedList.Search(50));
    }

    [TestMethod]
    public void Delete_ShouldReturnFalseIfValueDoesNotExist()
    {
        Assert.IsFalse(linkedList.Delete(60));
    }
}