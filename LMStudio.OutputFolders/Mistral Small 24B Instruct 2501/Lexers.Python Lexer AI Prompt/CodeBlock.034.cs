using System;
using System.Collections.Generic;

namespace LexerSolution
{
    public class AbstractSyntaxTree
    {
        private readonly List<StatementNode> Statements;

        public AbstractSyntaxTree()
        {
            Statements = new List<StatementNode>();
        }

        public void AddStatement(StatementNode statement)
        {
            Statements.Add(statement);
        }

        public IEnumerable<StatementNode> GetStatements() => Statements;
    }
}

namespace LexerApp.Lexer
{
    // Define the tokens for the lexer
    internal enum TokenType
    {
        Identifier,
        Keyword,
        Operator,
        Literal,
        NewLine,
        EndMarker,
        Indent,
        Dedent,
        Invalid
    }

    public class Token
    {
        private readonly string value;
        private readonly TokenType type;

        public Token(string value, TokenType type)
        {
            this.value = value;
            this.type = type;
        }

        public string Value => value;
        public TokenType Type => type;
    }

To create a .NET 9.0 Solution for lexing the provided grammar and generating an Abstract Syntax Tree (AST), we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure ensuring each class, interface, enumeration, and record is in its own file.**
3. **Develop the Lexer for the given Grammar.**
4. **Generate an Abstract Syntax Tree (AST) Pretty Printer.**
5. **Generate all nodes in the AST.**
6. **Develop Unit Tests using Microsoft's Unit Test Framework.**

Let's break down the solution into manageable steps and create the necessary files and code.

### Solution Structure

1. **Solution Setup**
   - Create a new .NET 9.0 Class Library project.
   - Add necessary folders and files for classes, interfaces, enumerations, records, and tests.

2. **Lexer Implementation**
   - Define tokens based on the provided grammar.
   - Implement methods to tokenize input strings.
   - Handle different types of statements, expressions, and literals.

3. **Abstract Syntax Tree (AST)**
   - Define nodes for each type of statement and expression.
   - Implement a parser that converts tokens into an AST.
   - Implement a pretty printer for the AST.

4. **Unit Tests**
   - Write unit tests to validate the lexer, parser, and pretty printer.

Here's a step-by-step guide to creating the solution:

### Step 1: Initialize the Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new .NET 9.0 Class Library project.
3. Name the project `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as specified.

#### File Structure: