using System;
using System.Collections.Generic;
using System.IO;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private int lineNumber;
        private int columnNumber;
        private List<Token> tokens;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.lineNumber = 1;
            this.columnNumber = 1;
            this.tokens = new List<Token>();
        }

To create a .NET 9.0 solution for the given grammar, we need to follow the specified coding style and structure. Below is a step-by-step guide to initialize the solution, define the project structure, implement the lexer, generate the Abstract Syntax Tree (AST), and write unit tests.

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new project.
3. Select "Class Library" and name it `LexerLibrary`.
4. Ensure the target framework is .NET 9.0.

### Project Structure