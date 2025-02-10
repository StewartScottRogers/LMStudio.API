using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public class TokenType
    {
        public const string Identifier = "Identifier";
        public const string Keyword = "Keyword";
        public const string Operator = "Operator";
        // Add more token types as needed
    }

    public record Token(ReadOnlyCollection<Char> Value, string Type);

    public class Lexer
    {
        private readonly string input;
        private int position;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public IEnumerable<Token> Tokenize()
        {
            while (position < input.Length)
            {
                char currentChar = input[position];

                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }
                else if (currentChar == '+')
                {
                    yield return LexerTokenType.PlusOperator;
                }
                // Add more token types and logic as needed based on the provided grammar

                // If no token type matched, throw an exception or handle it accordingly
                throw new InvalidOperationException("Unknown token");
            }

        }
    }
}