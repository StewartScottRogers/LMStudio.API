using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestNextToken()
    {
        var source = @"let five = 5;
let ten = 10;

let add = fn(x, y) {
    x + y;
};

let result = add(five, ten);";

        var lexer = new Lexer(source);
        var expectedTokens = new List<Token>
        {
            new(TokenType.Let, "let"),
            new(TokenType.Identifier, "five"),
            new(TokenType.Assign, "="),
            new(TokenType.Number, "5"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.Let, "let"),
            new(TokenType.Identifier, "ten"),
            new(TokenType.Assign, "="),
            new(TokenType.Number, "10"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.Let, "let"),
            new(TokenType.Identifier, "add"),
            new(TokenType.Assign, "="),
            new(TokenType.Function, "fn"),
            new(TokenType.LeftParenthesis, "("),
            new(TokenType.Identifier, "x"),
            new(TokenType.Comma, ","),
            new(TokenType.Identifier, "y"),
            new(TokenType.RightParenthesis, ")"),
            new(TokenType.LeftBrace, "{"),
            new(TokenType.Identifier, "x"),
            new(TokenType.Plus, "+"),
            new(TokenType.Identifier, "y"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.RightBrace, "}"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.Let, "let"),
            new(TokenType.Identifier, "result"),
            new(TokenType.Assign, "="),
            new(TokenType.Identifier, "add"),
            new(TokenType.LeftParenthesis, "("),
            new(TokenType.Identifier, "five"),
            new(TokenType.Comma, ","),
            new(TokenType.Identifier, "ten"),
            new(TokenType.RightParenthesis, ")"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.EOF, null),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_Assignment()
    {
        var source = @"x := 5;";
        var lexer = new Lexer(source);

        var tokens = new List<Token>
        {
            lexer.NextToken(),
            lexer.NextToken(),
            lexer.NextToken(),
            lexer.NextToken(),
        };

        Assert.AreEqual(TokenType.Identifier, tokens[0].Type);
        Assert.AreEqual("x", tokens[0].Value);

        Assert.AreEqual(TokenType.Assign, tokens[1].Type);
        Assert.AreEqual(":=", tokens[1].Value);

        Assert.AreEqual(TokenType.Number, tokens[2].Type);
        Assert.AreEqual("5", tokens[2].Value);

        Assert.AreEqual(TokenType.Semicolon, tokens[3].Type);
        Assert.AreEqual(";", tokens[3].Value);
    }

    [TestMethod]
    public void TestNextToken_IfStatement()
    {
        var source = @"if x > 10 then { print(x); }";
        var lexer = new Lexer(source);

        var expectedTokens = new List<Token>
        {
            new(TokenType.If, "if"),
            new(TokenType.Identifier, "x"),
            new(TokenType.GreaterThan, ">"),
            new(TokenType.Number, "10"),
            new(TokenType.Then, "then"),
            new(TokenType.LeftBrace, "{"),
            new(TokenType.Print, "print"),
            new(TokenType.LeftParenthesis, "("),
            new(TokenType.Identifier, "x"),
            new(TokenType.RightParenthesis, ")"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.RightBrace, "}"),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_WhileStatement()
    {
        var source = @"while x < 10 do { x := x + 1; }";
        var lexer = new Lexer(source);

        var expectedTokens = new List<Token>
        {
            new(TokenType.While, "while"),
            new(TokenType.Identifier, "x"),
            new(TokenType.LessThan, "<"),
            new(TokenType.Number, "10"),
            new(TokenType.Do, "do"),
            new(TokenType.LeftBrace, "{"),
            new(TokenType.Identifier, "x"),
            new(TokenType.Assign, ":="),
            new(TokenType.Identifier, "x"),
            new(TokenType.Plus, "+"),
            new(TokenType.Number, "1"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.RightBrace, "}"),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_PrintStatement()
    {
        var source = @"print(x);";
        var lexer = new Lexer(source);

        var expectedTokens = new List<Token>
        {
            new(TokenType.Print, "print"),
            new(TokenType.LeftParenthesis, "("),
            new(TokenType.Identifier, "x"),
            new(TokenType.RightParenthesis, ")"),
            new(TokenType.Semicolon, ";"),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_SimpleExpression()
    {
        var source = @"x + y - z;";
        var lexer = new Lexer(source);

        var expectedTokens = new List<Token>
        {
            new(TokenType.Identifier, "x"),
            new(TokenType.Plus, "+"),
            new(TokenType.Identifier, "y"),
            new(TokenType.Minus, "-"),
            new(TokenType.Identifier, "z"),
            new(TokenType.Semicolon, ";"),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_MultiplicativeExpression()
    {
        var source = @"a * b / c;";
        var lexer = new Lexer(source);

        var expectedTokens = new List<Token>
        {
            new(TokenType.Identifier, "a"),
            new(TokenType.Multiply, "*"),
            new(TokenType.Identifier, "b"),
            new(TokenType.Divide, "/"),
            new(TokenType.Identifier, "c"),
            new(TokenType.Semicolon, ";"),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_Parentheses()
    {
        var source = @"(x + y) * (z / w);";
        var lexer = new Lexer(source);

        var expectedTokens = new List<Token>
        {
            new(TokenType.LeftParenthesis, "("),
            new(TokenType.Identifier, "x"),
            new(TokenType.Plus, "+"),
            new(TokenType.Identifier, "y"),
            new(TokenType.RightParenthesis, ")"),
            new(TokenType.Multiply, "*"),
            new(TokenType.LeftParenthesis, "("),
            new(TokenType.Identifier, "z"),
            new(TokenType.Divide, "/"),
            new(TokenType.Identifier, "w"),
            new(TokenType.RightParenthesis, ")"),
            new(TokenType.Semicolon, ";"),
        };

        foreach (var token in expectedTokens)
        {
            var nextToken = lexer.NextToken();
            Assert.AreEqual(token.Type, nextToken.Type);
            Assert.AreEqual(token.Value, nextToken.Value);
        }
    }

    [TestMethod]
    public void TestNextToken_EndOfStream()
    {
        var source = @"";
        var lexer = new Lexer(source);

        var token = lexer.NextToken();

        Assert.AreEqual(TokenType.EOF, token.Type);
        Assert.IsNull(token.Value);
    }

    [TestMethod]
    public void TestNextToken_UnrecognizedCharacter()
    {
        var source = @"@";
        var lexer = new Lexer(source);

        Assert.ThrowsException<Exception>(() => lexer.NextToken());
    }
}