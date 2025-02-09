using System;
using RoslynAstGenerator.Ast;

namespace RoslynAstGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = @"
                using System;

                namespace TestNamespace
                {
                    public class TestClass
                    {
                        public int FieldOne { get; set; }

                        public void TestMethod()
                        {
                            Console.WriteLine(""Hello, World!"");
                        }
                    }
                }";

            var astGenerator = new AbstractSyntaxTreeGenerator(code);

            // Pretty print the AST
            Console.WriteLine("Pretty Printed AST:");
            Console.WriteLine(astGenerator.PrettyPrint());

            // Reflow and execute the code
            Console.WriteLine("Executing Generated Code...");
            astGenerator.ReflowAndExecute();
        }
    }
}