public enum TokenType { Identifier, Keyword, Operator, Literal }

public interface ILexer
{
    IEnumerable<Token> LexProgram(string programText);
    Token NextToken();
}

public class Token
{
    public TokenType Type { get; set; }
    // Other properties as needed (e.g., Value for literals)
}

// Example of a simple lexer implementation
public class SimpleLexer : ILexer
{
    public IEnumerable<Token> LexProgram(string programText) => 
        Enumerable.Range(0, programText.Length).Select(index => NextToken());

    private Token NextToken()
    {
        // Pseudo code: implement tokenization logic here.
        throw new NotImplementedException();
    }
}