using System;
using System.Collections.Generic;

namespace StackLibrary
{
    public class CustomStack<T>
    {
        private readonly List<T> stackList = new();
        private readonly int capacity;

        public CustomStack(int capacity)
        {
            this.capacity = capacity;
        }

        public bool IsEmpty()
        {
            return stackList.Count == 0;
        }

        public bool IsFull()
        {
            return stackList.Count >= capacity;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Stack is full.");
            }
            stackList.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            var topItem = stackList[stackList.Count - 1];
            stackList.RemoveAt(stackList.Count - 1);
            return topItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stackList[stackList.Count - 1];
        }
    }
}