using System.Collections.Generic;

namespace LexerLibrary;

public abstract class AstNode
{
    public AstNodeType NodeType { get; set; }
}