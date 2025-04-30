using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestSimpleAssignments()
    {
        var input = "x := 5; y := 10;";
        var lexer = new Lexer(input);
        var expectedTokens = new List<Token>
        {
            new Token(TokenType.Identifier, "x"),
            new Token(TokenType.ColonEquals, ":="),
            new Token(TokenType.Number, "5"),
            new Token(TokenType.Semicolon, ";"),
            new Token(TokenType.Identifier, "y"),
            new Token(TokenType.ColonEquals, ":="),
            new Token(TokenType.Number, "10"),
            new Token(TokenType.Semicolon, ";"),
            new Token(TokenType.EndOfFile, "")
        };

        foreach (var expected in expectedTokens)
        {
            var actual = lexer.NextToken();
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Value, actual.Value);
        }
    }

    [TestMethod]
    public void TestIfStatements()
    {
        var input = "if x > 10 then print y; end";
        var lexer = new Lexer(input);
        var expectedTokens = new List<Token>
        {
            new Token(TokenType.IfKeyword, "if"),
            new Token(TokenType.Identifier, "x"),
            new Token(TokenType.GreaterThan, ">"),  // Note: This is not implemented in the lexer, so you need to add support
            new Token(TokenType.Number, "10"),
            new Token(TokenType.ThenKeyword, "then"),
            new Token(TokenType.PrintKeyword, "print"),
            new Token(TokenType.Identifier, "y"),
            new Token(TokenType.Semicolon, ";"),
            new Token(TokenType.EndKeyword, "end"),
            new Token(TokenType.EndOfFile, "")
        };

        foreach (var expected in expectedTokens)
        {
            var actual = lexer.NextToken();
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Value, actual.Value);
        }
    }

    // Add 23 more test methods here
}