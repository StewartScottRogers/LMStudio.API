public sealed class BlockNode : AstNode {
    // For simplicity, just a list of statements.
    public readonly List<AstNode> Statements;

    public BlockNode(List<AstNode> statements, int line, int column) 
        : base(line, column) {
        Statements = statements;
    }

    public override string PrettyPrint() => string.Join("\n", Statements.Select(s => s.PrettyPrint()));
}