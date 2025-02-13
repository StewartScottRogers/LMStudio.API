using System;
using System.Collections.Generic;

public class Tokenizer
{
    private readonly string input;
    private int position = 0;
    private readonly List<Token> tokens = new();

    public Tokenizer(string input)
    {
        this.input = input;
    }

    public IEnumerable<Token> Tokenize()
    {
        while (Peek() != null)
        {
            Token token = ReadNextToken();
            if (token.TokenType != TokenType.Whitespace)
            {
                tokens.Add(token);
            }
        }

        return new LexerTokenListTuple(tokens);
    }

# Project Structure