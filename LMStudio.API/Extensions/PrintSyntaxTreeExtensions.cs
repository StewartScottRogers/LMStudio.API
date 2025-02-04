using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text;


namespace LMStudio.API.Extensions
{
    public static class PrintSyntaxTreeExtensions
    {
        public static string PrintSyntaxTree(this SyntaxNode node, string indent = "", StringBuilder stringBuilder = null)
        {
            if (stringBuilder is null)
                stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($"{indent}{node.Kind()} - {node}");

            foreach (SyntaxNodeOrToken syntaxNodeOrToken in node.ChildNodesAndTokens())
                if (syntaxNodeOrToken.IsNode)
                {
                    SyntaxNode? syntaxNode =
                        syntaxNodeOrToken
                                .AsNode();

                    if (syntaxNode is not null)
                        stringBuilder
                            .AppendLine(
                                syntaxNode
                                    .PrintSyntaxTree(
                                        indent + "  ",
                                        stringBuilder
                                        )
                            );
                }
                else
                    stringBuilder.AppendLine($"{indent}  {syntaxNodeOrToken.Kind()} - {syntaxNodeOrToken}");

            return stringBuilder.ToString();
        }
    }
}
