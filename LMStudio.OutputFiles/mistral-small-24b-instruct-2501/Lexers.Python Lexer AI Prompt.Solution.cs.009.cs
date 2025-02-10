using System;

namespace PythonLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = new Lexer();
            var inputStream = "example python code";
            var tokens = lexer.Lex(inputStream);
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
        }
    }

**File Structure:**