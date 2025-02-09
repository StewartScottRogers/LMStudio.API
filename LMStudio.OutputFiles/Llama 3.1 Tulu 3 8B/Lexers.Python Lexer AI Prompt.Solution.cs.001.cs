public class Lexer {
      private TextReader _input;
      
      // Constructor to initialize _input with your Python source code
      public Lexer(TextReader input) => _input = input;

      public IEnumerable<Token> Lex() {
          while (!_input.EndOfStream) {
              char c = (char)_input.Read();
              switch (c) {
                  case ' ':
                  case '\t':
                      // Skip whitespace
                      break;
                  case '\n':
                      yield return new Token { Type = TokenType.NewLine, Value = "\n", LineNumber = ... };
                      break;
                  // Add cases for handling other tokens such as identifiers, literals, keywords...
                  default:
                      // Determine token type and value based on c
                      var tokenValue = c.ToString();
                      // Check if current char can form a keyword/identifier/operator etc.
                      yield return new Token { Type = DetermineTokenType(tokenValue), Value = tokenValue, LineNumber = ... };
                      break;
              }
          }
      }

      private TokenType DetermineTokenType(string value) {
          // Implement logic to determine TokenType based on `value`
      }
  }