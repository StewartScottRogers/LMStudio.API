using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructuresTests;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void InsertAtBeginning_AddsElementToHead()
    {
        var list = new LinkedList<int>();
        list.InsertAtBeginning(1);
        Assert.AreEqual(list.SearchElement(1).Value, 1);
    }

    [TestMethod]
    public void DeleteElement_RemovesExistingElement()
    {
        var list = new LinkedList<int>();
        list.InsertAtBeginning(2);
        list.InsertAtBeginning(3);
        Assert.IsTrue(list.DeleteElement(3));
        Assert.IsNull(list.SearchElement(3));
    }

    [TestMethod]
    public void DeleteElement_DoesNotRemoveNonexistentElement()
    {
        var list = new LinkedList<int>();
        list.InsertAtBeginning(4);
        Assert.IsFalse(list.DeleteElement(5));
    }

    [TestMethod]
    public void SearchElement_FindsExistingElement()
    {
        var list = new LinkedList<string>();
        list.InsertAtBeginning("hello");
        list.InsertAtBeginning("world");
        var foundNode = list.SearchElement("hello");
        Assert.IsNotNull(foundNode);
        Assert.AreEqual(foundNode.Value, "hello");
    }

    [TestMethod]
    public void SearchElement_ReturnsNullForNonexistentElement()
    {
        var list = new LinkedList<string>();
        list.InsertAtBeginning("hello");
        list.InsertAtBeginning("world");
        var foundNode = list.SearchElement("goodbye");
        Assert.IsNull(foundNode);
    }

    [TestMethod]
    public void Count_ReflectsNumberOfElements()
    {
        var list = new LinkedList<int>();
        list.InsertAtBeginning(1);
        list.InsertAtBeginning(2);
        list.DeleteElement(1);
        Assert.AreEqual(list.Count, 1);
    }
}