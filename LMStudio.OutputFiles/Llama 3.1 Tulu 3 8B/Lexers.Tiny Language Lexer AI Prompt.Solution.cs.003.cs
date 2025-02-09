using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestLexingIdentifiers()
    {
        var lexer = new Lexer("a b c");
        IEnumerable<Token> tokens = lexer.Lex();
        
        Assert.AreEqual(3, tokens.Count());
        CollectionAssert.Contains(tokens, new Token(TokenType.Identifier, "a"));
        CollectionAssert.Contains(tokens, new Token(TokenType.Identifier, "b"));
        CollectionAssert.Contains(tokens, new Token(TokenType.Identifier, "c"));
    }

    [TestMethod]
    public void TestLexingNumbers()
    {
        var lexer = new Lexer("123 456");
        IEnumerable<Token> tokens = lexer.Lex();

        Assert.AreEqual(2, tokens.Count());
        CollectionAssert.Contains(tokens, new Token(TokenType.Number, "123"));
        CollectionAssert.Contains(tokens, new Token(TokenType.Number, "456"));
    }

    // Write other unit tests as required for the lexer and AST generation.

    [TestMethod]
    public void TestAstPrinting()
    {
        // Set up an example AST and verify its pretty-printing
    }

    // ... Add more test methods here.
}