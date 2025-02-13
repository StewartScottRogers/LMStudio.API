using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Compiler.CSharp
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
