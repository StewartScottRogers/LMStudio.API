using System;
using MyStackProject.Interfaces;

namespace MyStackProject.Models
{
    public class MyStack<T> : IMyStack<T>
    {
        private readonly List<T> stack = new();
        private readonly int maxSize;

        public MyStack(int size)
        {
            maxSize = size;
        }

        public void Push(T item)
        {
            if (IsFull(maxSize))
            {
                throw new InvalidOperationException("The stack is full.");
            }
            stack.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            var item = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return item;
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public bool IsFull(int maxSize)
        {
            return stack.Count >= maxSize;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            return stack[stack.Count - 1];
        }
    }
}