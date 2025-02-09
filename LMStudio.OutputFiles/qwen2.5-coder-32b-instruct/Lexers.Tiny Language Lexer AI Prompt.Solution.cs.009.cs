// LexerTests.cs (additional)
[TestMethod]
public void TestLexSimpleExpression()
{
    var input = "3 + 5 * (2 - 8);";
    var expectedTokens = new[]
    {
        new Token(TokenKind.Number, "3"),
        new Token(TokenKind.Plus, "+"),
        new Token(TokenKind.Number, "5"),
        new Token(TokenKind.Star, "*"),
        new Token(TokenKind.LeftParenthesis, "("),
        new Token(TokenKind.Number, "2"),
        new Token(TokenKind.Minus, "-"),
        new Token(TokenKind.Number, "8"),
        new Token(TokenKind.RightParenthesis, ")"),
        new Token(TokenKind.Semicolon, ";")
    };
    var actualTokens = Lex(input);
    CollectionAssert.AreEqual(expectedTokens, actualTokens);
}

[TestMethod]
public void TestLexNestedIfStatements()
{
    var input = "if x > 0 then if y < 10 then z := 5; end; end";
    var expectedTokens = new[]
    {
        new Token(TokenKind.IfKeyword, "if"),
        new Token(TokenKind.Identifier, "x"),
        new Token(TokenKind.GreaterThan, ">"),
        new Token(TokenKind.Number, "0"),
        new Token(TokenKind.ThenKeyword, "then"),
        new Token(TokenKind.IfKeyword, "if"),
        new Token(TokenKind.Identifier, "y"),
        new Token(TokenKind.LessThan, "<"),
        new Token(TokenKind.Number, "10"),
        new Token(TokenKind.ThenKeyword, "then"),
        new Token(TokenKind.Identifier, "z"),
        new Token(TokenKind.ColonEquals, ":="),
        new Token(TokenKind.Number, "5"),
        new Token(TokenKind.Semicolon, ";"),
        new Token(TokenKind.EndKeyword, "end"),
        new Token(TokenKind.Semicolon, ";"),
        new Token(TokenKind.EndKeyword, "end")
    };
    var actualTokens = Lex(input);
    CollectionAssert.AreEqual(expectedTokens, actualTokens);
}

[TestMethod]
public void TestLexComplexWhileLoop()
{
    var input = "while x < 10 do y := y + (x * 2); z := z - 1; end";
    var expectedTokens = new[]
    {
        new Token(TokenKind.WhileKeyword, "while"),
        new Token(TokenKind.Identifier, "x"),
        new Token(TokenKind.LessThan, "<"),
        new Token(TokenKind.Number, "10"),
        new Token(TokenKind.DoKeyword, "do"),
        new Token(TokenKind.Identifier, "y"),
        new Token(TokenKind.ColonEquals, ":="),
        new Token(TokenKind.Identifier, "y"),
        new Token(TokenKind.Plus, "+"),
        new Token(TokenKind.LeftParenthesis, "("),
        new Token(TokenKind.Identifier, "x"),
        new Token(TokenKind.Star, "*"),
        new Token(TokenKind.Number, "2"),
        new Token(TokenKind.RightParenthesis, ")"),
        new Token(TokenKind.Semicolon, ";"),
        new Token(TokenKind.Identifier, "z"),
        new Token(TokenKind.ColonEquals, ":="),
        new Token(TokenKind.Identifier, "z"),
        new Token(TokenKind.Minus, "-"),
        new Token(TokenKind.Number, "1"),
        new Token(TokenKind.Semicolon, ";"),
        new Token(TokenKind.EndKeyword, "end")
    };
    var actualTokens = Lex(input);
    CollectionAssert.AreEqual(expectedTokens, actualTokens);
}