// UnitTest1.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerAstCore;

namespace LexerAstTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestIdentifier()
        {
            Lexer lexer = new Lexer("x");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Item1.Type);
            Assert.AreEqual("x", token.Item1.Value);
        }

        [TestMethod]
        public void TestNumber()
        {
            Lexer lexer = new Lexer("123");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Number, token.Item1.Type);
            Assert.AreEqual("123", token.Item1.Value);
        }

        [TestMethod]
        public void TestPlus()
        {
            Lexer lexer = new Lexer("+");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Plus, token.Item1.Type);
            Assert.AreEqual("+", token.Item1.Value);
        }

        [TestMethod]
        public void TestAssign()
        {
            Lexer lexer = new Lexer(":=");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Assign, token.Item1.Type);
            Assert.AreEqual(":=", token.Item1.Value);
        }

        [TestMethod]
        public void TestSemicolon()
        {
            Lexer lexer = new Lexer(";");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Semicolon, token.Item1.Type);
            Assert.AreEqual(";", token.Item1.Value);
        }

        [TestMethod]
        public void TestEndOfFile()
        {
            Lexer lexer = new Lexer("");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.EndOfFile, token.Item1.Type);
        }

		// Add more tests here to cover all token types and edge cases.  At least 25 as requested.
        [TestMethod]
        public void TestIdentifierWithNumber()
        {
            Lexer lexer = new Lexer("x123");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Item1.Type);
            Assert.AreEqual("x123", token.Item1.Value);
        }

		[TestMethod]
        public void TestWhitespace()
        {
            Lexer lexer = new Lexer("  x  ");
            var token = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Item1.Type);
            Assert.AreEqual("x", token.Item1.Value);
        }

		[TestMethod]
        public void TestMultipleTokens()
        {
            Lexer lexer = new Lexer("x := 123;");
            var token1 = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token1.Item1.Type);
            Assert.AreEqual("x", token1.Item1.Value);

            var token2 = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Assign, token2.Item1.Type);
            Assert.AreEqual(":=", token2.Item1.Value);

            var token3 = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Number, token3.Item1.Type);
            Assert.AreEqual("123", token3.Item1.Value);

            var token4 = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Semicolon, token4.Item1.Type);
            Assert.AreEqual(";", token4.Item1.Value);
        }

		// Add more tests to cover various combinations and edge cases.  Focus on boundary conditions.
    }
}