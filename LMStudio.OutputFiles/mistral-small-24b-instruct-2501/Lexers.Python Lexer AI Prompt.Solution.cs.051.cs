public enum TokenType
{
    Identifier,
    Keyword,
    Literal,
    Operator,
    Punctuation,
    Newline,
    EndMarker,
    // Add other token types as needed
}

public class Token
{
    public readonly TokenType Type;
    public readonly string Value;

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}