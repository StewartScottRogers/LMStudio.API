using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestInsertAtBeginning()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(10);

        Assert.IsTrue(linkedList.SearchElement(10));
    }

    [TestMethod]
    public void TestDeleteElement()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(10);
        linkedList.DeleteElement(10);

        Assert.IsFalse(linkedList.SearchElement(10));
    }

    [TestMethod]
    public void TestSearchElement()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(20);
        bool found = linkedList.SearchElement(20);

        Assert.IsTrue(found);
    }

    [TestMethod]
    public void TestGetAllElements()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(30);
        linkedList.InsertAtBeginning(20);
        linkedList.InsertAtBeginning(10);

        var elements = new List<int>();
        foreach (var value in linkedList.GetAllElements())
        {
            elements.Add(value);
        }

        CollectionAssert.AreEqual(new List<int> { 10, 20, 30 }, elements);
    }
}