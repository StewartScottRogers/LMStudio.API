using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackLibrary.Tests;

[TestClass]
public class StackTests
{
    /// <summary>
    /// Tests that a new stack is empty
    /// </summary>
    [TestMethod]
    public void Stack_IsEmpty_ReturnsTrue_ForNewStack()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        var result = stack.IsEmpty();
        
        // Assert
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Tests that a stack is not empty after pushing an element
    /// </summary>
    [TestMethod]
    public void Stack_IsEmpty_ReturnsFalse_AfterPush()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        
        // Act
        var result = stack.IsEmpty();
        
        // Assert
        Assert.IsFalse(result);
    }

    /// <summary>
    /// Tests that IsFull returns false for a new stack
    /// </summary>
    [TestMethod]
    public void Stack_IsFull_ReturnsFalse_ForNewStack()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        var result = stack.IsFull();
        
        // Assert
        Assert.IsFalse(result);
    }

    /// <summary>
    /// Tests that IsFull returns true when stack is full
    /// </summary>
    [TestMethod]
    public void Stack_IsFull_ReturnsTrue_WhenStackIsFull()
    {
        // Arrange
        var stack = new Stack<int>(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        // Act
        var result = stack.IsFull();
        
        // Assert
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Tests that Push adds an element to the top of the stack
    /// </summary>
    [TestMethod]
    public void Stack_Push_AddsElementToTop()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        
        // Act
        var result = stack.Peek();
        
        // Assert
        Assert.AreEqual(1, result);
    }

    /// <summary>
    /// Tests that Pop removes and returns the top element
    /// </summary>
    [TestMethod]
    public void Stack_Pop_RemovesAndReturnsTopElement()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        stack.Push(2);
        
        // Act
        var result = stack.Pop();
        
        // Assert
        Assert.AreEqual(2, result);
    }

    /// <summary>
    /// Tests that Peek returns the top element without removing it
    /// </summary>
    [TestMethod]
    public void Stack_Peek_ReturnsTopElementWithoutRemoving()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        stack.Push(2);
        
        // Act
        var firstPeekResult = stack.Peek();
        var secondPeekResult = stack.Peek();
        
        // Assert
        Assert.AreEqual(2, firstPeekResult);
        Assert.AreEqual(2, secondPeekResult);
    }

    /// <summary>
    /// Tests that Pop throws exception when stack is empty
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Stack_Pop_ThrowsException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act - This should throw an exception
        stack.Pop();
    }

    /// <summary>
    /// Tests that Peek throws exception when stack is empty
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Stack_Peek_ThrowsException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act - This should throw an exception
        stack.Peek();
    }

    /// <summary>
    /// Tests that Push throws exception when stack is full
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Stack_Push_ThrowsException_WhenStackIsFull()
    {
        // Arrange
        var stack = new Stack<int>(2);
        stack.Push(1);
        stack.Push(2);
        
        // Act - This should throw an exception
        stack.Push(3);
    }

    /// <summary>
    /// Tests that a stack works correctly with multiple operations
    /// </summary>
    [TestMethod]
    public void Stack_MultipleOperations_WorkCorrectly()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        stack.Push(1);
        stack.Push(2);
        var peekResult = stack.Peek();
        var popResult = stack.Pop();
        var isEmptyResult = stack.IsEmpty();
        stack.Push(3);
        var finalPeek = stack.Peek();
        
        // Assert
        Assert.AreEqual(2, peekResult);
        Assert.AreEqual(2, popResult);
        Assert.IsFalse(isEmptyResult);
        Assert.AreEqual(3, finalPeek);
    }
}