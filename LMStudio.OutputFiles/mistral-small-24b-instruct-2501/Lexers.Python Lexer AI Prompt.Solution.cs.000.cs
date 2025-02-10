using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;

namespace LexerApp
{
    public enum TokenType
    {
        Identifier,
        Keyword,
        Literal,
        Operator,
        Punctuation,
        EndOfFile
    }

    public class Token
    {
        public readonly TokenType Type { get; }
        public readonly string Value { get; }
        public readonly int Position { get; }

        public Token(TokenType type, string value, int position)
        {
            Type = type;
            Value = value;
            Position = position;
        }
    }

Based on the given requirements and grammar, we'll create a .NET 9.0 Solution in C# that includes:

1. A lexer for the provided grammar.
2. An Abstract Syntax Tree (AST) with nodes.
3. An AST Pretty Printer.
4. Unit tests using Microsoft's Unit Test Framework.

### Solution Structure