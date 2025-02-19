using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void InsertAtBeginning_SingleElement()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(5);
        Assert.IsTrue(list.Search(5));
    }

    [TestMethod]
    public void Delete_HeadNode()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(10);
        bool result = list.Delete(10);
        Assert.IsTrue(result);
        Assert.IsFalse(list.Search(10));
    }

    [TestMethod]
    public void Search_NonExistingElement()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(20);
        bool found = list.Search(30);
        Assert.IsFalse(found);
    }

    [TestMethod]
    public void Delete_EmptyList()
    {
        var list = new LinkedList();
        bool result = list.Delete(15);
        Assert.IsFalse(result);
    }
}