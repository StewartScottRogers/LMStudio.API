﻿// Token.cs
namespace TinyLanguageLexer
{
    public readonly record struct Token(TokenKind Kind, string Value);
}