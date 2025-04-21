namespace LexerLibrary;

public class TermNode : AstNode
{
    public FactorNode Left { get; set; }
    public string Operator { get; set; }
    public TermNode Right { get; set; }

    public TermNode()
    {
        NodeType = AstNodeType.Term;
    }
}