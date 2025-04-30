using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestAssignmentStatement()
    {
        var source = "x := 10;";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(4, tokens.Count);

        Assert.AreEqual(TokenType.Identifier, tokens[0].Type);
        Assert.AreEqual("x", tokens[0].Literal);

        Assert.AreEqual(TokenType.ColonEquals, tokens[1].Type);
        
        Assert.AreEqual(TokenType.Number, tokens[2].Type);
        Assert.AreEqual("10", tokens[2].Literal);

        Assert.AreEqual(TokenType.Semicolon, tokens[3].Type);
    }

    [TestMethod]
    public void TestIfStatement()
    {
        var source = "if x > 5 then print x; end";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(8, tokens.Count);

        Assert.AreEqual(TokenType.If, tokens[0].Type);
        
        Assert.AreEqual(TokenType.Identifier, tokens[1].Type);
        Assert.AreEqual("x", tokens[1].Literal);
        
        // Additional tokens testing...
    }

    [TestMethod]
    public void TestWhileStatement()
    {
        var source = "while x < 10 do print x; end";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(9, tokens.Count);

        Assert.AreEqual(TokenType.While, tokens[0].Type);
        
        Assert.AreEqual(TokenType.Identifier, tokens[1].Type);
        Assert.AreEqual("x", tokens[1].Literal);
        
        // Additional tokens testing...
    }

    [TestMethod]
    public void TestPrintStatement()
    {
        var source = "print x;";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        Assert.AreEqual(3, tokens.Count);

        Assert.AreEqual(TokenType.Print, tokens[0].Type);
        
        Assert.AreEqual(TokenType.Identifier, tokens[1].Type);
        Assert.AreEqual("x", tokens[1].Literal);

        Assert.AreEqual(TokenType.Semicolon, tokens[2].Type);
    }

    [TestMethod]
    public void TestExpression()
    {
        var source = "x + 5 * (y - 3)";
        var lexer = new Lexer(source);
        var tokens = lexer.ScanTokens();

        // Complex expression testing...
    }
    
    // Additional tests for other grammar rules.
}