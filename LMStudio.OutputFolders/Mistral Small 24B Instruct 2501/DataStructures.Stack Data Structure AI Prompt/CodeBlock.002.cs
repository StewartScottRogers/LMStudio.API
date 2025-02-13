var stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
var (success, element) = stack.PopElementTuple;
Console.WriteLine(element); // Output: 2