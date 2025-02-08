using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestSimpleAssignment()
    {
        var lexer = new Lexer("x = 5");
        AssertToken(lexer.GetNextToken(), TokenType.Name, "x");
        AssertToken(lexer.GetNextToken(), TokenType.Punctuation, "=");
        AssertToken(lexer.GetNextToken(), TokenType.Number, "5");
        AssertEndMarker(lexer);
    }

    [TestMethod]
    public void TestTypedAssignment()
    {
        var lexer = new Lexer("y: int = 10");
        AssertToken(lexer.GetNextToken(), TokenType.Name, "y");
        AssertToken(lexer.GetNextToken(), TokenType.Punctuation, ":");
        AssertToken(lexer.GetNextToken(), TokenType.Name, "int");
        AssertToken(lexer.GetNextToken(), TokenType.Punctuation, "=");
        AssertToken(lexer.GetNextToken(), TokenType.Number, "10");
        AssertEndMarker(lexer);
    }

    [TestMethod]
    public void TestReturnStatement()
    {
        var lexer = new Lexer("return 42");
        AssertToken(lexer.GetNextToken(), TokenType.Keyword, "return");
        AssertToken(lexer.GetNextToken(), TokenType.Number, "42");
        AssertEndMarker(lexer);
    }

    [TestMethod]
    public void TestRaiseStatement()
    {
        var lexer = new Lexer("raise ValueError from x");
        AssertToken(lexer.GetNextToken(), TokenType.Keyword, "raise");
        AssertToken(lexer.GetNextToken(), TokenType.Name, "ValueError");
        AssertToken(lexer.GetNextToken(), TokenType.Keyword, "from");
        AssertToken(lexer.GetNextToken(), TokenType.Name, "x");
        AssertEndMarker(lexer);
    }

    [TestMethod]
    public void TestSimpleStatements()
    {
        var lexer = new Lexer("a=1; b=2");
        AssertToken(lexer.GetNextToken(), TokenType.Name, "a");
        AssertToken(lexer.GetNextToken(), TokenType.Punctuation, "=");
        AssertToken(lexer.GetNextToken(), TokenType.Number, "1");
        AssertToken(lexer.GetNextToken(), TokenType.Punctuation, ";");

        AssertToken(lexer.GetNextToken(), TokenType.Name, "b");
        AssertToken(lexer.GetNextToken(), TokenType.Punctuation, "=");
        AssertToken(lexer.GetNextToken(), TokenType.Number, "2");
        AssertEndMarker(lexer);
    }

    [TestMethod]
    public void TestStringLiterals()
    {
        var lexer = new Lexer("\"hello\" 'world'");
        AssertToken(lexer.GetNextToken(), TokenType.String, "hello");
        AssertToken(lexer.GetNextToken(), TokenType.String, "world");
        AssertEndMarker(lexer);
    }

    private void AssertToken(Token token, TokenType type, string value)
    {
        Assert.AreEqual(type, token.Type);
        Assert.AreEqual(value, token.Value);
    }

    private void AssertEndMarker(Lexer lexer)
    {
        var endMarker = lexer.GetNextToken();
        Assert.AreEqual(TokenType.EndMarker, endMarker.Type);
    }
}