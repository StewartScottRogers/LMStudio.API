using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestIdentifier()
    {
        var lexer = new Lexer("variable");
        var token = lexer.GetNextToken();
        Assert.AreEqual(TokenType.Identifier, token.Type);
        Assert.AreEqual("variable", token.Value);
    }

    // Add 24 more test methods
}