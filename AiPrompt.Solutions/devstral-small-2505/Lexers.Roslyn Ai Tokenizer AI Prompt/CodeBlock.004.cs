using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyAstApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddition()
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

            var syntaxTree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(code);
            var rootNode = (Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax)syntaxTree.GetRoot();

            // Pretty print the AST
            Console.WriteLine(new MyAstApp.AbstractSyntaxTreePrettyPrinter().Print(rootNode));

            // Generate code from AST and execute it using Roslyn
            var generatedCode = new MyAstApp.AstReflowGenerator().Generate(rootNode);
            MyAstApp.RoslynHelper.Execute(generatedCode);

            Assert.IsTrue(true);  // Placeholder assertion for demonstration purposes
        }

        public static void RunTests()
        {
            UnitTest1 testInstance = new UnitTest1();
            testInstance.TestAddition();
        }
    }
}