using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PascalLexerClassLibrary.UnitTests
{
    [TestClass]
    public class PascalLexerTests
    {
        [TestMethod]
        public void TestTokenizeIdentifier()
        {
            var lexer = new Lexer("program");
            var tokens = lexer.Tokenize();

            Assert.AreEqual(TokenType.Identifier, tokens[0].Type);
            Assert.AreEqual("program", tokens[0].Value);
        }

        // Add more unit tests for different parts of the grammar
    }
}