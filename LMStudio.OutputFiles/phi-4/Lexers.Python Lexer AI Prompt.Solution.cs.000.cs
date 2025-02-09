using System;
using System.Collections.Generic;

public class Lexer
{
    public List<Token> Tokenize(string input)
    {
        // Implement tokenization logic based on the provided grammar.
        // This involves scanning the input string and producing a list of tokens.
        throw new NotImplementedException();
    }
}

public class Token
{
    public string Type { get; set; }
    public string Value { get; set; }

    public Token(string type, string value)
    {
        Type = type;
        Value = value;
    }
}