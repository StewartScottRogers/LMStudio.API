using System;
using System.Collections.Generic;
using System.Text;

public class Tokenizer
{
    private readonly string source;
    private int position;
    
    public List<Token> Tokens { get; set; }

    public Tokenizer(string source)
    {
        this.source = source.Trim();
        position = 0;
        Tokens = new List<Token>();
    }

    public bool HasMoreTokens()
    {
        return position < source.Length;
    }

    public Token NextToken()
    {
        if (HasMoreTokens())
        {
            char currentChar = source[position];
            switch (currentChar)
            {
                case '(':
                    Tokens.Add(new Token { Type = TokenType.Parenthesis, Value = "(" });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case ')':
                    Tokens.Add(new Token { Type = TokenType.RightParen, Value = ")" });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case '{':
                    Tokens.Add(new Token { Type = TokenType.OpenCurly, Value = "{" });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case '}':
                    Tokens.Add(new Token { Type = TokenType.CloseCurly, Value = "}" });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case '[':
                    Tokens.Add(new Token { Type = TokenType.OpenSquare, Value = "[" });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case ']':
                    Tokens.Add(new Token { Type = TokenType.CloseSquare, Value = "]" });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case ',':
                    Tokens.Add(new Token { Type = TokenType.Comma, Value = "," });
                    position++;
                    return Tokens[Tokens.Count - 1];
                case '+':
                    AddToken(TokenType.AddOp, "+");
                    return Tokens[Tokens.Count - 1];
                case '-':
                    AddToken(TokenType.SubOp, "-");
                    return Tokens[Tokens.Count - 1];
                case '*':
                    AddToken(TokenType.MultiOp, "*");
                    return Tokens[Tokens.Count - 1];
                case '/':
                    AddToken(TokenType.DivOp, "/");
                    return Tokens[Tokens.Count - 1];
                case '%':
                    AddToken(TokenType.ModOp, "%");
                    return Tokens[Tokens.Count - 1];
                case '&':
                    AddToken(TokenType.AndOp, "&");
                    return Tokens[Tokens.Count - 1];
                case '|':
                    AddToken(TokenType.OrOp, "|");
                    return Tokens[Tokens.Count - 1];
                case '^':
                    AddToken(TokenType.XorOp, "^");
                    return Tokens[Tokens.Count - 1];
                case '=':
                    if (NextIsAssign())
                    {
                        AddToken(TokenType.AssignOp, "=");
                    }
                    else
                    {
                        AddToken(TokenType.EqOp, "=");
                    }
                    return Tokens[Tokens.Count - 1];
                case ':':
                    AddToken(TokenType.Colon, ":");
                    return Tokens[Tokens.Count - 1];
                case ';':
                    AddToken(TokenType.Semicolon, ";");
                    return Tokens[Tokens.Count - 1];
                case '#':
                    // Ignore comments
                    GetComment();
                    return Tokens[Tokens.Count - 1];
                case ' ':
                    // Ignore whitespace
                    GetWhitespace();
                    return Tokens[Tokens.Count - 1];
            }
        }
        throw new PythonLexerException("Unexpected end of input");
    }

    private void AddToken(TokenType type, string value)
    {
        Token token = new Token { Type = type, Value = value };
        Tokens.Add(token);
    }

    private bool NextIsAssign()
    {
        if (HasMoreTokens() && source[position + 1] == '=')
            return true;
        return false;
    }

    private void GetComment()
    {
        while (HasMoreTokens() && source[position] != '\n')
            position++;
        position++; // Move past the newline
    }

    private void GetWhitespace()
    {
        while (HasMoreTokens() && Char.IsWhiteSpace(source[position]))
            position++;
    }
}