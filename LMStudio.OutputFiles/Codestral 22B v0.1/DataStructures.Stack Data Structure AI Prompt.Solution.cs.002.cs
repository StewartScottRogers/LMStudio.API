// StackUnitTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StackUnitTests
{
    [TestMethod]
    public void TestPushAndPop()
    {
        var stack = new StackClass<int>(5);
        stack.Push(1);
        Assert.AreEqual(1, stack.Pop());
    }

    // More tests for isEmpty, isFull, peek, etc.
}