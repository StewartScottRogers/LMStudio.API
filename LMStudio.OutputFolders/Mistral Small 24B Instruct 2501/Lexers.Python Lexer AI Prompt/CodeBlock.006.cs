using System;
using System.Collections.Generic;
using System.IO;

namespace AstLexerLibrary
{
    public enum TokenType
    {
        Identifier,
        Keyword,
        Operator,
        Literal,
        Newline,
        EndMarker,
        Comment,
        // Add other token types as needed based on the grammar
    }

    public class Token
    {
        public readonly string Value;
        public readonly TokenType Type;

        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }
    }

    public interface ILexer
    {
        IEnumerable<Token> Lex(string input);
    }

    public class PythonLexer : ILexer
    {
        private readonly Dictionary<string, TokenType> Keywords;

        public PythonLexer()
        {
            Keywords = new Dictionary<string, TokenType>
            {
                { "False", TokenType.BooleanLiteral },
                { "None", TokenType.NoneLiteral },
                { "True", TokenType.BooleanLiteral },
                { "and", TokenType.And },
                { "as", TokenType.As },
                { "assert", TokenType.Assert },
                { "async", TokenType.Async },
                { "await", TokenType.Await },
                { "break", TokenType.Break },
                { "class", TokenType.Class },
                { "continue", TokenType.Continue },
                { "def", TokenType.Def },
                { "del", TokenType.Del },
                { "elif", TokenType.Elif },
                { "else", TokenType.Else },
                { "except", TokenType.Except },
                { "finally", TokenType.Finally },
                { "for", TokenType.For },
                { "from", TokenType.From },
                { "global", TokenType.Global },
                { "import", TokenType.Import },
                { "in", TokenType.In },
                { "nonlocal", TokenType.NonLocal },
                { "pass", TokenType.Pass },
                { "raise", TokenType.Raise },
                { "return", TypeReturn },
                { "yield", TypeYield }.

To create a Class Library to lex the given grammar and generate an Abstract Syntax Tree (AST) with pretty printing, we will follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create the project structure.**
3. **Define the necessary classes, interfaces, enumerations, and records.**
4. **Implement the Lexer for the given grammar.**
5. **Generate the Abstract Syntax Tree (AST) nodes.**
6. **Create an AST Pretty Printer.**
7. **Develop unit tests using Microsoft's Unit Test Framework.**

Below is a solution that adheres to the specified requirements.

### Solution Structure