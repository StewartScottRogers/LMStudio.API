using System;
using Microsoft.Extensions.DependencyInjection;

namespace LexerSolution.LexerLibrary
{
    public abstract class AbstractSyntaxTreeNode
    {
        private readonly object Token;

        protected AbstractSyntaxTreeNode(object token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public override string ToString()
        {
            return Token.ToString();
        }
    }
}