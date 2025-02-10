using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public class TokenType
    {
        public const string Name = "Name";
        public const string Number = "Number";
        // Add other token types as needed.
    }

    public class Lexer
    {
        private readonly StreamReader InputStream;
        private readonly List<string> Tokens;

        public Lexer(Stream input)
        {
            this.InputStream = new StreamReader(input);
            this.Tokens = new List<string>();
        }

        public void Tokenize()
        {
            string line;
            while ((line = InputStream.ReadLine()) != null)
            {
                var tokens = SplitIntoTokens(line);
                Tokens.AddRange(tokens);
            }
        }

        private IEnumerable<string> SplitIntoTokens(string line)
        {
            // Implement tokenization logic based on the provided grammar
            // This is a placeholder implementation
            return new[] { line };
        }

        public readonly List<string> Tokens = new();

        // Additional methods and properties as needed

# Implementation Steps:

1. **Initialize the Solution in Visual Studio:**
   - Open Visual Studio 2022.
   - Create a new .NET 9.0 Class Library project.

2. **Project Structure:**
   - Separate files for each class, interface, enumeration, and record.

3. **Implement the Lexer:**
   - Create a lexer that can parse the given grammar.
   - Generate an Abstract Syntax Tree (AST) from the parsed input.
   - Implement a pretty printer to print the AST in a readable format.

Here is a step-by-step guide to create the solution:

### Step 1: Initialize the Solution

1. **Create a new .NET Solution in Visual Studio 2022.**
2. **Add a Class Library project to the solution.**

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record.

- **Lexer.cs**: Contains the main lexing logic.
- **SyntaxTreeNode.cs**: Base class for all syntax tree nodes.
- **StatementNodes.cs**: Classes for different statement types.
- **ExpressionNodes.cs**: Classes for different expression types.
- **PrettyPrinter.cs**: Pretty prints the Abstract Syntax Tree (AST).
- **Lexer.cs**: The lexer for tokenizing the input.
- **Program.cs**: The entry point of the application.

Below is a structured solution following the given requirements:

### Solution Structure