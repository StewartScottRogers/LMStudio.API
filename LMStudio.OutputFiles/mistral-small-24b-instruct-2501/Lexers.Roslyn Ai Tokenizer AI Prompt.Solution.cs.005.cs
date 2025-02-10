using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AstPrettyPrinterTests
{
    [TestMethod]
    public void TestPrettyPrint()
    {
        var sourceCode = @"namespace Example { public class HelloWorld { public static void Main() { Console.WriteLine(""Hello, World!""); } } }";
        var lexer = new RoslynLexer(sourceCode);
        var syntaxTree = lexer.GenerateSyntaxTree();
        var root = syntaxTree.GetRoot();

        var prettyPrinter = new AstPrettyPrinter(root);
        var prettyPrintedAst = prettyPrinter.PrettyPrint();

        Console.WriteLine(prettyPrintedAst); // Display the AST
        Assert.IsNotNull(prettyPrintedAst);

        // Add more tests for bounding conditions
    }
}