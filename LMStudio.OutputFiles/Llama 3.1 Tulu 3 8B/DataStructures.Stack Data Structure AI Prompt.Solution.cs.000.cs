using System.Collections;

namespace StackLibrary
{
    public class Stack<T>
    {
        private const int DEFAULT_CAPACITY = 100;
        private int _topIndex;
        private T[] _items;

        // Constructor with optional capacity
        public Stack(int capacity = DEFAULT_CAPACITY)
        {
            _items = new T[capacity];
            _topIndex = -1; // Indicating an empty stack
        }

        // Other methods go here...
    }
}