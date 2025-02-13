public enum TokenType
{
    Identifier,
    Keyword,
    Operator,
    Literal,
    Punctuation,
    Newline,
    EndMarker
}

public record Token
{
    public readonly string Value;
    public readonly TokenType Type;

    public Token(string value, TokenType type)
    {
        Value = value;
        Type = type;
    }
}