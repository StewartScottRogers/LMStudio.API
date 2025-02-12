using LexerProject.Tokens;
using System.Collections.Generic;

namespace LexerProject.Parsing
{
    public class Lexer
    {
        private readonly string _input;
        private int _position;
        private char _currentChar;

        public Lexer(string input)
        {
            _input = input;
            _position = 0;
            _currentChar = _input[_position];
        }

        private void Advance()
        {
            _position++;
            _currentChar = _position < _input.Length ? _input[_position] : '\0';
        }

        private char Peek()
        {
            int peekPosition = _position + 1;
            return peekPosition < _input.Length ? _input[peekPosition] : '\0';
        }

        public Token GetNextToken()
        {
            while (_currentChar != '\0')
            {
                if (char.IsWhiteSpace(_currentChar))
                {
                    Advance();
                    continue;
                }

                // Handle identifiers and numbers
                if (char.IsLetter(_currentChar))
                {
                    var identifier = "";
                    while (_currentChar != '\0' && (char.IsLetterOrDigit(_currentChar)))
                    {
                        identifier += _currentChar;
                        Advance();
                    }

                    return new Token(TokenType.Identifier, identifier);
                }

                if (char.IsDigit(_currentChar))
                {
                    var number = "";
                    while (_currentChar != '\0' && char.IsDigit(_currentChar))
                    {
                        number += _currentChar;
                        Advance();
                    }

                    return new Token(TokenType.Number, number);
                }

                // Handle individual characters
                switch (_currentChar)
                {
                    case ':':
                        if (Peek() == '=')
                        {
                            Advance();
                            Advance();
                            return new Token(TokenType.Assignment, ":=");
                        }
                        break;
                    case ';':
                        Advance();
                        return new Token(TokenType.SemiColon, ";");
                    // Handle other cases similarly
                }

                Advance();
            }

            return new Token(TokenType.EOF, null);
        }
    }
}