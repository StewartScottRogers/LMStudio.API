using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAiTokenizer.Services
{
    public class AbstractSyntaxTreeReflowGenerator : Models.IAbstractSyntaxTreeReflowGenerator
    {
        public string RegenerateCode(CSharpSyntaxNode astNode)
        {
            var syntaxRoot = (CompilationUnitSyntax)astNode;
            var rootWithFormattedTrivia = Formatter.Format(syntaxRoot, new AdhocWorkspace());
            return rootWithFormattedTrivia.ToFullString();
        }
    }
}