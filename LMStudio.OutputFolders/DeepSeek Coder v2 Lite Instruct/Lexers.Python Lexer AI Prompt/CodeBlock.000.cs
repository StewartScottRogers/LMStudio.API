namespace LexerLibrary
{
    public class Token
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Lexer
    {
        private readonly string _input;
        private int _pos = 0;
        private char _currentChar;

        public Lexer(string input)
        {
            _input = input;
            if (_input.Length > 0)
                _currentChar = _input[0];
        }

        private void Advance()
        {
            _pos++;
            if (_pos < _input.Length)
                _currentChar = _input[_pos];
            else
                _currentChar = null;
        }

        private void SkipWhitespace()
        {
            while (_currentChar != null && char.IsWhiteSpace(_currentChar))
            {
                Advance();
            }
        }

        private string Integer()
        {
            var result = "";
            while (_currentChar != null && char.IsDigit(_currentChar))
            {
                result += _currentChar;
                Advance();
            }
            return result;
        }

        public Token GetNextToken()
        {
            while (_currentChar != null)
            {
                if (char.IsWhiteSpace(_currentChar))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsDigit(_currentChar))
                {
                    return new Token { Type = "NUMBER", Value = Integer() };
                }

                // Handle other token types similarly...

                Advance();
            }
            return new Token { Type = "EOF", Value = null };
        }
    }
}