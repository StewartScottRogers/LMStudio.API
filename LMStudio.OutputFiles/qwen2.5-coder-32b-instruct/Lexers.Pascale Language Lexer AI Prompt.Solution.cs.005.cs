public sealed class IdentifierNode : AstNode {
    public readonly string Name;

    public IdentifierNode(string name, int line, int column) 
        : base(line, column) {
        Name = name;
    }

    public override string PrettyPrint() => $"{Name}";
}