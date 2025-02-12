using System;
using PythonLexer.Lexers;

namespace PythonLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "return 42";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source);

            foreach (var node in nodes)
            {
                Console.WriteLine(node.GetType().Name);
            }
        }
    }
}