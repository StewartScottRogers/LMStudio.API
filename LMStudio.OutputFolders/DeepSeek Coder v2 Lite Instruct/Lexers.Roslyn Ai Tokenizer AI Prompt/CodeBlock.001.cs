using Microsoft.CodeAnalysis;

public class SyntaxTreePrinter
{
    public void PrintSyntaxTree(SyntaxTree tree)
    {
        System.Console.WriteLine(tree.ToString());
    }
}