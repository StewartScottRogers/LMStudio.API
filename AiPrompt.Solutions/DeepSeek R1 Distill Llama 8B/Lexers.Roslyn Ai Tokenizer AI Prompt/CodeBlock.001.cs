using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynASTGenerator
{
    public readonly class AbstractSyntaxTreePrinter
    {
        public string PrettyPrint(SyntaxNode syntaxNode)
        {
            var walker = new SyntaxTreeWalker();
            walker.Visit(syntaxNode);

            return walker.FormattedTree.ToString();
        }
    }

    internal class SyntaxTreeWalker : CSharpSyntaxWalker
    {
        public System.Text.StringBuilder FormattedTree { get; } = new();

        public override void Visit(SyntaxNode node)
        {
            if (node != null)
            {
                var indentation = string.Concat(System.Linq.Enumerable.Repeat("  ", node.SpanStart));
                FormattedTree.AppendLine($"{indentation}{node.GetType().Name}: {node}");
                base.Visit(node);
            }
        }
    }
}