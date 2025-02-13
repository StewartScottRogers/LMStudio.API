// File: Token.cs
using System;

namespace PascaleLexer
{
    public enum TokenType
    {
        Identifier,
        Number,
        StringLiteral,
        Plus,
        Minus,
        Multiply,
        Divide,
        Equals,
        NotEquals,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        In,
        And,
        Or,
        Not,
        Semicolon,
        Colon,
        Comma,
        Period,
        LeftParentheses,
        RightParentheses,
        LeftBracket,
        RightBracket,
        LeftCurlyBrace,
        RightCurlyBrace,
        Assignment,
        Begin,
        End,
        If,
        Then,
        Else,
        While,
        Do,
        Repeat,
        Until,
        For,
        To,
        Downto,
        Case,
        Of,
        Goto,
        Program,
        Const,
        Type,
        Var,
        Procedure,
        Function,
        Label
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
}