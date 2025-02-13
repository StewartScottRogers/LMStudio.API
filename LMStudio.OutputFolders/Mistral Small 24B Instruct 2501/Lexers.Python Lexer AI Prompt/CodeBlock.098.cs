namespace LexerProject
{
    public enum StatementType
    {
        Compound,
        Simple
    }

    public readonly record StatementTuple(StatementType Type, AstNode Node);
}