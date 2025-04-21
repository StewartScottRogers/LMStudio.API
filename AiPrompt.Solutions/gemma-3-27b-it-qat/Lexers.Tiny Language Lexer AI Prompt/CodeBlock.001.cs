namespace LexerLibrary;

public record Token(TokenType Type, string Value)
{
    public override string ToString()
    {
        return $"({Type}, {Value})";
    }
}