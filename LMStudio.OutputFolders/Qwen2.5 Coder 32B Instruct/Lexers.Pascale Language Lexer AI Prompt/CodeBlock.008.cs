using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PascaleLexer.Tests
{
    [TestClass]
    public class LexerTests
    {
        private readonly IEnumerable<Token> tokenList;

        public LexerTests()
        {
            var lexer = new PascaleLexer.Lexer.PascaleLexer("program TestProgram; begin end.");
            tokenList = lexer.Lex().ToList();
        }

        [TestMethod]
        public void LexProgramToken()
        {
            Assert.AreEqual(TokenTypes.Program, tokenList.First().Type);
        }
        
        [TestMethod]
        public void LexIdentifierToken()
        {
            var identifierTokens = tokenList.Where(t => t.Type == TokenTypes.Identifier).ToList();
            Assert.AreEqual(1, identifierTokens.Count);
            Assert.AreEqual("TestProgram", identifierTokens[0].Value);
        }

        // Add more tests
    }
}