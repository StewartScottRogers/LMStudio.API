using System;

namespace StackLibrary
{
    public class StackImplementation : IStack
    {
        private readonly StackDataStructure stack;
        private readonly int maxSize;

        public StackImplementation(int size)
        {
            if (size <= 0) throw new ArgumentException("Size must be greater than zero", nameof(size));
            maxSize = size;
            var elements = new int[maxSize];
            stack = new StackDataStructure(elements, -1);
        }

        public void Push(int element)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full");

            var topIndex = stack.Top + 1;
            var newArray = stack.Elements[..];
            newArray[topIndex] = element;

            stack = new StackDataStructure(newArray, topIndex);
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            var topElement = Peek();
            var topIndex = stack.Top - 1;
            var newArray = stack.Elements[..];
            newArray[topIndex + 1] = default;

            stack = new StackDataStructure(newArray, topIndex);
            return topElement;
        }

        public bool IsEmpty()
        {
            return stack.Top == -1;
        }

        public bool IsFull()
        {
            return stack.Top >= maxSize - 1;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return stack.Elements[stack.Top];
        }
    }
}