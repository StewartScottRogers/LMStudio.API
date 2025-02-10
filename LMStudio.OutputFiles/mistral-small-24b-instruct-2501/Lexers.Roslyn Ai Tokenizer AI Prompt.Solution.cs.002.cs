using Microsoft.CodeAnalysis.CSharp;

public class AstReflowGenerator
{
    private readonly SyntaxNode root;

    public AstReflowGenerator(SyntaxNode root)
    {
        this.root = root;
    }

    public string GenerateCode()
    {
        return root.ToFullString();
    }
}