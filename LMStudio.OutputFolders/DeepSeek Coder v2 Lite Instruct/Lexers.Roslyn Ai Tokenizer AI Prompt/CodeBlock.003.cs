using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis;

[TestClass]
public class LexerServiceTests
{
    [TestMethod]
    public void TestGenerateSyntaxTree()
    {
        var lexer = new LexerService();
        string code = "class Sample { }";
        SyntaxTree tree = lexer.GenerateSyntaxTree(code);
        Assert.IsNotNull(tree);
    }

    [TestMethod]
    public void TestPrintSyntaxTree()
    {
        var lexer = new LexerService();
        string code = "class Sample { }";
        SyntaxTree tree = lexer.GenerateSyntaxTree(code);
        var printer = new SyntaxTreePrinter();
        printer.PrintSyntaxTree(tree);
    }
}