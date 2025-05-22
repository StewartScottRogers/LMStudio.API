using System;
using System.Collections.Generic;

namespace MyStackProject.Interfaces
{
    public interface IMyStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
        bool IsFull(int maxSize);
        T Peek();
    }
}