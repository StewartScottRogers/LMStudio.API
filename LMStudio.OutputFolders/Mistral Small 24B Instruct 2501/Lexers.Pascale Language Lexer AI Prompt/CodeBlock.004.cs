// File: Program.cs
using System;

namespace PascaleLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"program Example;
                begin
                    var a := 5;
                    if a > 0 then write('Positive');
                end.";
            var lexer = new Lexer(input);
            var tokens = lexer.Tokenize();

            foreach (var token in tokens)
            {
                Console.WriteLine($"{token.Type}: {token.Value}");
            }

            // Add AST generation and printing logic here...
        }
    }
}