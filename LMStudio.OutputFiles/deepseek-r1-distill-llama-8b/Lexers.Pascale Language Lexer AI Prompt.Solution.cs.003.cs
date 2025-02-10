using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class LexerTests : TestCase
{
    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
    }

    [TestMethod]
    public void TestIdentifierToken()
    {
        var tokenizer = new Tokenizer("identifier");
        Assert.AreEqual(typeof(Token<Identifier>), tokenizer.Tokens.First().Type);
    }
}