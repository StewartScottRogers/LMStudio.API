```csharp
using System;

namespace MyStackNamespace
{
    public class MyStack<T>
    {
        private T[] _stackArray; 
        private int _topIndex = -1;  
        
        public MyStack(int size) => _stackArray = new T[size];
       
        public bool IsEmpty() => _topIndex == -1;
        
        public bool IsFull() => _topIndex == _stackArray.Length - 1;

        public void Push(T item)
        {   
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            _stackArray[++_topIndex] = item;  
        }
       
        public T Pop()
        {
            if (IsEmpty()) 
                throw new InvalidOperationException("Stack is empty.");
            return _stackArray[_topIndex--];    
        }
       
        public T Peek()
        {  
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty."); 
            return _stackArray[_topIndex];      
        }     
    }
}
```
This code provides a generic stack implementation in C# with the desired functionality: push, pop, peek, check if it's full and empty. The size of the stack is determined when creating an instance of this class. 

Note that it would be wise to further validate the types T used on the stack, especially for operations like comparing elements (for a Priority Queue) or performing mathematical operations (for a Statistics Stack etc).

Here's how you can use `MyStack` class:
```csharp
var myStack = new MyStack<int>(10);
myStack.Push(23); // Push an item to stack
Console.WriteLine(myStack.Pop()); // Pop an item from stack
bool isEmpty = myStack.IsEmpty(); // Check if the stack is empty 
```