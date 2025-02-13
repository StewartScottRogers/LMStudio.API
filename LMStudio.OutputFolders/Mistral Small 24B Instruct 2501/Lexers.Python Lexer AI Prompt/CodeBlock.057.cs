using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public Token GetNextToken()
        {
            while (position < input.Length && char.IsWhiteSpace(input[position]))
                position++;

            if (position >= input.Length)
                return new EndOfInputToken();

            var currentChar = input[position];

            if (char.IsLetter(currentChar) || currentChar == '_')
                return ParseIdentifierOrKeyword();
            else if (char.IsDigit(currentChar))
                return ParseNumber();
            if (currentChar == '.') {
                return ParseDot();
            }
            // Add more cases for other tokens as needed

            return new Token(TokenType.Unknown, source[index..(index+1)]);

        }

    public void PrintTokens()
    {
        foreach (var token in tokens)
        {
            Console.WriteLine($"Token: {token.Type}, Value: {token.Value}");
        }
    }
}

# Lexer