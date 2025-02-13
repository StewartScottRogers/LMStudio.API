using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoslynAstGenerator.Tests
{
    [TestClass]
    public class AstReflowGeneratorTests
    {
        [TestMethod]
        public void TestAstReflowGeneration()
        {
            // Add unit tests for AST reflow generation here.
            // Example:
            var syntaxTree = CSharpSyntaxTree.ParseText("using System;");
            var ast = syntaxTree.GetRoot();
            var refloedCode = AstReflowGenerator.ReflowAstToCode(ast);
            Assert.IsTrue(refloedCode.Contains("using System"));
        }
    }
}