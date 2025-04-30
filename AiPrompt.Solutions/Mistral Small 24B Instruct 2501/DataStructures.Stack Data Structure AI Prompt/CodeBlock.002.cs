using System;
using System.Collections.Generic;

namespace StackLibrary.Implementations
{
    public class StackImplementation<T> : IStackOperations<T>
        where T : notnull
    {
        private readonly int capacity;
        private readonly List<StackRecord<T>> stackRecords;

        public bool IsEmpty => stackRecords.Count == 0;
        public bool IsFull => stackRecords.Count >= capacity;

        public StackImplementation(int initialCapacity)
        {
            if (initialCapacity < 1) throw new ArgumentException("Initial capacity must be greater than zero.");

            this.capacity = initialCapacity;
            this.stackRecords = new List<StackRecord<T>>(capacity);
        }

        public void Push(T item)
        {
            if (IsFull) throw new InvalidOperationException("The stack is full.");
            
            stackRecords.Add(new StackRecord<T>(item));
        }

        public var PopTuple()
        {
            if (IsEmpty) throw new InvalidOperationException("The stack is empty.");

            T topItem = Peek();
            stackRecords.RemoveAt(stackRecords.Count - 1);

            return new { Value = topItem };
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("The stack is empty.");

            var topRecord = stackRecords[stackRecords.Count - 1];
            return topRecord.Value;
        }
    }
}