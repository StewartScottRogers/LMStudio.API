public abstract class AstNode {
    public int LineNumber { get; set; }

    // Abstract methods and properties specific to each node type
}

public class Program : AstNode {
    public List<Statement> Statements { get; } = new();
}