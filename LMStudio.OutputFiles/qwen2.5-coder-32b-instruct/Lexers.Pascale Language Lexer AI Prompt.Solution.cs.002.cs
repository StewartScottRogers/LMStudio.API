using System;
using System.Collections.Generic;
using System.IO;

public class Lexer {
    private readonly string sourceCode;
    private readonly int length;
    private int position = 0;
    private int currentLine = 1, currentColumn = 1;
    
    public Lexer(string sourceCode) {
        this.sourceCode = sourceCode;
        this.length = sourceCode.Length;
    }

    public Token NextToken() {
        if (position >= length)
            return new Token(TokenType.EOF, string.Empty, currentLine, currentColumn);

        SkipWhitespace();

        char currentChar = CurrentChar;

        if (char.IsLetter(currentChar))
            return LexIdentifierOrKeyword();
        
        if (char.IsDigit(currentChar))
            return LexNumber();

        if (currentChar == '\'')
            return LexStringLiteral();

        if (IsOperator(currentChar))
            return LexOperator();

        if (IsDelimiter(currentChar))
            return LexDelimiter();

        throw new Exception($"Unknown character {currentChar} at line {currentLine}, column {currentColumn}");
    }

    private void SkipWhitespace() {
        while (position < length && char.IsWhiteSpace(CurrentChar)) {
            if (CurrentChar == '\n') {
                currentLine++;
                currentColumn = 1;
            } else {
                currentColumn++;
            }
            position++;
        }
    }

    private Token LexIdentifierOrKeyword() {
        int start = position;
        while (position < length && (char.IsLetterOrDigit(CurrentChar) || CurrentChar == '_'))
            position++;

        string identifier = sourceCode.Substring(start, position - start);
        currentColumn += position - start;

        if (TryGetKeyword(identifier, out var keyword))
            return new Token(TokenType.Keyword, identifier, currentLine, currentColumn);

        return new Token(TokenType.Identifier, identifier, currentLine, currentColumn);
    }

    private bool TryGetKeyword(string value, out TokenType type) {
        switch (value.ToLower()) {
            case "program": 
                type = TokenType.Keyword;
                return true;
            // Add more keywords here...
            default:
                type = default;
                return false;
        }
    }

    private Token LexNumber() {
        int start = position;

        while (position < length && char.IsDigit(CurrentChar))
            position++;

        if (position < length && CurrentChar == '.') {
            position++;
            while (position < length && char.IsDigit(CurrentChar))
                position++;

            currentColumn += position - start;
            return new Token(TokenType.RealLiteral, sourceCode.Substring(start, position - start), currentLine, currentColumn);
        }

        currentColumn += position - start;
        return new Token(TokenType.IntegerLiteral, sourceCode.Substring(start, position - start), currentLine, currentColumn);
    }

    private char CurrentChar => sourceCode[position];

    private bool IsOperator(char c) {
        switch (c) {
            case '+':
            case '-':
            case '*':
            case '/':
                return true;
            default:
                return false;
        }
    }

    private Token LexOperator() {
        var token = new Token(TokenType.Operator, CurrentChar.ToString(), currentLine, currentColumn);
        position++;
        currentColumn++;
        return token;
    }

    private bool IsDelimiter(char c) {
        switch (c) {
            case ';':
            case ':':
            case '.':
                return true;
            default:
                return false;
        }
    }

    private Token LexDelimiter() {
        var token = new Token(TokenType.Delimiter, CurrentChar.ToString(), currentLine, currentColumn);
        position++;
        currentColumn++;
        return token;
    }

    private Token LexStringLiteral() {
        int start = position + 1;

        while (position < length && CurrentChar != '\'') {
            if (CurrentChar == '\n')
                throw new Exception($"Unclosed string literal at line {currentLine}, column {currentColumn}");
            
            position++;
        }

        if (position >= length)
            throw new Exception($"Unclosed string literal at line {currentLine}, column {currentColumn}");

        var literal = sourceCode.Substring(start, position - start);
        position++; // Skip the closing quote
        currentColumn += position - start + 1;

        return new Token(TokenType.StringLiteral, literal, currentLine, currentColumn);
    }
}