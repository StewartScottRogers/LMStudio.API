// UnitTest1.cs (Example)

using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerProject; // Adjust namespace as needed.

[TestClass]
public class TokenizerTests
{
    [TestMethod]
    public void SimpleWhitespaceTokenization()
    {
        var tokenizer = new Tokenizer();
        string sourceCode = "   This is a test   ";
        var tokens = tokenizer.Tokenize(sourceCode);

        Assert.AreEqual(5, tokens.Count, "Incorrect number of whitespace tokens");
    }

    // Add more tests...
}