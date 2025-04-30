using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace RoslynAstGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string code = "public class SampleClass { public int SampleProperty { get; set; } }";
            
            // Parse the code into a syntax tree.
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            
            // Get the root of the syntax tree.
            var compilationUnit = (CSharpSyntaxNode)syntaxTree.GetRoot();
            
            Console.WriteLine("Abstract Syntax Tree Generated.");
        }
    }
}