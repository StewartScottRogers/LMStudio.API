using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace AstGenerator
{
    class SyntaxTreeReflowGenerator : CSharpSyntaxRewriter
    {
        public string Reflow(SyntaxNode node)
        {
            StringBuilder builder = new StringBuilder();
            this.Visit(node, builder);
            return builder.ToString();
        }

        private void Visit(SyntaxNode node, StringBuilder builder)
        {
            if (node == null) return;

            builder.AppendLine($"{new string(' ', this.Depth * 2)}{node.ToFullString()}");
            base.Visit(node, builder);
        }
    }
}