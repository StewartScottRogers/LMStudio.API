using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the lexer and pretty printer.
            var lexer = new Lexer();
            var input = "def exampleFunction():\n    return 42";
            var tokens = lexer.Lex(input);
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            var astPrettyPrinter = new AstPrettyPrinter();
            var prettyPrintedAst = astPrettyPrinter.PrettyPrint(tokens);
            Console.WriteLine(prettyPrintedAst);

**File Structure:**