using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace PythonLexer
{
    public static class Lexer
    {
        private static readonly Dictionary<string, TokenType> Keywords = new()
        {
            { "class", TokenType.Class },
            { "def", TokenType.FunctionDef },
            // Add other keywords as needed
        };

        private static readonly HashSet<string> SingleTokenKeywords = new()
        {
            "pass",
            "break",
            "continue",
            "return",
            "raise",
            "global",
            "nonlocal",
            "assert",
        };

        const string Newline = "\n";
        const string Endmarker = "<ENDMARKER>";
        const string TypeComment = "# type: ";
        const string Indent = "    ";

# Solution Structure

The solution will be structured as follows:

1. **Lexer Project**:
   - Contains the lexer classes and methods for tokenizing the input based on the given grammar.
   - Includes unit tests for the lexer.

2. **Abstract Syntax Tree (AST) Project**:
   - Contains classes for all nodes in the AST.
   - Includes a pretty printer for the AST.
   - Includes unit tests for the AST and pretty printer.

3. **Solution Structure**: