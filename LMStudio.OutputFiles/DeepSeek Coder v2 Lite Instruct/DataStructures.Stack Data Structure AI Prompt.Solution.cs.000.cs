using System;

namespace DataStructures
{
    public class Stack<T>
    {
        private readonly int _size;
        private readonly T[] _items;
        private int _top;

        public Stack(int size)
        {
            _size = size;
            _items = new T[_size];
            _top = -1;
        }

        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            _items[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return _items[_top--];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return _items[_top];
        }

        public bool IsEmpty() => _top == -1;

        public bool IsFull() => _top == _size - 1;
    }
}