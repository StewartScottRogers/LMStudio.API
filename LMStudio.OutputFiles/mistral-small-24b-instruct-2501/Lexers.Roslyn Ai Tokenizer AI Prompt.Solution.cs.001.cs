using Microsoft.CodeAnalysis.CSharp;

public class AstPrettyPrinter
{
    private readonly SyntaxNode root;

    public AstPrettyPrinter(SyntaxNode root)
    {
        this.root = root;
    }

    public string PrettyPrint()
    {
        return Format(root);
    }

    private static string Format(SyntaxNode node, int indentLevel = 0)
    {
        var indent = new string(' ', indentLevel * 4);
        var result = $"{indent}{node.Kind()}";

        foreach (var child in node.ChildNodes())
        {
            result += $"\n{Format(child, indentLevel + 1)}";
        }

        return result;
    }
}