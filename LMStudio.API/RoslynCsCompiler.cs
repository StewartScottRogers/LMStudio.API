using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace LMStudio.API
{
    public static class RoslynCsCompiler
    {
        public static SyntaxTree CompileSyntaxTree(this string csCode)
        {
            SyntaxTree syntaxTree
                = CSharpSyntaxTree.ParseText(csCode);

            return syntaxTree;
        }
    }
}
