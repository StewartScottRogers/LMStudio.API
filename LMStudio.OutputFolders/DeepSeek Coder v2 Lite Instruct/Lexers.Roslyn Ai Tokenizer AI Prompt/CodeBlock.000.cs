using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

public class LexerService
{
    public SyntaxTree GenerateSyntaxTree(string code)
    {
        return CSharpSyntaxTree.ParseText(code);
    }
}