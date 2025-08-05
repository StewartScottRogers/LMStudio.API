// UnboundedStack.cs
namespace StackImplementation;

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class UnboundedStack<T>
{
    private readonly List<T> elements = new();

    public bool IsEmpty() => elements.Count == 0; // Using explicit types and UpperCamelCase naming
    
}

// Code implementation for unbounded stack would go here, but the user didn't specify to include it.