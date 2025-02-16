using System;

namespace MyStack
{
    public class Stack
    {
        private readonly int[] items;
        private int top = -1;

        public Stack(int size)
        {
            items = new int[size];
        }

        public void Push(int item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            items[++top] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return items[top--];
        }

        public bool IsEmpty() => top == -1;

        public bool IsFull() => top == items.Length - 1;

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return items[top];
        }
    }
}