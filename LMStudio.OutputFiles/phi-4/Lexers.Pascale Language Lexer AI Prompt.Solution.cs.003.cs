[TestClass]
public class LexerTests
{
    [TestMethod]
    public void TestTokenizeSimpleProgram()
    {
        var lexer = new Lexer("program Example; begin end.");
        var tokens = lexer.Tokenize().ToList();
        
        Assert.AreEqual(5, tokens.Count);
        // More assertions for each token
    }
}