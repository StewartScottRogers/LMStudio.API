var stack = new Stack<int>(5);
stack.Push(10);
Console.WriteLine(stack.Peek()); // Outputs 10
stack.Pop();
Console.WriteLine(stack.IsEmpty()); // Outputs true