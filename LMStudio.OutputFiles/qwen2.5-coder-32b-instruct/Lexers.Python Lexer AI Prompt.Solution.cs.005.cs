using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class LexerTests
    {
        private PythonLexer.Lexer CreateLexer(string input)
        {
            return new PythonLexer.Lexer(new System.IO.StringReader(input));
        }

        [TestMethod]
        public void TestSimpleTokenization()
        {
            var lexer = CreateLexer("print('Hello, World!')");
            var tokens = new List<PythonLexer.Token>(lexer.Tokenize());
            
            // Assert statements
            Assert.AreEqual(4, tokens.Count);  // print, (, string literal, )
            Assert.AreEqual(PythonLexer.TokenType.Keyword, tokens[0].Type);
            Assert.AreEqual("print", tokens[0].Value);

            Assert.AreEqual(PythonLexer.TokenType.Operator, tokens[1].Type);
            Assert.AreEqual("(", tokens[1].Value);

            Assert.AreEqual(PythonLexer.TokenType.String, tokens[2].Type);
            Assert.AreEqual("'Hello, World!'", tokens[2].Value);

            Assert.AreEqual(PythonLexer.TokenType.Operator, tokens[3].Type);
            Assert.AreEqual(")", tokens[3].Value);
        }

        // Add more tests as required
    }
}