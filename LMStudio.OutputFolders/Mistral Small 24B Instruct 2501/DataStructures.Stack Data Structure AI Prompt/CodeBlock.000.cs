using System;

namespace StackDataStructure.Interfaces
{
    /// <summary>
    /// Interface for stack data structure.
    /// </summary>
    public interface IStack<Type>
    {
        void Push(Type element);
        Type Pop();
        bool IsEmpty();
        bool IsFull();
        Type Peek();
    }
}