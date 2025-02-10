using System;
using System.Collections.Generic;
using System.IO;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly string sourceCode;
        private int currentPosition;
        private List<Token> tokens;

        public Lexer(string sourceCode)
        {
            this.sourceCode = sourceCode;
            this.tokens = new();
        }

        public List<Token> Tokenize()
        {
            while (currentPosition < sourceCode.Length)
            {
                char currentChar = sourceCode[currentPosition];

                if (char.IsWhiteSpace(currentChar))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                {
                    var token = ReadIdentifier();
                    yield return new Token(TokenType.Identifier, token);
                    continue;
                }

                switch (current)
                {
                    case '(':
                        yield return new Token(TokenType.LeftParen, current.ToString());
                        break;
                    case ')':
                        yield return new Token(TokenType.RightParen, current.ToString());
                        break;
                    case '{':
                        yield return new Token(TokenType.LeftBrace, current.ToString());
                        break;
                    case '}':
                        yield return new Token(TokenType.RightBrace, current.ToString());
                        break;
                    case '[':
                        yield return new Token(TokenType.LeftSquareBracket, current.ToString());
                        break;
                    case ']':
                        yield return new Token(TokenType.RightSquareBracket, current.ToString());
                        break;
                    case ':':
                        yield return new Token(TokenType.Colon, value: text);
                        break;
                    case ',':
                        yield return new Token(TokenType.Comma, value: text);
                        break;
                    case '=':
                        if (Peek() is Token(TokenType.Equal))
                        {
                            Consume();
                            yield return new Token(TokenType.AssignmentOperator, value: $"{text}=");
                        }
                        else
                        {
                            yield return new Token(TokenType.Equal, value: text);
                        }
                        break;
                    }
                    default:
                        throw new InvalidOperationException($"Unexpected token: {token}");
                }

            }
        }

        /// <summary>
        /// Tokenizes the input string based on the given grammar.
        /// </summary>
        /// <param name="input">The input string to tokenize.</param>
        /// <returns>A list of tokens.</returns>
        public static List<Token> Tokenize(string input)
        {
            var tokens = new List<Token>();
            var currentPosition = 0;

            while (currentPosition < input.Length)
            {
                char currentChar = input[currentPosition];

                if (char.IsWhiteSpace(currentChar))
                {
                    currentPosition++;
                    continue;
                }

                if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                {
                    var tokenNameBuilder = new StringBuilder();
                    while (currentPosition < input.Length && (char.IsLetterOrDigit(input[currentPosition]) || input[currentPosition] == '_'))
                    {
                        tokenNameBuilder.Append(input[currentPosition]);
                        currentPosition++;
                    }

                    var tokenName = tokenNameBuilder.ToString();

                    // Check if the token is a keyword or identifier
                    switch (tokenName)
                    {
                        case "async":
                        case "await":
                        case "break":
                        case "class":
                        case "continue":
                        case "def":
                        case "del":
                        case "elif":
                        case "else":
                        case "except":
                        case "finally":
                        case "for":
                        case "from":
                        case "global":
                        case "if":
                        case "import":
                        case "in":
                        case "is":
                        case "lambda":
                        case "nonlocal":
                        case "not":
                        case "or":
                        case "pass":
                        case "raise":
                        case "return":
                        case "try":
                        case "while":
                        case "with":
                        case "yield"
        | NEWLINE TYPE_COMMENT &(NEWLINE INDENT)
        | TYPE_COMMENT

To create a .NET 9.0 Solution that includes a Class Library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and providing a pretty printer for the AST, we need to follow these steps:

1. **Initialize a New Solution in Visual Studio.**
2. **Create the Project Structure.**
3. **Implement the Lexer.**
4. **Generate the Abstract Syntax Tree (AST).**
5. **Implement the Pretty Printer for the AST.**
6. **Write Unit Tests using Microsoft's Unit Test Framework.**

Let's break down the implementation steps:

### Step 1: Initialize a new Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new .NET Standard Class Library project named `PythonLexer`.
3. Ensure the target framework is set to `.NET 9.0`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as follows:

1. **Interfaces**
   - `ILexer.cs`
   - `IPrettyPrinter.cs`

2. **Enumerations**
   - `TokenType.cs`

3. **Records**
   - `TokenRecord.cs`
   - `LexemeTuple.cs`

4. **Classes**
   - `AbstractSyntaxTreeNode.cs`
   - `AstPrettyPrinter.cs`
   - `Lexer.cs`
   - `LexerTests.cs`

### Project Structure