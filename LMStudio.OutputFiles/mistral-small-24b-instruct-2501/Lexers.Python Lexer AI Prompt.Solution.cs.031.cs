using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public static class Lexer
    {
        private readonly List<string> keywords = new() { "if", "else", "while", "for", "try", "except", "finally", "return", "break", "continue", "pass", "def", "class", "import", "from", "as", "with", "yield", "raise", "global", "nonlocal", "del", "assert", "if", "elif", "match", "case", "in", "is", "not", "and", "or", "lambda" TYPE_COMMENT? NEWLINE INDENT
# .NET Solution for Lexer, Abstract Syntax Tree (AST) and Pretty Printer

## Solution Structure
1. **LexerLibrary**: Class library for lexing the grammar.
2. **AstNodesLibrary**: Class library for defining AST nodes.
3. **PrettyPrinterLibrary**: Class library for pretty-printing the AST.

## File System Structure