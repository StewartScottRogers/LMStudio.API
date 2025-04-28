using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerAst.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void Lexer_Identifier()
        {
            Lexer lexer = new Lexer("myVariable");
            var (token, success) = lexer.GetNextToken();
            Assert.IsTrue(success);
            Assert.AreEqual(TokenType.Identifier, token.Type);
            Assert.AreEqual("myVariable", token.Value);
        }

        [TestMethod]
        public void Lexer_Number()
        {
            Lexer lexer = new Lexer("123");
            var (token, success) = lexer.GetNextToken();
            Assert.IsTrue(success);
            Assert.AreEqual(TokenType.Number, token.Type);
            Assert.AreEqual("123", token.Value);
        }

        [TestMethod]
        public void Lexer_Plus()
        {
            Lexer lexer = new Lexer("+");
            var (token, success) = lexer.GetNextToken();
            Assert.IsTrue(success);
            Assert.AreEqual(TokenType.Plus, token.Type);
            Assert.AreEqual("+", token.Value);
        }

        // Add more tests for other tokens and combinations of tokens
    }
}