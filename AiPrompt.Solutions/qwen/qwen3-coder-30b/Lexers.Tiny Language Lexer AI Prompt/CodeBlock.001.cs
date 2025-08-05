namespace LexerLibrary
{
    /// <summary>
    /// Enumeration of all possible token types in our grammar.
    /// </summary>
    public enum TokenType
    {
        // Keywords
        If,
        Then,
        End,
        While,
        Do,
        Print,

        // Operators and punctuation
        Assign,
        Plus,
        Minus,
        Multiply,
        Divide,
        LeftParen,
        RightParen,
        Semicolon,

        // Identifiers and literals
        Identifier,
        Number,

        // Special tokens
        Eof,
        Unknown
    }
}