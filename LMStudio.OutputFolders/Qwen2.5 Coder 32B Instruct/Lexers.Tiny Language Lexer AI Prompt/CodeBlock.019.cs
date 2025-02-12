using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    private readonly ILexer lexer = new Lexer("");

    [TestMethod]
    public void TestIdentifier()
    {
        var tokens = lexer.Lex("abc123").ToList();
        Assert.AreEqual(2, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual("abc123", tokens[0].Value);
        Assert.AreEqual(TokenKind.Eof, tokens[1].Kind);
    }

    [TestMethod]
    public void TestNumberLiteral()
    {
        var tokens = lexer.Lex("456").ToList();
        Assert.AreEqual(2, tokens.Count);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[0].Kind);
        Assert.AreEqual("456", tokens[0].Value);
        Assert.AreEqual(TokenKind.Eof, tokens[1].Kind);
    }

    [TestMethod]
    public void TestOperators()
    {
        var tokens = lexer.Lex("+ - * /").ToList();
        Assert.AreEqual(6, tokens.Count);
        Assert.AreEqual(TokenKind.Plus, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Minus, tokens[1].Kind);
        Assert.AreEqual(TokenKind.Star, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Slash, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[5].Kind);
    }

    [TestMethod]
    public void TestAssignment()
    {
        var tokens = lexer.Lex("x := 10").ToList();
        Assert.AreEqual(4, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual("x", tokens[0].Value);
        Assert.AreEqual(TokenKind.Assign, tokens[1].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[2].Kind);
        Assert.AreEqual("10", tokens[2].Value);
        Assert.AreEqual(TokenKind.Eof, tokens[3].Kind);
    }

    [TestMethod]
    public void TestIfStatement()
    {
        var tokens = lexer.Lex("if x > 0 then print x end").ToList();
        Assert.AreEqual(9, tokens.Count);
        Assert.AreEqual(TokenKind.If, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.GreaterThan, tokens[2].Kind); // Assuming we handle '>'
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Then, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Print, tokens[5].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[6].Kind);
        Assert.AreEqual(TokenKind.End, tokens[7].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[8].Kind);
    }

    [TestMethod]
    public void TestWhileStatement()
    {
        var tokens = lexer.Lex("while x < 10 do print x end").ToList();
        Assert.AreEqual(9, tokens.Count);
        Assert.AreEqual(TokenKind.While, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.LessThan, tokens[2].Kind); // Assuming we handle '<'
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Do, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Print, tokens[5].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[6].Kind);
        Assert.AreEqual(TokenKind.End, tokens[7].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[8].Kind);
    }

    [TestMethod]
    public void TestPrintStatement()
    {
        var tokens = lexer.Lex("print x").ToList();
        Assert.AreEqual(3, tokens.Count);
        Assert.AreEqual(TokenKind.Print, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[2].Kind);
    }

    [TestMethod]
    public void TestParentheses()
    {
        var tokens = lexer.Lex("(x + y) * z").ToList();
        Assert.AreEqual(8, tokens.Count);
        Assert.AreEqual(TokenKind.LeftParenthesis, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[1].Kind);
        Assert.AreEqual(TokenKind.Plus, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[3].Kind);
        Assert.AreEqual(TokenKind.RightParenthesis, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Star, tokens[5].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[6].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[7].Kind);
    }

    [TestMethod]
    public void TestSemicolon()
    {
        var tokens = lexer.Lex("x := 10; y := 20").ToList();
        Assert.AreEqual(8, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[1].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Semicolon, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[5].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[6].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[7].Kind);
    }

    [TestMethod]
    public void TestMultipleStatements()
    {
        var tokens = lexer.Lex("x := 10; y := 20; print x + y").ToList();
        Assert.AreEqual(14, tokens.Count);
        Assert.AreEqual(TokenKind.Identifier, tokens[0].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[1].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[2].Kind);
        Assert.AreEqual(TokenKind.Semicolon, tokens[3].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[4].Kind);
        Assert.AreEqual(TokenKind.Assign, tokens[5].Kind);
        Assert.AreEqual(TokenKind.NumberLiteral, tokens[6].Kind);
        Assert.AreEqual(TokenKind.Semicolon, tokens[7].Kind);
        Assert.AreEqual(TokenKind.Print, tokens[8].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[9].Kind);
        Assert.AreEqual(TokenKind.Plus, tokens[10].Kind);
        Assert.AreEqual(TokenKind.Identifier, tokens[11].Kind);
        Assert.AreEqual(TokenKind.Eof, tokens[13].Kind);
    }

    [TestMethod]
    public void TestEndOfFile()
    {
        var tokens = lexer.Lex("").ToList();
        Assert.AreEqual(1, tokens.Count);
        Assert.AreEqual(TokenKind.Eof, tokens[0].Kind);
    }
}