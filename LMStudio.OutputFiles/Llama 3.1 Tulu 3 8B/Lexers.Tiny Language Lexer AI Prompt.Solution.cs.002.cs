[TestClass]
public class LexerTest
{
    [TestMethod]
    public void TestLexProgram()
    {
        var lexer = new SimpleLexer();
        var tokens = lexer.LexProgram("x := 5; if x > 3 then print x");

        // Asserts here for the expected token sequence.
    }
}