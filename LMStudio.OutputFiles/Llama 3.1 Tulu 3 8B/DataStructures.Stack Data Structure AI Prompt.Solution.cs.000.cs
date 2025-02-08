using System;

  // Interface definition for the stack data structure operations.
  public interface IStack<T>
  {
      void Push(T item);
      T Pop();
      bool IsEmpty();
      bool IsFull(); // Assuming we have a fixed-size implementation here for simplicity.
      T Peek();
  }