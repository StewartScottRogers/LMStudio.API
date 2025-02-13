using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerParserAST.Tests
{
    [TestClass]
    public class LexerTests
    {
        private readonly Lexer lexer;
        private readonly Tokenizer tokenizer;

        public LexerTests()
        {
            lexer = new Lexer("a=5");
            tokenizer = new Tokenizer(lexer.ReadToken());
        }

        [TestMethod]
        public void TestLexer()
        {
            Assert.AreEqual(new Token(typeof(IdentifierToken), "a"));
            Assert.AreEqual(new Token(typeof(EqualToken), "="));
            Assert.AreEqual(new Token(typeof(NumberToken), "5"));
        }
    }
}