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
        RightParenthesis
    }
}