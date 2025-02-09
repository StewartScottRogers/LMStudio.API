// LexerTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyLanguageLexer;

namespace TinyLanguageTests
{
    [TestClass]
    public class LexerTests
    {
        private static Token[] Lex(string input)
        {
            var lexer = new Lexer(input);
            var tokens = new List<Token>();
            while (true)
            {
                var token = lexer.NextToken();
                if (token.Kind == TokenKind.Unknown || string.IsNullOrEmpty(token.Value))
                    break;
                tokens.Add(token);
            }
            return tokens.ToArray();
        }

        [TestMethod]
        public void TestLexSimpleAssignment()
        {
            var input = "x := 10;";
            var expectedTokens = new[]
            {
                new Token(TokenKind.Identifier, "x"),
                new Token(TokenKind.ColonEquals, ":="),
                new Token(TokenKind.Number, "10"),
                new Token(TokenKind.Semicolon, ";")
            };
            var actualTokens = Lex(input);
            CollectionAssert.AreEqual(expectedTokens, actualTokens);
        }

        [TestMethod]
        public void TestLexIfStatement()
        {
            var input = "if x > 5 then y := 2; end";
            var expectedTokens = new[]
            {
                new Token(TokenKind.IfKeyword, "if"),
                new Token(TokenKind.Identifier, "x"),
                new Token(TokenKind.GreaterThan, ">"), // Add GreaterThan to TokenKind and lexer
                new Token(TokenKind.Number, "5"),
                new Token(TokenKind.ThenKeyword, "then"),
                new Token(TokenKind.Identifier, "y"),
                new Token(TokenKind.ColonEquals, ":="),
                new Token(TokenKind.Number, "2"),
                new Token(TokenKind.Semicolon, ";"),
                new Token(TokenKind.EndKeyword, "end")
            };
            var actualTokens = Lex(input);
            CollectionAssert.AreEqual(expectedTokens, actualTokens);
        }

        [TestMethod]
        public void TestLexWhileStatement()
        {
            var input = "while x < 10 do y := y + 1; end";
            var expectedTokens = new[]
            {
                new Token(TokenKind.WhileKeyword, "while"),
                new Token(TokenKind.Identifier, "x"),
                new TokenKind.LessThan, "<"), // Add LessThan to TokenKind and lexer
                new Token(TokenKind.Number, "10"),
                new Token(TokenKind.DoKeyword, "do"),
                new Token(TokenKind.Identifier, "y"),
                new Token(TokenKind.ColonEquals, ":="),
                new Token(TokenKind.Identifier, "y"),
                new Token(TokenKind.Plus, "+"),
                new Token(TokenKind.Number, "1"),
                new Token(TokenKind.Semicolon, ";"),
                new Token(TokenKind.EndKeyword, "end")
            };
            var actualTokens = Lex(input);
            CollectionAssert.AreEqual(expectedTokens, actualTokens);
        }

        [TestMethod]
        public void TestLexPrintStatement()
        {
            var input = "print x + y;";
            var expectedTokens = new[]
            {
                new Token(TokenKind.PrintKeyword, "print"),
                new Token(TokenKind.Identifier, "x"),
                new Token(TokenKind.Plus, "+"),
                new Token(TokenKind.Identifier, "y"),
                new Token(TokenKind.Semicolon, ";")
            };
            var actualTokens = Lex(input);
            CollectionAssert.AreEqual(expectedTokens, actualTokens);
        }
    }
}