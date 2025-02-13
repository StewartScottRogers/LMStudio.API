using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private readonly List<Token> tokens = new();

        public IEnumerable<Token> Tokens => tokens.AsReadOnly();

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public void Tokenize()
        {
            while (position < input.Length)
            {
                var token = NextToken();
                if (token is not null)
                {
                    tokens.Add(token);
                }
            }
        }

        private Token NextToken()
        {
            // Skip whitespace
            while (position < input.Length && char.IsWhiteSpace(input[position]))
            {
                position++;
            }

            if (position >= input.Length)
            {
                return null;
            }

            char currentChar = input[position];

            // Handle identifiers, keywords, and literals
            if (char.IsLetter(currentChar) || currentChar == '_')
            {
                int startPos = position;
                while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
                {
                    position++;
                }
                string token = input.Substring(startPos, position - startPos);
                // Token processing logic here
                return token;
            }

To create a .NET 9.0 solution that lexes the given grammar and generates an Abstract Syntax Tree (AST) along with a Pretty Printer for the AST, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure ensuring each class, interface, enumeration, and record is in its own file.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project and key points of logic for easy comprehension.**

Let's start by creating the solution structure and the necessary files.

### Solution Structure

1. **LexerSolution**
   - **LexerProject**
     - **Models**
       - Statement.cs
       - SimpleStmt.cs
       - CompoundStmt.cs
       - Assignment.cs
       - Augassign.cs
       - ReturnStmt.cs
       - RaiseStmt.cs
       - GlobalStmt.cs
       - NonlocalStmt.cs
       - DelStmt.cs
       - YieldStmt.cs
       - AssertStmt.cs
       - ImportStmt.cs
       - ImportName.cs
       - ImportFrom.cs
       - ImportFromTargets.cs
       - ImportFromAsNames.cs
       - ImportFromAsName.cs
       - DottedAsNames.cs
       - DottedAsName.cs
       - DottedName.cs
        function_def: 'def' name '(' [params] ')': block
functionDefTuple

Create a complete .NET 9.0 Solution in Visual Studio 2022, with the following structure and coding style:

### Solution Structure: