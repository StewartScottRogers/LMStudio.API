namespace PascaleLexer.Lexer
{
    public readonly record struct Token(TokenTypes Type, string Value, int Position);
}