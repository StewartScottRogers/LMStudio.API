using System;
using System.Collections.Generic;

namespace PascalLexerClassLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;

        public Lexer(string input)
        {
            this.input = input;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();
            while (position < input.Length)
            {
                var charCurrent = input[position];
                if (char.IsWhiteSpace(charCurrent))
                {
                    position++;
                    continue;
                }
                else if (char.IsLetter(charCurrent) || char == '_')
                {
                    tokens.Add(TokenizeIdentifier());
                }
                else if (char.IsDigit(charCurrent))
                {
                    tokens.Add(TokenizeNumber());
                }
                else if (charCurrent == '\'')
                {
                    tokens.Add(TokenizeStringLiteral());
                }
                else
                {
                    tokens.Add(CreateToken(TokenType.Operator, charCurrent.ToString()));
                    position++;
                }
            }
            tokens.Add(new Token(TokenType.Eof, ""));
            return tokens;
        }

        private Token TokenizeIdentifier()
        {
            int start = position;
            while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
            {
                position++;
            }
            var value = input.Substring(start, position - start);
            return new Token(TokenType.Identifier, value);
        }

        private Token TokenizeNumber()
        {
            int start = position;
            while (position < input.Length && char.IsDigit(input[position]))
            {
                position++;
            }
            if (position < input.Length && input[position] == '.')
            {
                position++;
                while (position < input.Length && char.IsDigit(input[position]))
                {
                    position++;
                }
            }
            var value = input.Substring(start, position - start);
            return new Token(TokenType.Number, value);
        }

        private Token TokenizeStringLiteral()
        {
            int start = position;
            position++; // Skip the opening '
            while (position < input.Length && input[position] != '\'')
            {
                if (input[position] == '\\') position++;
                position++;
            }
            var value = input.Substring(start, position - start + 1);
            return new Token(TokenType.StringLiteral, value);
        }

        private Token CreateToken(TokenType type, string value)
        {
            return new Token(type, value);
        }
    }
}