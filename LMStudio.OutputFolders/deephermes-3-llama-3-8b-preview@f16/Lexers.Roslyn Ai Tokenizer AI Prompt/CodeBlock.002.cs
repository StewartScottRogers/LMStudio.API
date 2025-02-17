using Microsoft.CodeAnalysis.CSharp;
using Xunit;

public class LexingTests
{
    [Fact]
    public void TestSimpleExpressionLexing()
    {
        var sourceCode = "var x = 5;"; // Simple C# code snippet
        
        var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
        
        // Use PrettyPrinter to display the AST
        var printer = new Services.PrettyPrinter();
        string astOutput = printer.PrintAst(syntaxTree);
        
        Assert.Contains("VariableDeclarator", astOutput);
    }
}