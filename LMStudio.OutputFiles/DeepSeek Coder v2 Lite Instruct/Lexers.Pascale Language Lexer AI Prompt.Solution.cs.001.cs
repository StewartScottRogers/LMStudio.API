public class Lexer {
    private readonly string _source;
    private int _position;
    private char _currentChar;

    public Lexer(string source) {
        _source = source;
        _position = 0;
        _currentChar = _source[_position];
    }

    private void Advance() {
        _position++;
        _currentChar = _position < _source.Length ? _source[_position] : '\0';
    }

    private void SkipWhitespace() {
        while (_currentChar != '\0' && char.IsWhiteSpace(_currentChar)) {
            Advance();
        }
    }

    private string Integer() {
        var result = "";
        while (_currentChar != '\0' && char.IsDigit(_currentChar)) {
            result += _currentChar;
            Advance();
        }
        return result;
    }

    public Token GetNextToken() {
        SkipWhitespace();
        if (char.IsLetter(_currentChar)) {
            var lexeme = "";
            while (_currentChar != '\0' && (char.IsLetterOrDigit(_currentChar) || _currentChar == '_')) {
                lexeme += _currentChar;
                Advance();
            }
            return new Token(TokenType.Identifier, lexeme, null);
        }
        // Continue with other token types...
    }
}