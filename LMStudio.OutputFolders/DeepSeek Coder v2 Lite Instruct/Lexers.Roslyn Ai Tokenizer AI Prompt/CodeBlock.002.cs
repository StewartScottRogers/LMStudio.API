using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CodeGenerator
{
    public string GenerateCode(SyntaxTree tree)
    {
        var root = tree.GetRoot();
        return root.NormalizeWhitespace().ToFullString();
    }
}