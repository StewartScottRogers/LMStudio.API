using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstLibrary
{
    public class AbstractSyntaxTreeReflowGenerator
    {
        public string GenerateCode(SyntaxNode node)
        {
            var formattedCode = CSharpSyntaxTree.Create(node).GetRoot().ToFullString();
            return formattedCode;
        }
    }
}