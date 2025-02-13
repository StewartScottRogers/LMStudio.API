using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public sealed class TokenType
    {
        // Define token types based on the grammar
        public static readonly TokenType Newline = new TokenType("NEWLINE");
        public static readonly TokenType Indent = new TokenType("INDENT");
        public static readonly TokenType Dedent = new TokenType("DEDENT");
        public static readonly TokenType Endmarker = new TokenType("ENDMARKER");

    // Class to represent a token
    public class Token
    {
        public string Lexeme { get; set; }
        public TokenType Type { get; set; }

        public Token(string lexeme, TokenType type)
        {
            Lexeme = lexeme;
            Type = type;
        }
    }

    // Enumeration for token types
    public enum TokenType
    {
        Identifier,
        Number,
        StringLiteral,
        Keyword,
        Operator,
        Punctuation,
        Whitespace,
        EndMarker
    }

### Solution Structure

1. **Project Initialization**:
   - Create a new .NET 9.0 Class Library project in Visual Studio 2022.
   - Name the project `PythonLexer`.

2. **File System Structure**:
   - Create separate files for each class, interface, enumeration, and record.

3. **Solution Structure**:
   - Create a `.NET` Class Library project.
   - Add the necessary NuGet packages for Microsoft Unit Testing Framework.

4. **Implementation**:

### File: AbstractSyntaxTree.cs