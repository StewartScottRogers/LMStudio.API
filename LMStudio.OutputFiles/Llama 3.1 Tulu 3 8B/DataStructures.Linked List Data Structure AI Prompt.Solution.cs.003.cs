using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestAddFirst()
    {
        var list = new LinkedList<int>();
        list.AddFirst(10);
        Assert.AreEqual(1, list.Count);
        Assert.IsTrue(list.Contains(10));
    }

    [TestMethod]
    public void TestContains()
    {
        var list = new LinkedList<int> { 10, 20, 30 };
        Assert.IsTrue(list.Contains(10));
        Assert.IsTrue(list.Contains(20));
        Assert.IsTrue(list.Contains(30));
        Assert.IsFalse(list.Contains(5));
    }

    [TestMethod]
    public void TestRemove()
    {
        var list = new LinkedList<int> { 10, 20, 30 };
        list.Remove(20);
        Assert.AreEqual(2, list.Count);
        Assert.IsFalse(list.Contains(20));
        list.Remove(30);
        Assert.AreEqual(1, list.Count);
        Assert.IsTrue(list.Contains(10));
    }
}