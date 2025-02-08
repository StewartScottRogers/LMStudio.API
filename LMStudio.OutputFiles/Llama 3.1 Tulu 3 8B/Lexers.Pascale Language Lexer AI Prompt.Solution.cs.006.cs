[TestFixture]
public class LexingUnitTest
{
    [Test]
    public void TestIdentifier()
    {
        var lexer = new PascaleLexer("program myProgram;");
        Assert.AreEqual(new Token(TokenType.Identifier, "myProgram"), lexer.Lex().First());
    }

    // Add more tests for numbers, strings, operators etc.
}