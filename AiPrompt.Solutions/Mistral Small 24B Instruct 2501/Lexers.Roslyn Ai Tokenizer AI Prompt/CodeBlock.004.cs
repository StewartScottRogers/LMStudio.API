using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    public class AstReflowGenerator
    {
        public string Reflow(SyntaxNode node)
        {
            // Simple example of reflowing, expand as needed
            return node.ToFullString();
        }
    }
}