var stack = new Stack<int>(5); // Create a stack with a maximum size of 5
stack.Push(1);
int topElement = stack.Peek();
bool isFull = stack.IsFull();