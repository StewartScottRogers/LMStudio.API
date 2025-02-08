public abstract class AstNode
{
    public string Value { get; protected set; }
    
    public AstNode(string value)
    {
        Value = value;
    }

    // Virtual methods for operations like Pretty Printing and visiting.
}

public class ProgramNode : AstNode
{
    public List<IdentifierNode> Identifiers { get; } = new();

    public ProgramNode(string name, IEnumerable<IdentifierNode> identifiers) 
        : base(name)
    {
        Identifiers.AddRange(identifiers);
    }
}