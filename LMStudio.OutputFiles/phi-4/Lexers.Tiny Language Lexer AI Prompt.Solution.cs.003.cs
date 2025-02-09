using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TinyLanguageLexer.Tests
{
    [TestClass]
    public class LexerTests
    {
        private IEnumerable<Token> Lex(string input)
        {
            var lexer = new Lexer(input);
            return lexer.Lex();
        }

        [TestMethod]
        public void TestLexIdentifiers()
        {
            var tokens = Lex("x := 10");
            Assert.AreEqual("IDENTIFIER", tokens.GetEnumerator().Current.Type);
        }

        // Add more tests for each grammar rule and edge case
    }
}