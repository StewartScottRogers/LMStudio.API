using System;
using System.Collections.Generic;
using System.IO;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly string Input;
        private int Position;
        private List<Token> Tokens;

        public Lexer(string input)
        {
            Input = input;
            Position = 0;
            Tokens = new List<Token>();
        }

        public void Lex()
        {
            while (Position < Input.Length)
            {
                char currentChar = Input[Position];

                if (char.IsWhiteSpace(currentChar))
                {
                    Position++;
                    continue;
                }

                if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                {
                    string identifier = ReadIdentifier();
                    // Handle different types of identifiers
                }
                else
                {
                    char token = ReadToken();
                    // Handle different types of tokens
                }
            }

            private static string ReadIdentifier()
            {
                var builder = new StringBuilder();
                while (CanRead() && IsIdentifierChar(CurrentChar))
                {
                    builder.Append(CurrentChar);
                    ReadChar();
                }
                return builder.ToString();
            }

            private static bool CanRead() => Position < Source.Length;

            private static char CurrentChar => Source[Position];

            private static void ReadChar()
            {
                if (CanRead())
                {
                    Position++;
                }
            }

            #region Token Enumeration

            public enum Token
            {
                EndOfInput,
                Identifier,
                Number,
                StringLiteral,
                Newline,
                Indent,
                Dedent,
                Operator,
                Keyword,
                InvalidSyntax,
                Star,
                Dot,
                OpenParen,
                CloseParen,
                OpenBracket,
                CloseBracket,
                OpenBrace,
                CloseBrace,
                Colon,
                Comma,
                SemiColon,
                Equal,
            }

# .NET Solution Structure

## Project Files
1. **LexerLibrary.csproj** - The main project file for the solution.
2. **Token.cs** - Defines the token structure.
3. **Lexer.cs** - Implements the lexer logic.
4. **AstNode.cs** - Defines the base class for AST nodes.
5. **AstPrettyPrinter.cs** - Pretty prints the AST.
6. **AstNodes\<SpecificNodeType>.cs** - Files for each specific AST node type (e.g., AssignmentNode, FunctionDefNode).

### Solution Structure

1. **LexerSolution.sln**: The main solution file.
2. **LexerProject**: The main project containing all the classes, interfaces, and records.
3. **LexerProject.Test**: The test project containing unit tests.

### File Structure