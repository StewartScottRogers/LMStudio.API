// Token.cs
public readonly record struct TokenTuple(TokenType Type, string Value);

// TokenType.cs
public enum TokenType
{
    Identifier,
    Number,
    Plus,
    Minus,
    Multiply,
    Divide,
    Assign,
    If,
    Then,
    End,
    While,
    Do,
    Print,
    Semicolon,
    LeftParen,
    RightParen,
    EndOfFile
}