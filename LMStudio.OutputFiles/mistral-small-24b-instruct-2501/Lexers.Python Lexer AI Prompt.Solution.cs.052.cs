using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public sealed class Token
    {
        public readonly string Value;
        public readonly TokenType Type;

        public Token(string value, TokenType type)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Type = type;
        }
    }

    public enum TokenType
    {
        Identifier,
        Keyword,
        Literal,
        Operator,
        Punctuation,
        Newline,
        Endmarker,
        // Add other token types as needed based on the grammar
    }

    public class Lexer
    {
        private readonly string Input;
        private int Position;

        public Lexer(string input)
        {
            this.Input = input;
            this.Position = 0;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (this.Position < this.Input.Length)
            {
                char currentChar = this.Input[this.Position];

                if (char.IsWhiteSpace(currentChar))
                {
                    this.Position++;
                    continue;
                }

                if (char.IsDigit(currentChar) || currentChar == '.')
                {
                    string numberLiteral = this.ParseNumber();
                    yield return new NumberToken(numberLiteral);
                }
                else if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    string identifier = this.ParseIdentifier();
                    yield return new IdentifierToken(identifier);
                }
                else
                {
                    switch (currentChar)
                    {
                        case '+':
                            yield return new PlusToken();
                            break;
                        // Add cases for other tokens as needed
                    }
                }
            }
        }

        private static IEnumerable<Tokens> Tokenize(string input)
        {
            var tokens = new List<Tokens>();

            foreach (var token in TokenStream(input))
            {
                tokens.Add(token);
            }

            return tokens;
        }

        public static void Main()
        {

        }
    }
}