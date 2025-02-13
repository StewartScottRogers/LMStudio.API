using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoslynAstGenerator.Tests
{
    [TestClass]
    public class AstPrettyPrinterTests
    {
        [TestMethod]
        public void TestAstPrettyPrinting()
        {
            // Add unit tests for AST pretty printing here.
            // Example:
            var syntaxTree = CSharpSyntaxTree.ParseText("using System;");
            var ast = syntaxTree.GetRoot();
            var prettyPrintedAst = AstPrettyPrinter.PrettyPrint(ast);
            Assert.IsTrue(prettyPrintedAst.Contains("using System"));
        }
    }
}