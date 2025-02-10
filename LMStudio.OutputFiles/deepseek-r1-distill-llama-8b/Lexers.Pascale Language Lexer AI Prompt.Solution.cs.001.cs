using System;
using System.Collections.Generic;
using System.Text;

public class Tokenizer : IDisposable
{
    private readonly string input;
    private int currentlyReadingNumber;
    private int currentlyReadingString;
    private int lineNumber;
    
    public Tokenizer(string input)
    {
        this.input = input;
        this.currentlyReadingNumber = 0;
        this.currentlyReadingString = 0;
        this.lineNumber = 1;
    }

    public List<Token<T>> Tokens<T> 
    {
        get; private set; 
    }

    public void Start()
    {
        ClearTokens();
        ParseInput();
    }

    private void ClearTokens() => Tokens = new List<Token<T>>();

    private void ParseInput()
    {
        for (int i = 0; i < input.Length; i++)
        {
            var c = input[i];
            switch (c)
            {
                case '<':
                    AddToken(Tokens<T>.Add(new Token<Identifier>(new Identifier("Identifier"), i)));
                    break;
                // ... other token cases
            }
        }
    }

    public void Dispose()
    {
        Tokens.Clear();
    }
}