using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace AstGenerator
{
    class LexicalAnalyzer
    {
        private readonly List<SyntaxToken> tokens = new();

        public IEnumerable<SyntaxToken> Analyze(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = (CompilationUnitSyntax)syntaxTree.GetRoot();
            this.Visit(root);

            return this.tokens;
        }

        private void Visit(SyntaxNode node)
        {
            if (node == null) return;

            foreach (var token in node.ChildTokens())
            {
                this.tokens.Add(token);
            }

            foreach (var child in node.ChildNodes())
            {
                this.Visit(child);
            }
        }
    }
}