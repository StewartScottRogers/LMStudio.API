using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynAstGenerator.Ast;
using System.Linq;

namespace RoslynAstGenerator.Tests
{
    [TestClass]
    public class AbstractSyntaxTreeGeneratorTests
    {
        private const string sampleCode = @"
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

        [TestMethod]
        public void PrettyPrint_ShouldReturnValidAstString()
        {
            var generator = new AbstractSyntaxTreeGenerator(sampleCode);
            var prettyPrintResult = generator.PrettyPrint();

            Assert.IsTrue(prettyPrintResult.Contains("using System;"));
            Assert.IsTrue(prettyPrintResult.Contains("public class TestClass"));
            Assert.IsTrue(prettyPrintResult.Contains("public void TestMethod()"));
        }

        [TestMethod]
        public void ReflowAndExecute_ShouldRunWithoutErrors()
        {
            var generator = new AbstractSyntaxTreeGenerator(sampleCode);
            generator.ReflowAndExecute();
        }
    }
}