using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LexerLibrary.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestLexer()
        {
            var input = "x := 42 + y;";
            var lexer = new Lexer(input);
            var tokenStream = lexer.GenerateTokenStream();

            Assert.AreEqual(6, tokenStream.Tokens.Count);

            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Identifier && t.Value == "x"));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Assign));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Number && t.Value == "42"));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Plus));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Identifier && t.Value == "y"));
            Assert.IsTrue(tokenStream.Tokens.Any(t => t.Type == TokenType.Semicolon));
        }

        // Add more tests for different scenarios
    }
}