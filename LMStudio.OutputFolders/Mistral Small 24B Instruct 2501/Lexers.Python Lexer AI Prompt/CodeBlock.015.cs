using System;
using System.Collections.Generic;

namespace AbstractSyntaxTreeNodes
{
    public class StatementNode : INode
    {
        public List<SimpleStmtNode> SimpleStatements { get; private set; }

        // Constructor to initialize the list
        public StatementNode(List<SimpleStmtNode> simpleStatements)
        {
            SimpleStatements = simpleStatements;
        }
    }

    public class SimpleStmtNode : NodeBase
    {
        public ExpressionNode ExpressionNode { get; readonly set; }
        public NewLineNode NewlineNode { get; readonly set; }

        public SimpleStmtNode(ExpressionNode expression, NewLineNode newline)
        {
            ExpressionNode = expression;
            NewlineNode = newline;
        }
    }

    public class Lexer
    {
        private string input;

        public Lexer(string input)
        {
            this.input = input;
        }

        public IEnumerable<string> Tokenize()
        {
            var tokens = new List<string>();
            var position = 0;

            while (position < input.Length)
            {
                if (char.IsWhiteSpace(input[position]))
                {
                    position++;
                    continue;
                }

                if (IsKeyword(input, position))
                {
                    tokens.Add(ReadKeyword(input, ref position));
                    continue;
                }

                // Add more token types and reading logic as needed

                throw new InvalidOperationException("Unexpected character");
            }
        }

        private bool IsKeyword(string input, int startIndex)
        {
            foreach (var keyword in Keywords)
            {
                if (input.StartsWith(keyword, startIndex, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        private static readonly string[] Keywords = new string[]
        {
            "if", "else", "elif", "for", "while", "try", "except", "finally",
            "with", "def", "return", "import", "from", "as", "class", "pass",
            "global", "nonlocal", "del", "yield", "raise", "assert", "continue",
            "break", "match", "case"
To create a .NET 9.0 Solution that lexes the provided grammar and generates an Abstract Syntax Tree (AST) along with a Pretty Printer, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio**:
   - Create a new .NET Class Library project.
   - Ensure it is compatible with .NET 9.0.

2. **Define the Project Structure**:
   - Create separate files for each class, interface, enumeration, and record as per the given grammar.

3. **Develop the Lexer**:
   - Implement a lexer that can parse the given grammar.
   - Generate an Abstract Syntax Tree (AST) from the parsed tokens.
   - Create a pretty printer to display the AST in a readable format.

Here's a step-by-step guide to creating this solution in C#:

### Step 1: Initialize the Solution

1. Open Visual Studio 2022.
2. Create a new Solution called `LexerLibrary`.
3. Add a new Class Library project called `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record.

#### Directory Structure: