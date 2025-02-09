// TokenKind.cs
namespace TinyLanguageLexer
{
    public enum TokenKind
    {
        Unknown,
        Identifier,
        Number,
        Plus,
        Minus,
        Star,
        Slash,
        ColonEquals,
        Semicolon,
        IfKeyword,
        ThenKeyword,
        WhileKeyword,
        DoKeyword,
        EndKeyword,
        PrintKeyword,
        LeftParenthesis,
        RightParenthesis,
        GreaterThan, // Added
        LessThan     // Added
    }
}

// Lexer.cs (updated)
private Token NextToken()
{
    while (currentPos < sourceCode.Length && char.IsWhiteSpace(sourceCode[currentPos]))
        currentPos++;

    if (currentPos >= sourceCode.Length)
        return new Token(TokenKind.Unknown, string.Empty);

    var ch = sourceCode[currentPos];
    currentPos++;

    switch (ch)
    {
        case '+': return new Token(TokenKind.Plus, "+");
        case '-': return new Token(TokenKind.Minus, "-");
        case '*': return new Token(TokenKind.Star, "*");
        case '/': return new Token(TokenKind.Slash, "/");
        case '=': return Match('=', TokenKind.ColonEquals, ":=");
        case ';': return new Token(TokenKind.Semicolon, ";");
        case '(': return new Token(TokenKind.LeftParenthesis, "(");
        case ')': return new Token(TokenKind.RightParenthesis, ")");
        case '>': return new Token(TokenKind.GreaterThan, ">");
        case '<': return new Token(TokenKind.LessThan, "<");
    }

    if (char.IsDigit(ch))
        return ProcessNumber(ch);

    if (char.IsLetter(ch) || ch == '_')
        return ProcessIdentifierOrKeyword(ch);

    throw new InvalidOperationException($"Unknown character: {ch}");
}