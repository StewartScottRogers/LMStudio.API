using System.Collections.Generic;

namespace PascalLexerClassLibrary
{
    public abstract class AstNode
    {
        // Base class for all AST nodes
    }

    public class ProgramNode : AstNode
    {
        public readonly string Identifier;
        public readonly BlockNode Block;

        public ProgramNode(string identifier, BlockNode block)
        {
            Identifier = identifier;
            Block = block;
        }
    }

    public class BlockNode : AstNode
    {
        // Add properties for label declaration part, constant definition part, etc.
    }

    // Define other AST nodes (e.g., LabelDeclarationPartNode, ConstantDefinitionPartNode, etc.)
}