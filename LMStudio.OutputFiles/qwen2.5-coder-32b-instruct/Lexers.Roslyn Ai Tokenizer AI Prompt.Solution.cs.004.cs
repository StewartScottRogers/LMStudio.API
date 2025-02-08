using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAiTokenizer.Models
{
    public interface IAbstractSyntaxTreeReflowGenerator
    {
        string RegenerateCode(CSharpSyntaxNode astNode);
    }
}