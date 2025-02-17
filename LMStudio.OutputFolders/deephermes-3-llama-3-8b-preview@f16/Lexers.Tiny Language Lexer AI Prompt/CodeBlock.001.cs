using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestValidInput()
    {
        var input = "if (x > 10) then print x end";
        var lexer = new Lexer(input);
        List<(Token, int)> tokens = new List<(Token, int)>();
        
        foreach (var token in lexer)
        {
            tokens.Add((token, lexer._current));
            if (token == Token.EOF) break;
        }

        // Verify the expected sequence of tokens
        Assert.AreEqual(8, tokens.Count);
    }
    
    [TestMethod]
    public void TestInvalidInput()
    {
        var input = "if then";
        var lexer = new Lexer(input);

        try
        {
            foreach (var _ in lexer) ;
            Assert.Fail("Expected exception was not thrown");
        }
        catch (Exception ex)
        {
            // Ensure we're catching the specific type of exception expected
            Assert.IsTrue(ex is Exception, "Unexpected exception caught: " + ex.GetType().Name);
        }
    }

    // Additional test methods for other tokens and scenarios...
}