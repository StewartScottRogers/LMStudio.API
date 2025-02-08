using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAiTokenizer.Models
{
    public interface IAbstractSyntaxTreeParser
    {
        CSharpSyntaxNode ParseCode(string sourceCode);
    }
}