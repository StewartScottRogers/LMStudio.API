using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FixedSizeStackTests
{
    [TestMethod]
    public void Push_ShouldAddElementToTop()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        Assert.AreEqual(1, stack.Peek());
    }

    [TestMethod]
    public void Pop_ShouldRemoveAndReturnTopElement()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        stack.Push(2);
        int poppedValue = stack.Pop();
        Assert.AreEqual(2, poppedValue);
        Assert.AreEqual(1, stack.Peek());
    }

    [TestMethod]
    public void Pop_ShouldThrowExceptionIfEmpty()
    {
        var stack = new FixedSizeStack<int>(3);
        Assert.ThrowsException<StackUnderflowException>(() => stack.Pop());
    }

    [TestMethod]
    public void Peek_ShouldReturnTopElementWithoutRemovingIt()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        int peekedValue = stack.Peek();
        Assert.AreEqual(1, peekedValue);
        Assert.AreEqual(1, stack.Pop());
    }

    [TestMethod]
    public void Peek_ShouldThrowExceptionIfEmpty()
    {
        var stack = new FixedSizeStack<int>(3);
        Assert.ThrowsException<StackUnderflowException>(() => stack.Peek());
    }

    [TestMethod]
    public void IsEmpty_ShouldReturnTrueWhenNoElementsArePresent()
    {
        var stack = new FixedSizeStack<int>(3);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestMethod]
    public void IsFull_ShouldReturnFalseWhenNotAllCapacityIsUsed()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        Assert.IsFalse(stack.IsFull());
    }

    [TestMethod]
    public void IsFull_ShouldReturnTrueWhenAllCapacityIsUsed()
    {
        var stack = new FixedSizeStack<int>(2);
        stack.Push(1);
        stack.Push(2);
        Assert.IsTrue(stack.IsFull());
    }

    [TestMethod]
    public void Push_ShouldThrowExceptionIfFull()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.ThrowsException<StackOverflowException>(() => stack.Push(4));
    }
}