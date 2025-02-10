using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LexerLib
{
    public class PythonLexer : ILexer
    {
        private readonly StreamReader _reader;
        private readonly List<string> _tokens = new();
        private readonly string[] _tokenTypes =
        {
            // Define your token types here based on the grammar provided
            "NAME", "NUMBER", "STRING", "NEWLINE", "INDENT",
            "DEDENT", "LPAREN", "RPAREN", "LSQUARE", "RSQUARE",
            "COLON", "COMMA", "SEMI", "PLUS", "MINUS",
            "STAR", "SLASH", "VBAR", "AMPER", "LESS", "GREATER",
            "EQUAL", "DOT", "OPEN_PAREN", "CLOSE_PAREN", "OPEN_BRACKET",
            "CLOSE_BRACKET", "OPEN_BRACE", "CLOSE_BRACE", "COLON", "COMMA",
            "SEMICOLON", "ARROW", "EQUAL", "STAR", "AWAIT", "NEWLINE",
            "ENDMARKER", "NAME", "STRING", "NUMBER", "BYTESTRING", "INTEGER",
            "FLOAT", "IMAGINARY", "ELLIPSIS", "OPEN_PAREN", "CLOSE_PAREN",
            "COMMA", "COLON", "SEMICOLON", "PLUS", "MINUS", "STAR", "SLASH",
            "VERTICAL_BAR", "AMPERSAND", "LESS_THAN", "GREATER_THAN", "EQUALS",
            "PERCENT", "CARET", "TILDE", "LEFT_SHIFT", "RIGHT_SHIFT", "DOUBLE_STAR",
            "AT", "SLASH", "BACK_SLASH", "COMMA" # Added some common symbols for completeness

Sure, let's break down the steps to create a .NET 9.0 solution that includes a Class Library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and pretty-printing the AST.

### Solution Structure
1. **Solution Name**: LexerLibrary
2. **Projects**:
   - **LexerLibrary**: Class Library containing the lexer, AST nodes, and pretty printer.
   - **LexerLibraryTests**: Unit Tests for the LexerLibrary.

### Step-by-Step Solution

#### 1. Initialize a new Solution in Visual Studio

- Create a new solution named `LexerSolution`.
- Add two projects:
  - `LexerLibrary` (Class Library)
  - `LexerLibraryTests` (Unit Test Project)

#### 2. Define the project structure

**LexerLibrary**