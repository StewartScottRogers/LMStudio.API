using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace LexerLibrary
    {
        public class AbstractSyntaxTreeNode
        {
            public string Token { get; set; }
            public List<AbstractSyntaxTreeNode> Children { get; set; }

            public AbstractSyntaxTreeNode(string token)
            {
                Token = token;
                Children = new List<AbstractSyntaxTreeNode>();
            }
        }

        // Add methods to handle the lexing and parsing logic for the provided grammar.
        // For brevity, I'll provide a skeleton structure. You can expand this based on the given grammar.

        public class Lexer
        {
            private readonly string input;
            private int position;

            public Lexer(string input)
            {
                this.input = input;
                this.position = 0;
            }

            public Token NextToken()
            {
                // Implement tokenization logic here.
                while (position < input.Length && char.IsWhiteSpace(input[position]))
                {
                    position++;
                }

                if (position >= input.Length)
                {
                    return new EndMarkerToken();
                }

                char currentChar = input[position];

                if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    string identifier = "";
                    while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
                    {
                        identifier += input[position];
                        position++;
                    }
                    return new IdentifierToken(identifier);
                }

                else if (Character.IsWhiteSpace(character))
                {
                    var whiteSpaceBuilder = new StringBuilder();
                    while (position < code.Length && Character.IsWhiteSpace(code[position]))
                    {
                        whiteSpaceBuilder.Append(code[position]);
                        position++;
                    }

                    WhiteSpaces.Add(new WhitespaceToken(whiteSpaceBuilder.ToString(), LineNumber, ColumnNumber));
                }
            } else if (char == '(' || char == '{' || char == '[')
            {
                // Handle open brackets
                OpenBrackets.Add(char);
            } else if (char == ')' || char == '}' || char == ']')
            {
                // Handle close brackets
                if (OpenBrackets.Count > 0 && OpenBrackers.Pop() != char)
                {
                    throw new InvalidOperationException("Mismatched brackets");
                }
            }

The provided grammar defines a set of rules for parsing Python-like statements. To create a lexer and parser for this grammar, we need to follow several steps:

1. **Define Token Types**: Identify the token types based on the grammar.
2. **Create a Lexer**: Implement a lexer that converts input text into a sequence of tokens.
3. **Generate an Abstract Syntax Tree (AST)**: Implement classes and methods to generate an AST from the token sequence.
4. **Implement an AST Pretty Printer**: Create a method to print the AST in a human-readable format.
5. **Unit Tests**: Write unit tests using Microsoft's Unit Test Framework.

Let's break down the solution into manageable steps:

### Step 1: Initialize a New Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new Class Library project targeting .NET 9.0.
3. Name the project `LexerLibrary`.

### Project Structure