public interface ITokenizer
    {
        IEnumerable<Token> Tokenize(string sourceCode);
    }
    
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        
        public override string ToString() => $"{Type}:{Value}";
    }
    
    public enum TokenType 
    {
        // Define all token types such as Name, Number, String, Newline, etc., based on the provided grammar.
    }

    public class Lexer : ITokenizer
    {
        private readonly string _sourceCode;

        public Lexer(string sourceCode) => _sourceCode = sourceCode;
        
        public IEnumerable<Token> Tokenize()
        {
            // Implementation using a state machine or similar approach to iterate over source code and yield tokens.
            foreach (var token in GenerateTokens(_sourceCode))
                yield return token;
        }

        private IEnumerable<Token> GenerateTokens(string source)
        {
            int position = 0;

            while (position < source.Length)
            {
                var currentChar = source[position];
                
                // Handle each possible grammar rule here
                switch (currentChar)
                {
                    case 'a' when IsStartOfKeyword(source, ref position, "class"):
                        yield return new Token(TokenType.ClassKeyword, "class");
                        break;
                    case 'd':
                        if (IsStartOfKeyword(source, ref position, "def"))
                            yield return new Token(TokenType.FunctionDefinition, "def");
                        // More cases...
                        break;
                    // Implement all other grammar rules here
                    default:
                        // Handle identifiers, numbers, strings, whitespace, etc.
                        if (Char.IsLetter(currentChar))
                            while (Char.IsLetterOrDigit(source[position]) || source[position] == '_')
                                position++;
                            yield return new Token(TokenType.Name, source.Substring(position - currentChar.Length + 1));
                        else
                            // Yield tokens for other characters like whitespace, punctuation, etc.
                            yield return new Token(GetTokenTypeForCharacter(currentChar), currentChar.ToString());
                        break;
                }
            }
        }

        private bool IsStartOfKeyword(string source, ref int position, string keyword)
        {
            if (source.Substring(position, keyword.Length) == keyword)
            {
                position += keyword.Length;
                return true;
            }
            return false;
        }

        private TokenType GetTokenTypeForCharacter(char ch)
        {
            // Map characters to their respective token types based on grammar.
            switch (ch)
            {
                case '(':
                    return TokenType.LeftParenthesis;
                case ')':
                    return TokenType.RightParenthesis;
                case '{':
                    return TokenType.OpenBrace;
                case '}':
                    return TokenType.CloseBrace;
                // More cases...
                default:
                    return TokenType.Unknown;  // Or handle special cases here.
            }
        }
    }