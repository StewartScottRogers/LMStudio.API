using System;
using System.Collections.Generic;

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

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (position < input.Length)
            {
                char currentChar = input[position];

                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }

                // Handle various token types
                else if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    tokens.Add(new Token(TokenType.Name, ReadIdentifier()));
                }
                else if (char.IsDigit(currentChar))
                {
                    tokens.Add(new Token(TokenType.Number, ReadNumber()));
                }
                // Handle other token types as needed
                else
                {
                    tokens.Add(new Token(TokenType.Unknown, char.ToString()));
                }

# Solution Structure