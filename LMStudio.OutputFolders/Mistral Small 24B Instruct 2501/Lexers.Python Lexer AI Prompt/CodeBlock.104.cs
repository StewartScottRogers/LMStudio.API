using System;
using System.Collections.Generic;
using System.Linq;

namespace LexerLibrary
{
    public static class Lexer
    {
        private readonly string input;
        private int position;
        private List<Token> Tokens { get; }

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.Tokens = new List<Token>();
        }

        public void Lex()
        {
            while (position < input.Length)
            {
                var char = Peek();

                if (char == '\n' || char == ' ')
                    Advance();
                else
                {
                    switch (char)
                    {
                        case ':':
                            Tokens.Add(new Token(TokenType.COLON, ":"));
                            break;
                        case ',':
                            Tokens.Add(new Token(TokenType.COMMA, ","));
                            break;
                        case '.':
                            Tokens.Add(new Token(TokenType.DOT, "."));
                            break;
                        case ';':
                            Tokens.Add(new Token(TokenType.SEMICOLON, ";"));
                            break;
                    }
                }

            }
        }

        private static readonly Dictionary<string, TokenType> Keywords = new()
        {
            { "if", TokenType.If },
            { "else", TokenType.Else },
            { "elif", TokenType.Elif },
            { "while", TokenType.While },
            { "for", TokenType.For },
            { "in", TokenType.In },
            { "try", TokenType.Try },
            { "except", TokenType.Except },
            { "finally", TokenType.Finally },
    { "match", TokenType.Match },
    { "case", TokenType.Case },
    { "return", TokenType.Return },
    { "raise", TokenType.Raise },
    { "assert", TokenType.Assert },
    { "import", TokenType.Import },
    { "from", TokenType.From },
    { "pass", TokenType.Pass },
    { "del", TokenType.Del },
    { "global", TokenType.Global },
    { "nonlocal", TokenType.Nonlocal },
    { "assert", TokenType.Assert },
    { "import", TokenType.Import },
    { "from", TokenType.From },
    { "class", TokenType.Class },
    { "def", TokenType.Def },
    { "return", TokenType.Return },
    { "if", TokenType.If },
    { "elif", TokenType.Elif },
    { "else", TokenType.Else },
    { "for", TokenType.For },
    { "while", TokenType.While },
    { "with", TokenType.With },
    | "match" subject_expr ':' NEWLINE INDENT case_block+ DEDENT 
    | "case" patterns guard? ':' block 

To create a .NET 9.0 solution that meets the requirements specified, we need to follow several steps. Below is a high-level overview of the project structure and implementation details.

### Project Structure

1. **LexerLibrary**: The main class library containing the lexer and AST nodes.
2. **AstPrinter**: A separate class for pretty-printing the Abstract Syntax Tree (AST).
3. **UnitTests**: Unit tests using Microsoft's Unit Test Framework.

### Implementation Details

#### 1. LexerLibrary
- **Lexer.cs**: Class to handle lexical analysis of the given grammar.
- **Token.cs**: Enum to define tokens based on the grammar.
- **AstNode.cs**: Base class for all AST nodes.
- Various specific classes for different types of statements, expressions, etc.

### Solution Structure