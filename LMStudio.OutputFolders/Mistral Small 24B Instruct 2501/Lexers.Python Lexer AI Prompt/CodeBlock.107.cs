using System;
using System.Collections.Generic;
using System.IO;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly TextReader inputStream;
        private char currentChar;
        private int lineNumber = 1;
        private int columnNumber = 0;
        private List<Token> tokens = new List<Token>();

        public Lexer()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            // Initialization code if needed
        }

        public TokenListTuple GetTokens(string input)
        {
            var tokenList = new List<IToken>();
            var positionTracker = 0;
            while (positionTracker < input.Length)
            {
                var tokenInfo = Tokenize(input, ref positionTracker);
                tokenList.Add(tokenInfo.Item1);
            }
            return tokenList.ToArray();
        }

    private Tuple<(IToken Token, int Position)> Tokenize(string sourceCode, ref int currentPosition)
    {
        if (currentPosition >= sourceCode.Length)
            throw new IndexOutOfRangeException("End of the source code reached unexpectedly.");

        char currentChar = sourceCode[currentPosition];

        // Skip whitespace
        while (char.IsWhiteSpace(currentChar))
        {
            currentPosition++;
            if (currentPosition < sourceCode.Length)
                currentChar = sourceCode[currentPosition];
            else
                break;
        }

        // Handle different types of tokens
        switch (currentChar)
        {
            case '(':
                return new Token(TokenType.LeftParenthesis, "(");
            case ')':
                return new Token(TokenType.RightParenthesis, ")");
            case '{':
                return new Token(TokenType.LeftBrace, "{");
            case '}':
                return new Token(TokenType.RightBrace, "}");
            case '[':
                return new Token(TokenType.LeftBracket, "[");
            case ']':
                return new Token(TokenType.RightBracket, "]");
            case '(':
                return new Token(TokenType.LeftParen, "(");
            case ')':
                return new Token(TokenType.RightParen, ")");

To create a Class Library that lexes the given grammar into an Abstract Syntax Tree (AST) and generates a Pretty Printer for the AST, we need to follow these steps:

1. **Initialize a New Solution in Visual Studio**:
   - Create a new .NET 9.0 solution.
   - Add a new class library project.
   - Ensure the project is compatible with Visual Studio 2022.

2. **Define the Project Structure**:
   - Each class, interface, enumeration, and record will be in its own file.

3. **Create the Lexer**:
    - The lexer will tokenize the input based on the given grammar.
    - Tokens will include keywords, identifiers, literals, operators, and punctuation.