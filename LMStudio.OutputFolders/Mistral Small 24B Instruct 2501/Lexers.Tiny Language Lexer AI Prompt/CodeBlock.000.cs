// Define tokens for our lexer
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
    While,
    Do,
    End,
    Print,
    LeftParenthesis,
    RightParenthesis,
    Semicolon,
    EOF
}

public record Token(TokenType Type, string? Value);