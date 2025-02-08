// Create a new instance of the stack with default capacity (16 elements)
Stack stack = Stack.CreateInstance();

// Push an element onto the stack
stack.Push("Element 1");

// Peek the top element without removing it
string topElement = stack.Peek(); // Outputs "Element 1"

// Pop the top element and check if empty
bool isEmpty = stack.IsEmpty();

// Try to pop when empty (throws exception)
try
{
    stack.Pop();
}
catch (InvalidOperationException)
{
    Console.WriteLine("Stack was empty");
}

// Check if the stack is full after adding elements
stack.Push("Element 2");
if (stack.IsFull) Console.WriteLine("Stack is full");