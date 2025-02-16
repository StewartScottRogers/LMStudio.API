using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace AstGenerator
{
    class SyntaxTreePrettyPrinter : CSharpSyntaxWalker
    {
        public void Print(SyntaxNode node)
        {
            this.Visit(node);
        }

        public override void Visit(SyntaxNode node)
        {
            if (node == null) return;

            Console.WriteLine($"{new string(' ', this.Depth * 2)}{node.Kind()}");
            base.Visit(node);
        }
    }
}