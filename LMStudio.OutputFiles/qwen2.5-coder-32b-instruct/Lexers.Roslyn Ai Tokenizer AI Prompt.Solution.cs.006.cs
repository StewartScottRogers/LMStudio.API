using RoslynAiTokenizer.Models;
using RoslynAiTokenizer.Services;

namespace RoslynAiTokenizer
{
    public class Program
    {
        private static readonly IAbstractSyntaxTreeParser AstParser = new AbstractSyntaxTreeParser();
        private static readonly IAbstractSyntaxTreePrettyPrinter PrettyPrinter = new AbstractSyntaxTreePrettyPrinter();
        private static readonly IAbstractSyntaxTreeReflowGenerator ReflowGenerator = new AbstractSyntaxTreeReflowGenerator();

        public static void Main(string[] args)
        {
            var sourceCode = @"
using System;

namespace Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}";
            
            var astNode = AstParser.ParseCode(sourceCode);
            var prettyPrintedAst = PrettyPrinter.PrettyPrint(astNode);
            var regeneratedCode = ReflowGenerator.RegenerateCode(astNode);

            Console.WriteLine("Pretty Printed AST:");
            Console.WriteLine(prettyPrintedAst);

            Console.WriteLine("\nReflowed Code:");
            Console.WriteLine(regeneratedCode);
        }
    }
}