using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;

        public Lexer(string input)
        {
            this.input = input;
        }

        public Token GetNextToken()
        {
            if (position >= input.Length)
            {
                return new Token(TokenType.EndMarker);
            }

            char currentChar = input[position];

            switch (currentChar)
            {
                case ' ':
                    position++;
                    return GetNextToken();
                case '\n':
                    position++;
                    return new Token(TokenType.Newline);
                case '\r':
                    position++;
                    return GetNextToken();
                case '\t':
                    position++;
                    return GetNextToken();
                // Add more cases for other whitespace characters if needed
                default:
                    throw new Exception("Unexpected character");
            }

        // Read the next token from the input stream
        private Token ReadNextToken(StreamReader reader)
        {
            int nextChar = reader.Read();

            while (nextChar != -1 && char.IsWhiteSpace((char)nextChar))
            {
                nextChar = reader.Read();
            }

            if (nextChar == -1)
            {
                return new EndMarkerTuple(reader);
            }

            string tokenString = string.Empty;
            bool isEscapeSequence = false;

            switch ((char)nextChar)
            {
                case '(':
                    TokenType = TokenType.LeftParenthesis;
                    break;
                case ')':
                    TokenType = TokenType.RightParenthesis;
                    break;
                // Add cases for other tokens such as '{', '}', '[', ']', '=', '+', '-', '*', '/', etc.
                // Make sure to cover all the tokens defined in the grammar

Based on your requirements, here is a step-by-step guide to create a .NET 9.0 Solution for a Lexer that handles the provided grammar. This solution will include:

1. **Initialization of the Solution**:
   - Create a new Solution in Visual Studio.
   - Include comprehensive comments for any non-trivial logic or structure.

2. **Project Structure**:
   - Define separate files for each class, interface, enumeration, and record.

3. **Lexer Class**:
   - Develop a lexer that tokenizes the input string based on the given grammar rules.
   - Ensure the lexer handles all specified tokens (e.g., NAME, NUMBER, STRING, etc.).

4. **Abstract Syntax Tree (AST) Nodes**:
   - Create classes for each node type in the AST (e.g., StatementNode, ExpressionNode).

5. **AST Pretty Printer**:
   - Implement a class to pretty-print the AST.

6. **Unit Tests**:
   - Write unit tests for lexing and parsing the provided grammar.

Below is the structure of the solution based on your requirements:

### Solution Structure

1. **Class Library Project**
    - **Lexer.cs**: Contains the lexer implementation.
    - **ASTNode.cs**: Base class for all AST nodes.
    - **SpecificASTNodes.cs**: Contains specific AST node classes.
    - **PrettyPrinter.cs**: Contains the pretty printer implementation.
    - **UnitTests.cs**: Contains unit tests for the lexer.
    - **LexerTestData.cs**: Contains test data for the lexer.

Below is a complete .NET 9.0 Solution in C# that adheres to the given specifications.

### File: LexerSolution.sln