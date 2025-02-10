using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RoslynLexerTests
{
    [TestMethod]
    public void TestGenerateSyntaxTree()
    {
        var sourceCode = @"namespace Example { public class HelloWorld { public static void Main() { Console.WriteLine(""Hello, World!""); } } }";
        var lexer = new RoslynLexer(sourceCode);
        var syntaxTree = lexer.GenerateSyntaxTree();
        Assert.IsNotNull(syntaxTree);

        // Add more tests for bounding conditions
    }
}