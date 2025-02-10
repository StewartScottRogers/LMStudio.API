using System;

namespace PascalLexerClassLibrary
{
    public enum TokenType
    {
        Identifier,
        Number,
        StringLiteral,
        Keyword,
        Operator,
        Punctuation,
        Whitespace,
        Eof
    }

    public readonly record Token(TokenType Type, string Value);
}