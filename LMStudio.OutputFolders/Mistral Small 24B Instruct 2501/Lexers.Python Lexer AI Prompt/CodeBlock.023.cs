using System;

public class Token
{
    public readonly TokenType Type;
    public readonly string Value;

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Type}: {Value}";
    }
}

public enum TokenType
{
    Identifier,
    Keyword,
    Operator,
    Punctuation,
    Literal,
    Whitespace,
    EndMarker,
    Invalid
}