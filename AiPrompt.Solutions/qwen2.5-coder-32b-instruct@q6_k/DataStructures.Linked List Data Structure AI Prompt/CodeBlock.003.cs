using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void InsertAtBeginning_SingleElement_ListNotEmpty()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(10);
        Assert.IsFalse(list.IsEmpty);
    }

    [TestMethod]
    public void SearchElement_ElementPresent_ReturnsTrueAndValue()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(20);

        var resultTuple = list.SearchElement(20);
        Assert.IsTrue(resultTuple.Success);
        Assert.AreEqual(20, resultTuple.Value);
    }

    [TestMethod]
    public void SearchElement_ElementNotPresent_ReturnsFalseAndDefaultValue()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(15);

        var resultTuple = list.SearchElement(20);
        Assert.IsFalse(resultTuple.Success);
        Assert.AreEqual(default(int), resultTuple.Value);
    }

    [TestMethod]
    public void DeleteElement_ElementPresent_ReturnsTrueAndRemoves()
    {
        var list = new LinkedList();
        list.InsertAtBeginning(10);

        var deleteResult = list.DeleteElement(10);
        Assert.IsTrue(deleteResult);
        Assert.IsTrue(list.IsEmpty);
    }
}