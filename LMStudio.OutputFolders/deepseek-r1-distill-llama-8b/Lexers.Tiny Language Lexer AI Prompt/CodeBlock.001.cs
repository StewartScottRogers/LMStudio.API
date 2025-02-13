using System.Text;

public class Lexer
{
    private readonly string input;
    private int currentPos;

    public Lexer(string input)
    {
        this.input = input;
        currentPos = 0;
    }

    public Tokenizer GetTokens()
    {
        return new Tokenizer(input, currentPos);
    }

    public void ReadToken()
    {
        if (currentPos >= input.Length) throw new Exception("Unexpected end of input");
    }
}