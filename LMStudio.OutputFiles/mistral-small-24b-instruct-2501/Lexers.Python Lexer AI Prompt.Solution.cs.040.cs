using System;
    using System.Collections.Generic;
    using System.IO;

    namespace PythonLexer
    {
        public static class TokenType
        {
            public const string Identifier = "Identifier";
            public const string Keyword = "Keyword";
            public const string Number = "Number";
            public const string StringLiteral = "StringLiteral";
            public const string Operator = "Operator";
            public const string Punctuation = "Punctuation";
            // Add other token types as needed
        }

To create a lexer for the given grammar, we need to break down the problem into several key components:

1. **Token Definition**: Define the tokens based on the grammar.
2. **Lexer Class**: Implement the lexer that will read the input and generate tokens.
3. **Abstract Syntax Tree (AST) Nodes**: Create classes for each node in the AST.
4. **AST Pretty Printer**: Implement a class to print the AST in a readable format.
5. **Unit Tests**: Write unit tests using Microsoft's Unit Test Framework.

Below is the step-by-step implementation of the solution:

### Step 1: Initialize a new Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new .NET 9.0 Class Library project.
3. Name the solution `LexerLibrary`.

### Step 2: Define the Project Structure
Create separate files for each class, interface, enumeration, and record as specified.

#### File: Lexer.cs