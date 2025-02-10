using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LexerLibraryTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestLexing()
        {
            var input = "if (a > 1) then print a end";
            var lexer = new Lexer(input);
            var tokens = new List<Token>();

            Token token;
            while ((token = lexer.GetNextToken()).Type != TokenType.EOF)
            {
                tokens.Add(token);
            }

            // Add assertions for expected tokens
            Assert.AreEqual(10, tokens.Count);
            Assert.AreEqual(TokenType.If, tokens[0].Type);
            Assert.AreEqual("(", tokens[1].Value);
            Assert.AreEqual(TokenType.Id, tokens[2].Type);
            Assert.AreEqual(">", tokens[4].Value);
            Assert.AreEqual(TokenType.Number, tokens[5].Type);
            // Add more assertions as needed
        }
    }
}