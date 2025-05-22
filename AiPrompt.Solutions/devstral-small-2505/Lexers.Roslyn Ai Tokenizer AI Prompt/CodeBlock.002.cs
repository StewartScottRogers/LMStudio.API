using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyAstApp
{
    public class AstReflowGenerator
    {
        public string Generate(CompilationUnitSyntax rootNode)
        {
            return rootNode.ToFullString();
        }
    }
}