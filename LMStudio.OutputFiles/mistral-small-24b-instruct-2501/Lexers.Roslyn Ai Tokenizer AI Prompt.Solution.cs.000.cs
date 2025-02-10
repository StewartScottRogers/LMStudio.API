using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

public class RoslynLexer
{
    private readonly string sourceCode;

    public RoslynLexer(string sourceCode)
    {
        this.sourceCode = sourceCode;
    }

    public SyntaxTree GenerateSyntaxTree()
    {
        var tree = CSharpSyntaxTree.ParseText(sourceCode);
        return tree;
    }
}