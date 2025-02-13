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

        public var TokenStreamTuple GenerateTokenStream()
        {
            var tokenList = new List<Token>();

            while (position < input.Length)
            {
                char currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                }
                else if (char.IsLetter(currentChar))
                {
                    tokenList.Add(GenerateId());
                }
                else if (char.IsDigit(currentChar))
                {
                    tokenList.Add(GenerateNumber());
                }
                else
                {
                    tokenList.Add(GenerateSpecialToken());
                }
            }

            return new var { Tokens = tokenList };
        }

        private Token GenerateId()
        {
            int startPos = position;
            while (position < input.Length && (char.IsLetterOrDigit(input[position])))
            {
                position++;
            }

            string idValue = input.Substring(startPos, position - startPos);
            return new Token(TokenType.Identifier, idValue);
        }

        private Token GenerateNumber()
        {
            int startPos = position;
            while (position < input.Length && char.IsDigit(input[position]))
            {
                position++;
            }

            string numberValue = input.Substring(startPos, position - startPos);
            return new Token(TokenType.Number, numberValue);
        }

        private Token GenerateSpecialToken()
        {
            int startPos = position;
            switch (input[position])
            {
                case '+':
                    position++;
                    return new Token(TokenType.Plus, "+");
                case '-':
                    position++;
                    return new Token(TokenType.Minus, "-");
                case '*':
                    position++;
                    return new Token(TokenType.Multiply, "*");
                case '/':
                    position++;
                    return new Token(TokenType.Divide, "/");
                case '(':
                    position++;
                    return new Token(TokenType.LParen, "(");
                case ')':
                    position++;
                    return new Token(TokenType.RParen, ")");
                case ':':
                case '=':
                    if (input[position] == ':' && input[position + 1] == '=')
                    {
                        position += 2;
                        return new Token(TokenType.Assign, ":=");
                    }
                    break;
                case ';':
                    position++;
                    return new Token(TokenType.Semicolon, ";");
            }

            throw new InvalidOperationException("Unknown character: " + input[position]);
        }
    }
}