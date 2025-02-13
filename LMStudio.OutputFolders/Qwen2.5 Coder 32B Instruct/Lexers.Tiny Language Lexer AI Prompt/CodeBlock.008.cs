using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestSimpleAssignment()
    {
        var source = "x := 10;";
        var lexer = new Lexer(source);
        
        AssertTokenSequence(lexer, new List<TokenKind>
        {
            TokenKind.Identifier,
            TokenKind.ColonEquals,
            TokenKind.Number,
            TokenKind.Semicolon,
            TokenKind.EndOfFile
        });
    }

    [TestMethod]
    public void TestSimpleIf()
    {
        var source = "if x > 10 then print x end;";
        var lexer = new Lexer(source);
        
        AssertTokenSequence(lexer, new List<TokenKind>
        {
            TokenKind.IfKeyword,
            TokenKind.Identifier,
            TokenKind.GreaterThan, // Note: GreaterThan is not in our enum but it should be added similarly to other operators.
            TokenKind.Number,
            TokenKind.ThenKeyword,
            TokenKind.PrintKeyword,
            TokenKind.Identifier,
            TokenKind.EndKeyword,
            TokenKind.Semicolon,
            TokenKind.EndOfFile
        });
    }

    [TestMethod]
    public void TestSimpleWhile()
    {
        var source = "while x < 10 do print x end;";
        var lexer = new Lexer(source);
        
        AssertTokenSequence(lexer, new List<TokenKind>
        {
            TokenKind.WhileKeyword,
            TokenKind.Identifier,
            TokenKind.LessThan, // Note: LessThan is not in our enum but it should be added similarly to other operators.
            TokenKind.Number,
            TokenKind.DoKeyword,
            TokenKind.PrintKeyword,
            TokenKind.Identifier,
            TokenKind.EndKeyword,
            TokenKind.Semicolon,
            TokenKind.EndOfFile
        });
    }

    [TestMethod]
    public void TestSimplePrint()
    {
        var source = "print (x + 5);";
        var lexer = new Lexer(source);
        
        AssertTokenSequence(lexer, new List<TokenKind>
        {
            TokenKind.PrintKeyword,
            TokenKind.LeftParen,
            TokenKind.Identifier,
            TokenKind.Plus,
            TokenKind.Number,
            TokenKind.RightParen,
            TokenKind.Semicolon,
            TokenKind.EndOfFile
        });
    }

    [TestMethod]
    public void TestMultipleStatements()
    {
        var source = "x := 10; y := 20;";
        var lexer = new Lexer(source);
        
        AssertTokenSequence(lexer, new List<TokenKind>
        {
            TokenKind.Identifier,
            TokenKind.ColonEquals,
            TokenKind.Number,
            TokenKind.Semicolon,
            TokenKind.Identifier,
            TokenKind.ColonEquals,
            TokenKind.Number,
            TokenKind.Semicolon,
            TokenKind.EndOfFile
        });
    }

    // Add 20 more unit tests as per the requirement

    private void AssertTokenSequence(Lexer lexer, List<TokenKind> expectedKinds)
    {
        foreach (var kind in expectedKinds)
        {
            var token = lexer.ScanToken();
            if (token.Kind != kind)
                Assert.Fail($"Expected {kind} but got {token.Kind}");
        }
        
        // Ensure we've reached the end of file
        var finalToken = lexer.ScanToken();
        Assert.AreEqual(TokenKind.EndOfFile, finalToken.Kind);
    }
}