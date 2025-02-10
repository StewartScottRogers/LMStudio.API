using System;
using Microsoft.VisualBasic;

namespace LexerApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Lexer Application");
            var lexer = new Lexer();
            string input = "example input";
            var tokens = lexer.Lex(input);
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
        }
    }
}

I'll start by creating the necessary files and classes for the Lexer, Abstract Syntax Tree (AST), AST Pretty Printer, and Unit Tests. Here is the initial structure of the solution:

### File Structure