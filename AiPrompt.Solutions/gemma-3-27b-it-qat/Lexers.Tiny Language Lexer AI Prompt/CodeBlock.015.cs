using System.Collections.Generic;

namespace LexerLibrary;

public class StatementListNode : AstNode
{
    public List<AstNode> Statements { get; set; } = new List<AstNode>();

    public StatementListNode()
    {
        NodeType = AstNodeType.StatementList;
    }
}