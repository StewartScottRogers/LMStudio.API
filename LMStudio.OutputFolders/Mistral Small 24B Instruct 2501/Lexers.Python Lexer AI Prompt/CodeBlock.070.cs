using System;
using System.Collections.Generic;
using System.IO;

namespace PythonLexer
{
    public class Lexer : ILexer
    {
        private readonly string sourceCode;
        private int currentPosition = 0;

        public Lexer(string code)
        {
            this.sourceCode = code;
        }

        public Token GetNextToken()
        {
            while (currentPosition < sourceCode.Length)
            {
                char currentChar = sourceCode[currentPosition];

                // Skip whitespace
                if (char.IsWhiteSpace(currentChar))
                {
                    currentPosition++;
                    continue;
                }

                // Handle comments
                if (currentChar == '#')
                {
                    while (currentPosition < sourceLength && source[currentPosition] != '\n')
                    {
                        currentPosition++;
                    }
                    continue;
                }

To create a .NET 9.0 Solution for lexing the provided grammar, we need to follow the specified coding style and structure. Below is a step-by-step guide along with the necessary code snippets.

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new project:
   - Select "Class Library" from the available templates.
   - Name the project `LexerLibrary`.
3. Add a unit test project to the solution by right-clicking on the solution, selecting "Add", and then "New Project". Choose "Unit Test Project".

### File Structure

The solution will consist of the following files:

1. **Class Definitions**
    - `Token.cs`
    - `Lexer.cs`
2. **Abstract Syntax Tree (AST)**
   - `AstNode.cs`
3. **Pretty Printer**
    - `AstPrinter.cs`
4. **Unit Tests**
    - `LexerTests.cs`

### File: Token.cs