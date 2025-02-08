using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListItemTests
{
    private LinkedList<int> linkedList;

    [TestInitialize]
    public void TestInitialize()
    {
        linkedList = new LinkedList<int>();
    }

    [TestMethod]
    public void InsertAtBeginning_AddsElement_CanBeFound()
    {
        linkedList.InsertAtBeginning(1);
        Assert.IsTrue(linkedList.Search(1));
    }

    [TestMethod]
    public void Search_ElementExists_ReturnsTrue()
    {
        linkedList.InsertAtBeginning(2);
        linkedList.InsertAtBeginning(3);
        Assert.IsTrue(linkedList.Search(2));
    }

    [TestMethod]
    public void Search_ElementDoesNotExist_ReturnsFalse()
    {
        linkedList.InsertAtBeginning(4);
        Assert.IsFalse(linkedList.Search(5));
    }

    [TestMethod]
    public void Delete_ElementExists_RemovesElement()
    {
        linkedList.InsertAtBeginning(6);
        linkedList.Delete(6);
        Assert.IsFalse(linkedList.Search(6));
    }

    [TestMethod]
    public void Traverse_ListNotEmpty_ReturnsAllElements()
    {
        linkedList.InsertAtBeginning(7);
        linkedList.InsertAtBeginning(8);
        var elements = new List<int>();
        foreach (var element in linkedList.Traverse())
            elements.Add(element);

        CollectionAssert.AreEqual(new[] { 8, 7 }, elements.ToArray());
    }

    [TestMethod]
    public void Delete_HeadElement_RemovesHead()
    {
        linkedList.InsertAtBeginning(9);
        linkedList.Delete(9);
        Assert.IsTrue(linkedList.IsEmpty);
    }
}