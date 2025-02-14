using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

public class AstPrettyPrinter : IAstPrinter
{
    public void Print(AbstractSyntaxTree ast)
    {
        // Implement the pretty printing logic here
        Console.WriteLine($"Root Node: {ast.RootNode}");
        // Add more detailed AST printing as needed.
    }
}