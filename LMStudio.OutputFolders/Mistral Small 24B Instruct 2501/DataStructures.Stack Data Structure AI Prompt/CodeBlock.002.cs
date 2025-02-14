using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StackTests
{
    [TestMethod]
    public void Push_ShouldIncrementTop()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        stack.Push(1);

        // Assert
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestMethod]
    public void Pop_ShouldDecrementTopAndReturnLastPushedElement()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);

        // Act
        int result = stack.Pop();

        // Assert
        Assert.AreEqual(1, result);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestMethod]
    public void IsEmpty_ShouldReturnTrueForNewStack()
    {
        // Arrange
        var stack = new Stack<int>(5);

        // Act & Assert
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestMethod]
    public void Peek_ShouldReturnTopElementWithoutRemovingIt()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);

        // Act
        int result = stack.Peek();

        // Assert
        Assert.AreEqual(1, result);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestMethod]
    public void IsFull_ShouldReturnTrueWhenStackIsFull()
    {
        // Arrange
        var stack = new Stack<int>(2);
        stack.Push(1);
        stack.Push(2);

        // Act & Assert
        Assert.IsTrue(stack.IsFull());
    }
}