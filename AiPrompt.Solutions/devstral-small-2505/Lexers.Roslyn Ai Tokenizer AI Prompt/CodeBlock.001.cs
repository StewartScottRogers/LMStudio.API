using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyAstApp
{
    public class AbstractSyntaxTreePrettyPrinter
    {
        public string Print(SyntaxNode node)
        {
            return node.ToString();
        }
    }
}