using System;
using System.Collections.Generic;

public record Token(Type Type, string Value);

[AttributeUsage(AttributeUsage.None)]
public enum TokenType : int
{
    None = 0,
    Identifier = 1,
    Literal = 2,
    Equal = 3,
    Add = 4,
    Subtract = 5,
    Multiply = 6,
    Divide = 7,
    OpenParen = 8,
    CloseParen = 9,
    OpenCurly = 10,
    CloseCurly = 11,
    OpenSquare = 12,
    CloseSquare = 13,
    If = 14,
    Then = 15,
    End = 16,
    While = 17,
    Do = 18,
    Print = 19,
    StringLiteral = 20,
    Increment = 21,
    Decrement = 22,
    Pow = 23,
    Elipsis = 24,
    Comment = 25
}

public class Lexer
{
    private readonly string input;
    private int currentPos;

    public Lexer(string input)
    {
        this.input = input ?? "";
        currentPos = 0;
    }

    public Token GetNextToken()
    {
        if (currentPos >= input.Length)
            throw new InvalidOperationException("Unexpected end of input");

        var tokenType = TryReadNumber(out var num) ? typeof(NumberToken) :
                     TryReadStringLiteral(out var str) ?? 
                     TryReadSingleChar(out var ch, 28, "({[", ")]}", "+-*/=", "ifthenweprint") ? (typeof(ParenToken), ch) : null;

        if (tokenType == typeof(StringToken))
            return new Token(tokenType, str);
        if (tokenType == typeof(NumberToken))
            return new Token(tokenType, num);
        if (tokenType is not null)
            return new Token(tokenType, ch ?? "");

        throw new InvalidOperationException("Unexpected character: " + input[currentPos]);
    }

    private bool TryReadNumber(out string number)
    {
        StringBuilder sb = new();
        while (currentPos < input.Length && char.IsDigit(input[currentPos]))
        {
            sb.Append(input[currentPos]);
            currentPos++;
        }
        return number ??= sb.ToString();
    }

    private bool TryReadStringLiteral(out string str)
    {
        if (currentPos + 2 >= input.Length) return false;

        if (input[currentPos] == '\'' && 
            (currentPos + 1 < input.Length && input[currentPos + 1] == '\\') &&
            currentPos + 2 < input.Length)
        {
            str = input.Substring(currentPos + 1, 2);
            currentPos += 3;
            return true;
        }

        return false;
    }

    private bool TryReadSingleChar(out char ch, params int[] expectedTokenTypes, 
                                  params string[] twoChars, params string[] threeChars)
    {
        if (currentPos >= input.Length) return false;

        switch (input[currentPos])
        {
            case '{': 
                currentPos++;
                return true;
            case '}':
                currentPos++;
                return true;
            case '[': currentPos++; return true;
            case ']': currentPos++; return true;
            case '(':
            case ')':
                currentPos++;
                ch = input[currentPos];
                if (ch == '(' || ch == ')')
                    return true;
                break;
        }

        foreach (char c in expectedTokenTypes.Select(t => input[currentPos] == t))
        {
            switch (input[currentPos])
            {
                case '+':
                    currentPos++;
                    return true;
                case '-':
                    currentPos++;
                    return true;
                case '*':
                    currentPos++;
                    return true;
                case '/':
                    currentPos++;
                    return true;
                case '=':
                    currentPos++;
                    return true;
                default: break;
            }
        }

        foreach (var twoChar in twoChars)
        {
            if (input.Substring(currentPos, 2) == twoChar)
            {
                currentPos += 2;
                switch (twoChar)
                {
                    case "++":
                        ch = '+';
                        return true;
                    case "--":
                        ch = '-';
                        return true;
                    case "**":
                        ch = '*';
                        return true;
                    case "//":
                        currentPos++;
                        return true;
                }
            }
        }

        foreach (var threeChar in threeChars)
        {
            if (input.Substring(currentPos, 3) == threeChar)
            {
                currentPos += 3;
                switch (threeChar)
                {
                    case "...":
                        ch = '.';
                        return true;
                }
            }
        }

        ch = input[currentPos];
        currentPos++;
        return false;
    }
}