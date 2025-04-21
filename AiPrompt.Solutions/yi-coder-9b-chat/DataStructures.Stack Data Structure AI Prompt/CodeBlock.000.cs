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