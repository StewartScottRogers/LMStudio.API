using System;
using System.IO;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;
        private char currentChar;

        public Lexer(string input)
        {
            this.input = input;
            ReadNextChar();
        }

        private void ReadNextChar()
        {
            if (position < input.Length)
            {
                currentChar = input[position++];
            }
            else
            {
                currentChar = '\0';
            }
        }

        public Token GetNextToken()
        {
            while (char.IsWhiteSpace(currentChar))
            {
                ReadNextChar();
            }

            if (char.IsLetter(currentChar))
            {
                return new Token(TokenType.Id, ReadIdentifier());
            }

            if (char.IsDigit(currentChar))
            {
                return new Token(TokenType.Number, ReadNumber());
            }

            switch (currentChar)
            {
                case '+': return NextToken(TokenType.Plus);
                case '-': return NextToken(TokenType.Minus);
                case '*': return NextToken(TokenType.Multiply);
                case '/': return NextToken(TokenType.Divide);
                case ':':
                    ReadNextChar();
                    if (currentChar == '=')
                    {
                        return new Token(TokenType.Assign, ":=");
                    }
                    break;
                case '(': return NextToken(TokenType.LParen);
                case ')': return NextToken(TokenType.RParen);
                case ';': return NextToken(TokenType.Semicolon);
            }

            if (currentChar == '\0')
            {
                return new Token(TokenType.EOF, "");
            }

            throw new Exception("Unknown character");
        }

        private string ReadIdentifier()
        {
            var startPosition = position - 1;
            while (char.IsLetterOrDigit(currentChar))
            {
                ReadNextChar();
            }
            return input.Substring(startPosition, position - startPosition);
        }

        private string ReadNumber()
        {
            var startPosition = position - 1;
            while (char.IsDigit(currentChar))
            {
                ReadNextChar();
            }
            return input.Substring(startPosition, position - startPosition);
        }

        private Token NextToken(TokenType tokenType)
        {
            var value = currentChar.ToString();
            ReadNextChar();
            return new Token(tokenType, value);
        }
    }

    public record Token( TokenType Type, string Value );
}