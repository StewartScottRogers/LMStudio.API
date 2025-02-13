using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerApp
{
    #region Enums

    /// <summary>
    /// Enum representing the types of tokens.
    /// </summary>
    public enum TokenType
    {
        Newline,
        Indent,
        Dedent,
        Endmarker,
        Name,
        String,
        Number,
        Operator,
        Keyword,
        Await,
        Ellipsis,
        Star,
        OpenParen,
        CloseParen,
        OpenBracket,
        CloseBracket,
        OpenBrace,
        CloseBrace,
        Comma,
        Colon,
        Semicolon,
        Dot,
        Equal,
        Plus,
        Minus,
        Star,
        Slash,
        DoubleSlash,
        Percent,
        Ampersand,
        Pipe,
        Circumflex,
        LeftShift,
        RightShift,
        DoubleStar,
        At,
        LessThanEqual,
        GreaterThanEqual,
        NotEqual,
        Tilde,
    | 'is'
    | 'in'
    | 'not',