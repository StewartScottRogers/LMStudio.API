namespace PascaleLexer.AST
{
    public readonly record struct ConstantDefinitionNode(string Identifier, object Value, int Position);
}