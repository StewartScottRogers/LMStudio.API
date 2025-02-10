using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public record StatementNode(List<StatementNewlineTuple> Statements) : AbstractSyntaxNode
    {
        public readonly List<StatementNewlineTuple> StatementList = new();
    }
}