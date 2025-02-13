using System;
using Microsoft.VisualBasic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public TokenStream Parse()
        {
            var tokens = new List<Token>();
            while (position < input.Length)
            {
                char currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }

                switch (currentChar)
                {
                    case '(':
                        tokens.Add(new Token(TokenType.ParenOpen, "("));
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.ParenClose, ")"));
                        break;
                    case '{':
                        tokens.Add(new Token(TokenType.BraceOpen, "{"));
                        break;
                    case '}':
                        tokens.Add(new Token(TokenType.BraceClose, "}"));
                        break;
                    case '[':
                        tokens.Add(new Token(TokenType.BracketOpen, "["));
                        break;
                    case ']':
                        tokens.Add(new Token(TokenType.BracketClose, "]"));
                        break;

To create a .NET 9.0 solution for lexing the given grammar and generating an Abstract Syntax Tree (AST) with pretty printing functionality, follow these steps:

### Step 1: Initialize a New Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new Class Library project targeting .NET 9.0.
3. Name the solution `LexerSolution` and the project `LexerLibrary`.

### Step 2: Define the Project Structure
Create separate files for each class, interface, enumeration, and record.

#### LexerSolution
- `LexerLibrary`
  - `AstNode.cs`
  - `AbstractSyntaxTreePrinter.cs`
  - `Lexer.cs`
  - `Token.cs`
  - `TokenType.cs`
  - `ILexer.cs`
  - `Program.cs`

### Solution Structure

1. **Class Library Project**:
    - Create a new Class Library project in Visual Studio.
    - Name the project `PythonLexer`.

2. **File System Structure**:
    - Each class, interface, enumeration, and record will be in its own file.

3. **Code Documentation**:
    - Add comments to explain complex code structures or logic.

4. **Unit Testing**:
    - Use Microsoft Unit Test Framework.
    - Include unit tests for every entry point in the tested code.
    - Write three times as many unit tests as initially thought necessary.
    - Ensure all bounding conditions are tested.

Let's break down the solution into several parts:

1. **Project Structure**
2. **Class Library for Lexer**
3. **Abstract Syntax Tree (AST)**
4. **AST Pretty Printer**
5. **Unit Tests**

### 1. Project Structure

Create a new .NET Solution in Visual Studio with the following structure: