public enum TokenType
{
    Identifier,
    Number,
    Plus,
    Minus,
    Multiply,
    Divide,
    LeftParenthesis,
    RightParenthesis,
    EndOfFile,
    ColonEquals,
    IfKeyword,
    ThenKeyword,
    WhileKeyword,
    DoKeyword,
    PrintKeyword,
    EndKeyword
}

public record Token(TokenType Type, string Value)
{
    public override string ToString() => $"{Type}: {Value}";
}