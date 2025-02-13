// File: Token.cs
using System;

namespace PythonLexer
{
    public enum TokenType
    {
        NAME,
        NUMBER,
        STRING,
        FSTRING_START,
        FSTRING_MIDDLE,
        FSTRING_END,
        NEWLINE,
        INDENT,
        DEDENT,
        ENDMARKER,
        AWAIT,
        STAR_EXPRESSIONS,
        // Add other tokens as needed
    }

Below is a .NET 9.0 solution that includes a lexer for the provided grammar, an Abstract Syntax Tree (AST) pretty printer, and unit tests using Microsoft's Unit Test Framework.

### Solution Structure

1. **LexerProject**
   - **Classes**
     - Lexer.cs
     - TokenType.cs
     - Token.cs
   - **Interfaces**
     - ILexer.cs
   - **Enumerations**
     - Keyword.cs
   - **Records**
     - AbstractSyntaxTreeNodeRecord.cs
   - **Unit Tests**
     - UnitTest1.cs

### File System Structure