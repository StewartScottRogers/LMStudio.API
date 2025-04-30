using Microsoft.CodeAnalysis.CSharp;
using System;

namespace RoslynReflowGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string code = "public class SampleClass { public int SampleProperty { get; set; } }";
            
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilationUnit = (CSharpSyntaxNode)syntaxTree.GetRoot();
            
            Console.WriteLine("Reflowing Abstract Syntax Tree:");
            Console.WriteLine(compilationUnit.ToFullString());
        }
    }
}