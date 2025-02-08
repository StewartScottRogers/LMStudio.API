[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestIdentifier()
    {
        var lexer = new Lexer("programName");
        Assert.AreEqual(new Token(TokenType.Identifier, "programName"), lexer.GetNextToken());
    }

    // Add other tests.
}