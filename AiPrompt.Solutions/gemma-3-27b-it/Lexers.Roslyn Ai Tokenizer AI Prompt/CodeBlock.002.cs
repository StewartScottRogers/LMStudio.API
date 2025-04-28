using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace AstLexer
{
    public class AbstractSyntaxTreeLexer
    {
        public List<(string Type, string Value)> Lex(SyntaxNode node)
        {
            var tokens = new List<(string Type, string Value)>();
            LexSyntaxNode(node, tokens);
            return tokens;
        }

        private void LexSyntaxNode(SyntaxNode node, List<(string Type, string Value)> tokens)
        {
            if (node is IdentifierNameSyntax identifierName)
            {
                tokens.Add(("Identifier", identifierName.Identifier.Text));
            }
            else if (node is LiteralExpressionSyntax literalExpression)
            {
                tokens.Add(("Literal", literalExpression.ToString()));
            }
            // Add more token types as needed based on the AST structure you want to lex

            if (node.HasChildNodes())
            {
                foreach (var child in node.GetChildNodesAndTokens())
                {
                    if (child is SyntaxNode syntaxNode)
                    {
                        LexSyntaxNode(syntaxNode, tokens);
                    }
                }
            }
        }
    }
}