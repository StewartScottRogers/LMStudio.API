using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestInsertAtBeginning()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(10);
        var searchTuple = linkedList.SearchElement(10);
        Assert.AreEqual(0, searchTuple.Position);
    }

    [TestMethod]
    public void TestSearchElementFound()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(20);
        linkedList.InsertAtBeginning(15);
        var searchTuple = linkedList.SearchElement(15);
        Assert.AreEqual(0, searchTuple.Position);
    }

    [TestMethod]
    public void TestSearchElementNotFound()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(25);
        var searchTuple = linkedList.SearchElement(30);
        Assert.AreEqual(-1, searchTuple.Position);
    }

    [TestMethod]
    public void TestDeleteElementSuccess()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(30);
        DeleteStatus status = linkedList.DeleteElement(30);
        Assert.AreEqual(DeleteStatus.Success, status);
    }

    [TestMethod]
    public void TestDeleteElementNotFound()
    {
        var linkedList = new LinkedList();
        linkedList.InsertAtBeginning(40);
        DeleteStatus status = linkedList.DeleteElement(50);
        Assert.AreEqual(DeleteStatus.ElementNotFound, status);
    }
}