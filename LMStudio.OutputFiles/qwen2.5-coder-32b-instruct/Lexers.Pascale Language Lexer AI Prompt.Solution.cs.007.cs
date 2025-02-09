using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests {
    private static readonly List<(string input, Token expected)> TestCases = new() {
        ("program", new Token(TokenType.Keyword, "program", 1, 1)),
        ("42", new Token(TokenType.IntegerLiteral, "42", 1, 1)),
        ("3.14", new Token(TokenType.RealLiteral, "3.14", 1, 1)),
        ("'Hello World'", new Token(TokenType.StringLiteral, "Hello World", 1, 1)),
        ("+", new Token(TokenType.Operator, "+", 1, 1)),
        (";", new Token(TokenType.Delimiter, ";", 1, 1)),
    };

    [TestMethod]
    public void TestLexer() {
        foreach (var (input, expected) in TestCases) {
            var lexer = new Lexer(input);
            var token = lexer.NextToken();
            
            Assert.AreEqual(expected.Type, token.Type, $"Type mismatch for input '{input}'.");
            Assert.AreEqual(expected.Value, token.Value, $"Value mismatch for input '{input}'.");
            Assert.AreEqual(expected.Line, token.Line, $"Line number mismatch for input '{input}'.");
            Assert.AreEqual(expected.Column, token.Column, $"Column number mismatch for input '{input}'.");
        }
    }

    [TestMethod]
    public void TestEmptyString() {
        var lexer = new Lexer(string.Empty);
        var token = lexer.NextToken();
        
        Assert.AreEqual(TokenType.EOF, token.Type, "Type mismatch for empty string.");
        Assert.AreEqual(string.Empty, token.Value, "Value mismatch for empty string.");
        Assert.AreEqual(1, token.Line, "Line number mismatch for empty string.");
        Assert.AreEqual(1, token.Column, "Column number mismatch for empty string.");
    }

    [TestMethod]
    public void TestCommentsAndWhitespace() {
        var lexer = new Lexer("   \t\nprogram programName;"); // Simulate comments and whitespace
        var token = lexer.NextToken();
        
        Assert.AreEqual(TokenType.Keyword, token.Type, $"Type mismatch for input '   \\t\\nprogram programName;'.");
        Assert.AreEqual("program", token.Value, $"Value mismatch for input '   \\t\\nprogram programName;'.");
    }
}