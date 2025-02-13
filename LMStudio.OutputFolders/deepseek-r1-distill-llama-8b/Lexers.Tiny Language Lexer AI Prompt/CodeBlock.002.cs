using System;
using System.Collections.Generic;
using System.Text;

public class Tokenizer : IDisposable
{
    private string input;
    private int pos;

    public Tokenizer(string text, int start = 0)
    {
        input = text;
        pos = start;
    }

    public List<Token> Tokens => _tokens;

    private List<Token> _tokens = new List<Token>();

    public void Clear()
    {
        _tokens.Clear();
    }

    public Token GetNextToken()
    {
        if (pos >= input.Length) return null;

        var token = TryReadNumber(out var number) ? number :
                 TryReadStringLiteral() ?? 
                 TryReadSingleChar(out var ch, Enum.GetValues(typeof(TokenType)).Cast<TokenType>().ToList(),
                                  "(", ")", "+", "-", "*", "/", "=",
                                  "if", "then", "end", "while", "do",
                                  "print") ? (Token)ch : null;

        if (!string.IsNullOrEmpty(token?.Value))
            _tokens.Add(token);

        return token;
    }

    private Token? TryReadNumber(out string number)
    {
        if (pos >= input.Length) return null;
        
        StringBuilder sb = new();
        bool isNumber = true;

        while (pos < input.Length && char.IsDigit(input[pos]))
        {
            sb.Append(input[pos]);
            pos++;
        }

        number = sb.ToString();
        return new Token(typeof(NumberToken), number);
    }

    private Token? TryReadStringLiteral()
    {
        if (pos >= input.Length - 3) return null;
        
        if (input[pos] == '\'' && input[pos + 1] == '\\' && pos + 2 < input.Length)
            return new Token(typeof(StringToken), input.Substring(pos + 1, 2));
        
        return null;
    }

    private Token? TryReadSingleChar(out char ch, params char[] delimiters,
                                      params string[] twoChars, ... string threeChars)
    {
        if (pos >= input.Length) return null;

        switch (input[pos])
        {
            case '{':
                return new Token(typeof(OpenCurlyToken), "{");
            case '}':
                return new Token(typeof(CloseCurlyToken), "}");
            case '[':
                return new Token(typeof(OpenSquareToken), "[");
            case ']':
                return new Token(typeof(CloseSquareToken), "]");
            case '(':
                return new Token(typeof(OpenParenToken), "(");
            case ')':
                return new Token(typeof(CloseParenToken), ")");
        }

        foreach (char c in delimiters)
        {
            if (input[pos] == c)
            {
                switch (c)
                {
                    case '(': return new Token(typeof(ParenToken), "("); break;
                    case ')': return new Token(typeof(ParenToken), ")"); break;
                    default: break;
                }
            }
        }

        if (twoChars?.Length >= 2 && input.Substring(pos, 2) == twoChars[0])
        {
            switch (twoChars[0])
            {
                case "++": return new Token(typeof(IncrementToken), "++");
                case "--": return new Token(typeof(DecrementToken), "--");
                case "**": return new Token(typeof(PowToken), "**");
                case "//": return new Token(typeof CommentToken, input.Substring(pos, 2));
            }
        }

        if (threeChars?.Length >= 3 && input.Substring(pos, 3) == threeChars[0])
        {
            switch (threeChars[0])
            {
                case "...": return new Token(typeof(ElipsisToken), "...");
            }
        }

        ch = input[pos];
        pos++;
        return null;
    }

    public void Dispose()
    {
        Clear();
    }
}