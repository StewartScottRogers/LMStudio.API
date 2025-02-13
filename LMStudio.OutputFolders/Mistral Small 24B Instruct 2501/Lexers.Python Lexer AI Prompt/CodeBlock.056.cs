using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

namespace LexerLibrary
{
    public class Token
    {
        public readonly string Type { get; }
        public readonly string Value { get; }

        public Token(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"Token({Type}, {Value})";
        }
    }

    public enum TokenType
    {
        Name,
        Number,
        String,
        Newline,
        Endmarker,
        Indent,
        Dedent,
        // Add more token types as needed based on the grammar.
    }

Let's start by creating a .NET 9.0 solution in Visual Studio 2022 with the specified coding style and requirements.

### Step-by-Step Solution

1. **Initialize a new Solution in Visual Studio**:
   - Create a new Class Library project named `LexerLibrary`.
   - Add necessary class, interface, enumeration, and record files.
   - Ensure all files are compilable and executable without additional coding.

2. **Define the Project Structure**:
   - Each class, interface, enumeration, and record should be in its own file.

3. **Implement the Lexer**:
   - Create a lexer that can parse the provided grammar.
   - Generate an Abstract Syntax Tree (AST) from the parsed input.

4. **Generate AST Pretty Printer**:
   - Create a pretty printer to display the AST in a readable format.

5. **Unit Testing**:
   - Write unit tests for the lexing process using Microsoft's Unit Test Framework.

Here is a step-by-step guide to create the solution:

### Step 1: Initialize the Solution

1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Ensure the target framework is .NET 9.0.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as specified.

#### Directory Structure