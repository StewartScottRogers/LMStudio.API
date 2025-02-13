using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator.Tests
{
    [TestClass]
    public class AstPrettyPrinterTests
    {
        private readonly IAstPrettyPrinter prettyPrinter = new AbstractSyntaxTreePrettyPrinter();

        [TestMethod]
        public void PrettyPrint_ReturnsNonNullString()
        {
            var sourceCode = "class Program {}";
            SyntaxNode syntaxTreeRoot = CSharpSyntaxTree.ParseText(sourceCode).GetRoot();
            string result = prettyPrinter.PrettyPrint(syntaxTreeRoot);
            Assert.IsNotNull(result);
        }

        // Add 24 more unit tests for lexing the Abstract Syntax Tree.
    }
}