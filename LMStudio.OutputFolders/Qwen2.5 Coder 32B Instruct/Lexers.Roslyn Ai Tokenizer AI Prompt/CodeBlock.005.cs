using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace AstGeneratorTests
{
    [TestClass]
    public class AstNodeTests
    {
        private readonly LexicalAnalyzer lexicalAnalyzer = new();

        [TestMethod]
        public void TestLexicalAnalysis()
        {
            string code = "int x = 10;";
            var tokens = lexicalAnalyzer.Analyze(code).ToList();

            Assert.AreEqual(6, tokens.Count);

            Assert.AreEqual(SyntaxKind.IntKeyword, tokens[0].Kind());
            Assert.AreEqual("int", tokens[0].Text);

            Assert.AreEqual(SyntaxKind.IdentifierToken, tokens[1].Kind());
            Assert.AreEqual("x", tokens[1].Text);

            Assert.AreEqual(SyntaxKind.EqualsToken, tokens[2].Kind());
            Assert.AreEqual("=", tokens[2].Text);

            Assert.AreEqual(SyntaxKind.NumericLiteralToken, tokens[3].Kind());
            Assert.AreEqual("10", tokens[3].Text);

            Assert.AreEqual(SyntaxKind.SemicolonToken, tokens[4].Kind());
            Assert.AreEqual(";", tokens[4].Text);
        }

        [TestMethod]
        public void TestBoundaryConditions()
        {
            string code = "int a; int b;";
            var tokens = lexicalAnalyzer.Analyze(code).ToList();

            Assert.AreEqual(10, tokens.Count);

            Assert.AreEqual(SyntaxKind.IntKeyword, tokens[0].Kind());
            Assert.AreEqual("int", tokens[0].Text);
            Assert.AreEqual(SyntaxKind.IdentifierToken, tokens[1].Kind());
            Assert.AreEqual("a", tokens[1].Text);
            Assert.AreEqual(SyntaxKind.SemicolonToken, tokens[2].Kind());
            Assert.AreEqual(";", tokens[2].Text);

            Assert.AreEqual(SyntaxKind.IntKeyword, tokens[3].Kind());
            Assert.AreEqual("int", tokens[3].Text);
            Assert.AreEqual(SyntaxKind.IdentifierToken, tokens[4].Kind());
            Assert.AreEqual("b", tokens[4].Text);
            Assert.AreEqual(SyntaxKind.SemicolonToken, tokens[5].Kind());
            Assert.AreEqual(";", tokens[5].Text);
        }
    }
}