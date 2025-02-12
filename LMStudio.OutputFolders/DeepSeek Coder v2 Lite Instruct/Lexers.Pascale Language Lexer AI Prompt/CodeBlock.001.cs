using System.Collections.Generic;
using System.Text;

namespace Lexer
{
    public class Lexer
    {
        private readonly string _text;
        private int _position;

        public Lexer(string text)
        {
            _text = text;
            _position = 0;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (_position < _text.Length)
            {
                char currentChar = _text[_position];
                if (char.IsLetter(currentChar))
                {
                    tokens.Add(NextTokenForIdentifierOrKeyword());
                }
                else if (char.IsDigit(currentChar))
                {
                    tokens.Add(NextTokenForNumber());
                }
                else if (currentChar == '\'')
                {
                    tokens.Add(NextTokenForStringLiteral());
                }
                // Add handling for other token types...

                _position++;
            }

            return tokens;
        }

        private Token NextTokenForIdentifierOrKeyword()
        {
            var sb = new StringBuilder();
            while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_'))
            {
                sb.Append(_text[_position]);
                _position++;
            }

            string identifierStr = sb.ToString();
            TokenType type;
            if (!TokenTypeMap.TryGetValue(identifierStr, out type))
            {
                type = TokenType.Identifier;
            }

            return new Token(type, identifierStr);
        }

        private Token NextTokenForNumber()
        {
            var sb = new StringBuilder();
            while (_position < _text.Length && char.IsDigit(_text[_position]))
            {
                sb.Append(_text[_position]);
                _position++;
            }

            if (_position < _text.Length && _text[_position] == '.')
            {
                sb.Append('.');
                _position++;
                while (_position < _text.Length && char.IsDigit(_text[_position]))
                {
                    sb.Append(_text[_position]);
                    _position++;
                }
            }

            return new Token(TokenType.Number, sb.ToString());
        }

        private Token NextTokenForStringLiteral()
        {
            var sb = new StringBuilder();
            _position++; // Skip the opening quote
            while (_position < _text.Length && _text[_position] != '\'')
            {
                sb.Append(_text[_position]);
                _position++;
            }
            _position++; // Skip the closing quote

            return new Token(TokenType.StringLiteral, sb.ToString());
        }

        private static readonly Dictionary<string, TokenType> TokenTypeMap = new Dictionary<string, TokenType>
        {
            {"program", TokenType.Program},
            {"const", TokenType.Const},
            // Add other keywords...
        };
    }
}