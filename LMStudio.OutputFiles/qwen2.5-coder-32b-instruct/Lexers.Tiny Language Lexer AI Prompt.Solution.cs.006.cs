using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestSimpleTokens()
    {
        var lexer = new Lexer("123 + 456 - 789");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(5, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Plus, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Minus, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[4].Type);
    }

    [TestMethod]
    public void TestIdentifier()
    {
        var lexer = new Lexer("abc123");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(1, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
    }

    [TestMethod]
    public void TestKeywords()
    {
        var lexer = new Lexer("if then else end while do print");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(7, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.If, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Then, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[2].Type); // 'else' is not a keyword in our grammar
        Assert.AreEqual(TokenTypes.End, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.While, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Do, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[6].Type);
    }

    [TestMethod]
    public void TestAssignStatement()
    {
        var lexer = new Lexer("x := 10;");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(4, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Equal, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[3].Type);
    }

    [TestMethod]
    public void TestIfStatement()
    {
        var lexer = new Lexer("if x then print 5; end");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(7, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.If, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Then, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[6].Type);
    }

    [TestMethod]
    public void TestWhileStatement()
    {
        var lexer = new Lexer("while x do print 10; end");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(7, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.While, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Do, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[6].Type);
    }

    [TestMethod]
    public void TestPrintStatement()
    {
        var lexer = new Lexer("print 10;");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(3, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[2].Type);
    }

    [TestMethod]
    public void TestExpr()
    {
        var lexer = new Lexer("x + y - 5");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(5, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Plus, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Minus, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[4].Type);
    }

    [TestMethod]
    public void TestTerm()
    {
        var lexer = new Lexer("a * b / 3");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(5, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Asterisk, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Slash, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[4].Type);
    }

    [TestMethod]
    public void TestFactor()
    {
        var lexer = new Lexer("10");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(1, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[0].Type);

        lexer = new Lexer("(x + y)");
        tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(5, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.LeftParenthesis, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Plus, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.RightParenthesis, tokensTuple[4].Type);
    }

    [TestMethod]
    public void TestComplexStatementList()
    {
        var lexer = new Lexer("x := 10; print x + y;");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(7, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Equal, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Plus, tokensTuple[6].Type);
    }

    [TestMethod]
    public void TestIfWithMultipleStmts()
    {
        var lexer = new Lexer("if x then print y; print z; end");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(8, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.If, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Then, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[6].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[7].Type);
    }

    [TestMethod]
    public void TestWhileWithMultipleStmts()
    {
        var lexer = new Lexer("while x do print y; print z; end");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(8, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.While, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Do, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[4].Type);
        Assert.AreEqual(TokenTokens.Semicolon, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[6].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[7].Type);
    }

    [TestMethod]
    public void TestNestedIf()
    {
        var lexer = new Lexer("if x then if y then print z; end end");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(10, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.If, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Then, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.If, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Then, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[6].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[7].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[8].Type);
    }

    [TestMethod]
    public void TestNestedWhile()
    {
        var lexer = new Lexer("while x do while y do print z; end end");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(10, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.While, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Do, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.While, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Do, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[6].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[7].Type);
        Assert.AreEqual(TokenTypes.End, tokensTuple[8].Type);
    }

    [TestMethod]
    public void TestComplexExpr()
    {
        var lexer = new Lexer("x + y * z - 10 / (5 + 3)");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(13, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Plus, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Asterisk, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[4].Type);
        Assert.AreEqual(TokenTypes.Minus, tokensTuple[5].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[6].Type);
        Assert.AreEqual(TokenTypes.Slash, tokensTuple[7].Type);
        Assert.AreEqual(TokenTypes.LeftParenthesis, tokensTuple[8].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[9].Type);
        Assert.AreEqual(TokenTypes.Plus, tokensTuple[10].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[11].Type);
        Assert.AreEqual(TokenTypes.RightParenthesis, tokensTuple[12].Type);
    }

    [TestMethod]
    public void TestComments()
    {
        var lexer = new Lexer("x := 10; // This is a comment\nprint x;");
        var tokensTuple = lexer.Lex().ToArray();
        Assert.AreEqual(5, tokensTuple.Length);
        Assert.AreEqual(TokenTypes.Identifier, tokensTuple[0].Type);
        Assert.AreEqual(TokenTypes.Equal, tokensTuple[1].Type);
        Assert.AreEqual(TokenTypes.Number, tokensTuple[2].Type);
        Assert.AreEqual(TokenTypes.Semicolon, tokensTuple[3].Type);
        Assert.AreEqual(TokenTypes.Print, tokensTuple[4].Type);
    }
}