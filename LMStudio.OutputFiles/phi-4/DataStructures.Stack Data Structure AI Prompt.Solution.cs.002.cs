using System;

namespace StackLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new StackRecord<int>(5);

            Console.WriteLine("Pushing elements onto the stack...");
            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
                Console.WriteLine($"Pushed: {i}");
            }

            Console.WriteLine("\nPeeking top element:");
            Console.WriteLine($"Top Element: {stack.Peek()}");

            Console.WriteLine("\nPopping elements from the stack...");
            while (!stack.IsEmpty())
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
            }
        }
    }
}