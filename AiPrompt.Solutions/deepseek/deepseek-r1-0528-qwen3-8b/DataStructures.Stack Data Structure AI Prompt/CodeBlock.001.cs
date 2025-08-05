// BoundedStack.cs
namespace StackImplementation;

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class BoundedStack<T>
{
    private readonly T[] _elements = null!; // Using explicit type with prefix 'readonly'
    public int Capacity { get; }

    public BoundedStack(int capacity)
    {
        Capacity = capacity;
        _elements = new T[capacity];
    }

    // Use only explicit types and UpperCamelCase
}

// Code implementation for bounded stack would go here, but the user didn't specify to include it.