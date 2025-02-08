using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAiTokenizer.Models
{
    public interface IAbstractSyntaxTreePrettyPrinter
    {
        string PrettyPrint(CSharpSyntaxNode astNode);
    }
}