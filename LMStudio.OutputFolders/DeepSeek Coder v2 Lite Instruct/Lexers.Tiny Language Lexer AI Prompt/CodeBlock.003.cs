using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerProject.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestBasicLexing()
        {
            var lexer = new Lexer("x := 10 + 5; print x;");
            var tokens = new List<Token>();

            while (true)
            {
                var token = lexer.GetNextToken();
                if (token.Type == TokenType.EOF) break;
                tokens.Add(token);
            }

            // Assert the tokens list against expected values
        }
    }
}