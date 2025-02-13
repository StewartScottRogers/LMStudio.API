using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LexerLibrary
{
    public class Lexer : ILexer
    {
        private readonly TextReader input;
        private readonly List<string> keywords = new() { "def", "class", "if", "else", "elif", "while", "for", "in", "break", "continue", "pass", "return", "import", "from", "as", "None", "True", "False" }

Creating a .NET 9.0 Solution to lex the given grammar and generate an Abstract Syntax Tree (AST) involves several steps. Below is a comprehensive guide along with the necessary code snippets to achieve this.

### Step 1: Initialize the Solution

1. **Open Visual Studio 2022**.
2. **Create a new .NET 9.0 Class Library project**:
   - Name it `LexerLibrary`.
3. **Add necessary files**:
   - Token.cs
   - Lexer.cs
   - AstNode.cs
   - AstPrettyPrinter.cs
   - UnitTests.cs

Here is the complete code for the solution:

### Token.cs