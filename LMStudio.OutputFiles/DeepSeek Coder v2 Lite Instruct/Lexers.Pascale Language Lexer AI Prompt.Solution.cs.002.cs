[TestClass]
public class LexerTests {
    [TestMethod]
    public void TestBasicIdentifier() {
        var lexer = new Lexer("abc def;");
        Assert.AreEqual(TokenType.Identifier, lexer.GetNextToken().Type);
        Assert.AreEqual("abc", lexer.GetNextToken().Lexeme);
        // Continue with other tests...
    }
}