using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class TokenType
    {
        public const string ENDMARKER = "ENDMARKER";
        public const string NEWLINE = "NEWLINE";
        public const string INDENT = "INDENT";
        public const string DEDENT = "DEDENT";

        // Add other token types based on the grammar provided

        // Example:
        //public readonly static class TokenType
        //{
        //    public const string NAME = "NAME";
        //    public const string NUMBER = "NUMBER";
        //    public const string STRING = "STRING";
        //}
        }

To create a .NET 9.0 Solution for the described Lexer and Abstract Syntax Tree (AST) Pretty Printer, we'll follow these steps:

1. **Initialize a new Solution in Visual Studio**.
2. **Define the project structure** ensuring each class, interface, enumeration, and record is in its own file.
3. **Develop unit tests using Microsoft's Unit Test Framework**.
4. **Include comprehensive comments for any non-trivial logic or structure to enhance understanding.**
5. **Create a .README or documentation summarizing the project and key points of logic for easy comprehension.**

# Solution Structure

1. **Lexer Class**: This class will be responsible for tokenizing the input based on the given grammar.
2. **Abstract Syntax Tree (AST) Nodes**: These classes represent different nodes in the AST.
3. **AST Pretty Printer**: This class will handle the pretty printing of the AST.
4. **Unit Tests**: These will test the lexing functionality and ensure that the lexer behaves as expected.

Here is a step-by-step guide to creating the solution:

### Step 1: Initialize a New Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Ensure the target framework is .NET 9.0.

### Step by Step Implementation

#### 1. Define the Project Structure

Create separate files for each class, interface, enumeration, and record as specified in the problem statement.

#### 2. Implement Lexer Classes

We will start with the implementation of the lexer classes. We'll create a basic structure that can be extended to handle more complex tokens later.

##### Lexer.cs