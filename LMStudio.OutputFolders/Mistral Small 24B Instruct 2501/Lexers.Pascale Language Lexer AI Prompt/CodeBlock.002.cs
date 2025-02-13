// File: AstNode.cs
using System.Collections.Generic;

namespace PascaleLexer
{
    public abstract class AstNode
    {
        // Base class for all AST nodes
    }

    public class ProgramNode : AstNode
    {
        public readonly IdentifierNode Identifier;
        public readonly BlockNode Block;

        public ProgramNode(IdentifierNode identifier, BlockNode block)
        {
            Identifier = identifier;
            Block = block;
        }
    }

    // Define other AST node classes here...
}