using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAiTokenizer.Services
{
    public class AbstractSyntaxTreeParser : Models.IAbstractSyntaxTreeParser
    {
        public CSharpSyntaxNode ParseCode(string sourceCode)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            return syntaxTree.GetRoot();
        }
    }
}