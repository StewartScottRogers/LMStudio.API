// File: Lexer.cs
using System.Collections.Generic;
using System.IO;

namespace PascaleLexer
{
    public class Lexer
    {
        private readonly StreamReader _reader;
        private char _currentChar;

        public Lexer(string input)
        {
            _reader = new StreamReader(new StringReader(input));
            ReadNextChar();
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (_currentChar != '\0')
            {
                if (char.IsWhiteSpace(_currentChar))
                {
                    ReadNextChar();
                    continue;
                }

                switch (_currentChar)
                {
                    case '+':
                        tokens.Add(new Token(TokenType.Plus, "+"));
                        break;
                    case '-':
                        tokens.Add(new Token(TokenType.Minus, "-"));
                        break;
                    case '*':
                        tokens.Add(new Token(TokenType.Multiply, "*"));
                        break;
                    case '/':
                        tokens.Add(new Token(TokenType.Divide, "/"));
                        break;
                    case '=':
                        tokens.Add(new Token(TokenType.Equals, "="));
                        break;
                    case '<':
                        if (PeekNextChar() == '>')
                        {
                            ReadNextChar();
                            tokens.Add(new Token(TokenType.NotEquals, "<>"));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.LessThan, "<"));
                        }
                        break;
                    case '>':
                        if (PeekNextChar() == '=')
                        {
                            ReadNextChar();
                            tokens.Add(new Token(TokenType.GreaterThanOrEqual, ">="));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.GreaterThan, ">"));
                        }
                        break;
                    case ':':
                        if (PeekNextChar() == '=')
                        {
                            ReadNextChar();
                            tokens.Add(new Token(TokenType.Assignment, ":="));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.Colon, ":"));
                        }
                        break;
                    case ',':
                        tokens.Add(new Token(TokenType.Comma, ","));
                        break;
                    case ';':
                        tokens.Add(new Token(TokenType.Semicolon, ";"));
                        break;
                    case '.':
                        if (PeekNextChar() == '.')
                        {
                            ReadNextChar();
                            tokens.Add(new Token(TokenType.In, ".."));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.Period, "."));
                        }
                        break;
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParentheses, "("));
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParentheses, ")"));
                        break;
                    case '[':
                        tokens.Add(new Token(TokenType.LeftBracket, "["));
                        break;
                    case ']':
                        tokens.Add(new Token(TokenType.RightBracket, "]"));
                        break;
                    case '{':
                        tokens.Add(new Token(TokenType.LeftCurlyBrace, "{"));
                        break;
                    case '}':
                        tokens.Add(new Token(TokenType.RightCurlyBrace, "}"));
                        break;
                    default:
                        if (char.IsLetter(_currentChar))
                        {
                            tokens.Add(ReadIdentifier());
                        }
                        else if (char.IsDigit(_currentChar))
                        {
                            tokens.Add(ReadNumber());
                        }
                        else
                        {
                            throw new Exception($"Unexpected character: {_currentChar}");
                        }
                        break;
                }

                ReadNextChar();
            }

            return tokens;
        }

        private Token ReadIdentifier()
        {
            var start = _reader.CurrentPosition;

            while (char.IsLetterOrDigit(_currentChar))
            {
                ReadNextChar();
            }

            var identifierText = _reader.ReadLine(start, _reader.CurrentPosition);

            var tokenType = GetTokenTypeForKeyword(identifierText);
            return new Token(tokenType == TokenType.Identifier ? TokenType.Identifier : tokenType, identifierText);
        }

        private Token ReadNumber()
        {
            var start = _reader.CurrentPosition;

            while (char.IsDigit(_currentChar))
            {
                ReadNextChar();
            }

            if (_currentChar == '.')
            {
                ReadNextChar();

                while (char.IsDigit(_currentChar))
                {
                    ReadNextChar();
                }
            }

            var numberText = _reader.ReadLine(start, _reader.CurrentPosition);
            return new Token(TokenType.Number, numberText);
        }

        private void ReadNextChar()
        {
            int charCode = _reader.Read();
            if (charCode == -1)
            {
                _currentChar = '\0';
            }
            else
            {
                _currentChar = (char)charCode;
            }
        }

        private char PeekNextChar()
        {
            return _currentChar;
        }

        private TokenType GetTokenTypeForKeyword(string keyword)
        {
            switch(keyword)
            {
                case "program": return TokenType.Program;
                // Add more keywords here...
                default: return TokenType.Identifier;
            }
        }
    }
}