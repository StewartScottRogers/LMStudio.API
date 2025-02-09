using System;
using System.Collections.Generic;

namespace StackLibrary
{
    /// <summary>
    /// Defines the operations available on a Stack data structure.
    /// </summary>
    public interface IStack<T>
    {
        bool IsEmpty();
        bool IsFull();
        void Push(T item);
        T Pop();
        T Peek();
    }
}