using System;
  using System.Collections.Generic;

  public class Stack<T> : IStack<T>
  {
      private readonly List<T> _elements = new();

      // Property to check if the stack is empty
      public bool IsEmpty => _elements.Count == 0;

      // Assuming a fixed-size stack for simplicity.
      // In practice, you might want to use dynamic resizing or other strategies.
      private int MaxSize { get; } = 100;

      public void Push(T item)
      {
          if (_elements.Count >= MaxSize) throw new InvalidOperationException("Stack is full.");
          
          _elements.Add(item);
      }

      public T Pop()
      {
          if (IsEmpty) throw new InvalidOperationException("Stack is empty.");

          return _elements.RemoveAt(_elements.Count - 1); // Using a method to mimic 'pop' operation
      }

      public T Peek()
      {
          if (IsEmpty) throw new InvalidOperationException("Stack is empty.");
          
          return _elements[_elements.Count - 1];
      }

      // Method to check if stack is full, assuming MaxSize is defined.
      public bool IsFull => _elements.Count == MaxSize;
  }