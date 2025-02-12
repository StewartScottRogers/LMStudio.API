using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Example test case for lexing and parsing a simple program
        var lexer = new Lexer("x := 5 + 3 * (7 - 2);");
        var token = lexer.GetNextToken();
        while (token.Type != TokenTypes.EOF)
        {
            Console.WriteLine(token);
            token = lexer.GetNextToken();
        }
    }
}