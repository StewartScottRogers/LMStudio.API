using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyAstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = @"
                using System;

                namespace ExampleNamespace
                {
                    public class ExampleClass
                    {
                        public int Add(int a, int b) => a + b;
                    }
                }";

            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var rootNode = (CompilationUnitSyntax)syntaxTree.GetRoot();

            // Pretty print the AST
            Console.WriteLine(new AbstractSyntaxTreePrettyPrinter().Print(rootNode));

            // Generate code from AST and execute it using Roslyn
            var generatedCode = new AstReflowGenerator().Generate(rootNode);
            RoslynHelper.Execute(generatedCode);

            // Run Unit Tests
            MyAstApp.Tests.UnitTest1.RunTests();
        }
    }
}