namespace PascaleLexer.AST
{
    public readonly record struct ProgramNode(string Name, BlockNode Block, int Position);
}