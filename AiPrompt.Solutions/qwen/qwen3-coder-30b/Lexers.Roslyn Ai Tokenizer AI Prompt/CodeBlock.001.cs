using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTExplorer
{
    /// <summary>
    /// Main entry point for the Roslyn AST Explorer application.
    /// Demonstrates parsing C# code, generating AST, pretty printing, and code reflow.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Roslyn AST Explorer");
            Console.WriteLine("===================");
            
            // Sample C# code to parse
            string sampleCode = @"
                using System;
                namespace SampleNamespace
                {
                    public class SampleClass
                    {
                        private int _value;
                        
                        public SampleClass(int value)
                        {
                            _value = value;
                        }
                        
                        public int GetValue()
                        {
                            return _value;
                        }
                    }
                }";
            
            // Parse the code and generate AST
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sampleCode);
            var root = syntaxTree.GetRoot();
            
            Console.WriteLine("\nAST Pretty Print:");
            Console.WriteLine("----------------");
            AstPrettyPrinter.Print(root, 0);
            
            Console.WriteLine("\nReflowed Code:");
            Console.WriteLine("--------------");
            string reflowedCode = AstReflowGenerator.Reflow(root);
            Console.WriteLine(reflowedCode);
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}