using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestInsertAndSearch()
    {
        var list = new LinkedList();

        // Insert 3, 1, 4, 2 and search for each
        list.InsertAtBeginning(3);
        list.InsertAtBeginning(1);
        list.InsertAtBeginning(4);
        list.InsertAtBeginning(2);

        var foundNode;
        Assert.IsTrue(list.Search(3, out foundNode), "3 was not found");
        Assert.AreEqual(foundNode?.data, 3);

        Assert.IsTrue(list.Search(1, out foundNode), "1 was not found");
        Assert.AreEqual(foundNode?.data, 1);

        // ... more tests for other elements and edge cases
    }

    [TestMethod]
    public void TestDelete()
    {
        var list = new LinkedList();

        // Insert 3, 1, 4, 2 and delete each one
        list.InsertAtBeginning(3);
        list.InsertAtBeginning(1);
        list.InsertAtBeginning(4);
        list.InsertAtBeginning(2);

        list.Delete(list._head);

        var foundNode;
        Assert.IsFalse(list.Search(3, out foundNode), "3 was still found after deletion");
        Assert.AreEqual(foundNode, null);

        // ... more tests for other elements and edge cases
    }
}