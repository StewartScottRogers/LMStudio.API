using System.Collections.Generic;

namespace LexerLibrary;

public class ProgramNode : AstNode
{
    public List<AstNode> Statements { get; set; } = new List<AstNode>();

    public ProgramNode()
    {
        NodeType = AstNodeType.Program;
    }
}