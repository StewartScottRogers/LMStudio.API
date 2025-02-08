using System;
using static System.Collections.Generic;

/// <summary>
/// A singleton implementation of a stack data structure that manages elements using an array.
/// The stack allows Push, Pop, Peek, IsEmpty, and IsFull operations with exception handling for invalid states.
/// </summary>
public class Stack
{
    private static readonly Stack _instance;
    private readonly object[] _elements;

    /// <summary>
    /// Initializes the stack with a default capacity of 16 elements.
    /// This constructor is not meant to be called directly; use CreateInstance instead.
    /// </summary>
    private Stack()
    {
        _instance = this;
        _elements = new object[16];
    }

    public static Stack CreateInstance()
    {
        if (_instance == null)
            new Stack();
        return _instance;
    }

    public void Push(object element)
    {
        if (IsFull)
            throw new ArgumentOutOfRangeException("Cannot push to a full stack.");

        _elements[Count] = element;
        Count++;
    }

    public object Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _elements[--Count];
    }

    public object Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _elements[Count - 1];
    }

    public bool IsEmpty => Count == 0;

    public bool IsFull
    {
        get { return Count == _elements.Length; }
    }

    private int Count
    {
        get; set;
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StackTests
{
    private readonly Stack stack = new Stack();

    [TestInitialize]
    public void Initialize()
    {
        stack.CreateInstance();
        stack.Push("One");
        stack.Push("Two");
        stack.Push("Three");
    }

    [TestMethod]
    public void Push_ShouldIncreaseCount()
    {
        Assert.AreEqual(3, stack.Count);
        stack.Push("Four");
        Assert.AreEqual(4, stack.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(OutOfRangeException))]
    public void Push_WhenFullThrows()
    {
        stack.Push("Fourth"); // Now count is 4
        stack.Push("Fifth"); // Count becomes 5 which exceeds capacity
    }

    [TestMethod]
    public void Pop_ShouldDecreaseCount()
    {
        Assert.AreEqual(3, stack.Count);
        stack.Pop();
        Assert.AreEqual(2, stack.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Pop_WhenEmptyThrows()
    {
        stack.Pop(); // Count is 0
    }

    [TestMethod]
    public void Peek_ShouldReturnTopElement()
    {
        Assert.AreEqual("Three", stack.Peek());
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Peek_WhenEmptyThrows()
    {
        stack.Pop();
        stack.Peek(); // Now count is 0
    }

    [TestMethod]
    public void IsFull_ReturnsTrueWhenStackIsFull()
    {
        stack.Push("Fourth");
        Assert.IsTrue(stack.IsFull);
    }

    [TestMethod]
    public void IsEmpty_ReturnsFalseWhenStackHasElements()
    {
        Assert.IsFalse(stack.IsEmpty);
    }
}