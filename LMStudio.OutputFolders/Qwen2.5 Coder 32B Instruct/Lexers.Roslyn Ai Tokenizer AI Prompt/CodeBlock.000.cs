using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace AstGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "int x = 10;";

            // Generate AST from the given code
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = (CompilationUnitSyntax)syntaxTree.GetRoot();

            // Pretty print the AST
            var prettyPrinter = new SyntaxTreePrettyPrinter();
            prettyPrinter.Print(root);

            // Reflow the AST and execute the code
            var reflowGenerator = new SyntaxTreeReflowGenerator();
            string generatedCode = reflowGenerator.Reflow(root);
            Console.WriteLine("Generated Code:");
            Console.WriteLine(generatedCode);

            // Execute the generated code
            object result = CSharpScript.EvaluateAsync(code).Result;
            Console.WriteLine($"Execution Result: {result}");
        }
    }
}