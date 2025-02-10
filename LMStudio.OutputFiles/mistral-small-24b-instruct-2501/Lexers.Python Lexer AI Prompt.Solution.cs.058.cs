using System;
using Microsoft.VisualBasic;

namespace LexerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = new Lexer();
            var input = "print('Hello, World!')";
            var tokens = lexer.Lex(input);
            foreach (var token in tokens)
            {
                Console.WriteLine(token.ToString());
            }
        }
    }
}