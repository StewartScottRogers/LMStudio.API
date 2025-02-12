// RoslynAstApplication.Tests/AbstractSyntaxTreeServiceTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoslynAstApplication.Tests
{
    [TestClass]
    public class AbstractSyntaxTreeServiceTests
    {
        private readonly IAbstractSyntaxTreeService astService = new AbstractSyntaxTreeService();

        [TestMethod]
        public void GenerateAstFromString_ShouldNotBeNull()
        {
            var code = "class Program { static void Main() {} }";
            var result = astService.GenerateAstFromString(code);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PrettyPrint_ShouldReturnStringRepresentation()
        {
            var code = "class Program { static void Main() {} }";
            var ast = astService.GenerateAstFromString(code);
            var prettyPrinted = astService.PrettyPrint(ast);

            Assert.IsFalse(string.IsNullOrEmpty(prettyPrinted));
            Assert.IsTrue(prettyPrinted.Contains("class"));
            Assert.IsTrue(prettyPrinted.Contains("Program"));
        }

        [TestMethod]
        public void ReflowCode_ShouldFormatCode()
        {
            var code = "class Program {static void Main(){} }";
            var ast = astService.GenerateAstFromString(code);
            var reflowedCode = astService.ReflowCode(ast);

            Assert.IsFalse(string.IsNullOrEmpty(reflowedCode));
            Assert.IsTrue(reflowedCode.Contains("class Program"));
            Assert.IsTrue(reflowedCode.Contains("{\n    static void Main()\n    {\n    }\n}"));
        }

        // Add more tests as needed...
    }
}