using System.Collections.Generic;

namespace TinyLanguageLexer
{
    public class Lexer
    {
        private readonly string _sourceCode;
        private int _position;

        public Lexer(string sourceCode)
        {
            _sourceCode = sourceCode;
            _position = 0;
        }

        public IEnumerable<Token> Lex()
        {
            while (_position < _sourceCode.Length)
            {
                char currentChar = Peek();

                if (char.IsWhiteSpace(currentChar))
                {
                    Consume();
                }
                else if (char.IsLetter(currentChar))
                {
                    yield return TokenizeIdentifier();
                }
                else if (char.IsDigit(currentChar))
                {
                    yield return TokenizeNumber();
                }
                else
                {
                    yield return TokenizeSymbol();
                }
            }

            yield return new Token("EOF", "<EOF>");
        }

        private char Peek() => _sourceCode[_position];

        private void Consume()
        {
            _position++;
        }

        private Token TokenizeIdentifier()
        {
            int start = _position;
            while (char.IsLetterOrDigit(Peek()))
            {
                Consume();
            }
            string value = _sourceCode.Substring(start, _position - start);
            return new Token("IDENTIFIER", value);
        }

        private Token TokenizeNumber()
        {
            int start = _position;
            while (char.IsDigit(Peek()))
            {
                Consume();
            }
            string value = _sourceCode.Substring(start, _position - start);
            return new Token("NUMBER", value);
        }

        private Token TokenizeSymbol()
        {
            char symbol = Peek();
            Consume();
            return new Token($"SYMBOL_{symbol}", symbol.ToString());
        }
    }
}