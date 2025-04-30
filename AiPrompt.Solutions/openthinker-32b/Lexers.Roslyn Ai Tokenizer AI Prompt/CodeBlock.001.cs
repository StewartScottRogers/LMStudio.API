using Microsoft.CodeAnalysis.CSharp;
using System;

namespace RoslynPrettyPrinter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string code = "public class SampleClass { public int SampleProperty { get; set; } }";
            
            // Parse the code into a syntax tree.
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            
            var compilationUnit = (CSharpSyntaxNode)syntaxTree.GetRoot();
            
            Console.WriteLine("Pretty Printing Abstract Syntax Tree:");
            Console.WriteLine(compilationUnit.ToFullString());
        }
    }
}