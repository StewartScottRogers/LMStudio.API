using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Collections.Generic;

namespace RoslynAstGenerator.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceCode = @"
                using System;
                class Program 
                { 
                    static void Main() 
                    { 
                        Console.WriteLine(""Hello, World!""); 
                    } 
                }
            ";

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            Compilation compilation = CSharpCompilation.Create(
                "Program",
                new[] { syntaxTree },
                new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));

            var astPrettyPrinter = new AbstractSyntaxTreePrettyPrinter();
            string prettyPrintedAst = astPrettyPrinter.PrettyPrint(syntaxTree.GetRoot());
            System.Console.WriteLine("Pretty Printed AST:\n" + prettyPrintedAst);

            var astReflowGenerator = new AbstractSyntaxTreeReflowGenerator();
            bool isSuccessful = astReflowGenerator.ReflowAndExecute(compilation);
            if (!isSuccessful)
            {
                System.Console.WriteLine("Failed to Reflow and Execute the code.");
            }
        }
    }
}