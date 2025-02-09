public sealed class ProgramNode : AstNode {
    public readonly IdentifierNode Identifier;
    public readonly BlockNode Block;

    public ProgramNode(IdentifierNode identifier, BlockNode block, int line, int column) 
        : base(line, column) {
        Identifier = identifier;
        Block = block;
    }

    public override string PrettyPrint() => $"Program {Identifier.PrettyPrint()} {{\n{Block.PrettyPrint()}\n}}";
}