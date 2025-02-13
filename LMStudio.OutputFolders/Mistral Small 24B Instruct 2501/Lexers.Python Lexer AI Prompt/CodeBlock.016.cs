using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lexer Solution for Abstract Syntax Tree");
            // Run unit tests
            var testAssembly = Assembly.GetExecutingAssembly();
            var runner = new TestRunner(testAssembly);
            runner.RunTests();
        }
    }
}