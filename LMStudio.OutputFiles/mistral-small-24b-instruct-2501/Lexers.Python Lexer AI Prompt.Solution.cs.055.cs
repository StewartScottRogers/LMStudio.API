using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PythonLexerLibrary
{
    public class TokenType
    {
        public const string Name = "NAME";
        // Add other token types here as needed
    }

    public record Token(string Type, string Value);
    public static class Lexer
    {
        private readonly StreamReader stream;
        private readonly char[] buffer;

        public Lexer(Stream input)
        {
            this.stream = new StreamReader(input);
            this.buffer = new char[1024];
        }

        public (string Token, string Value) GetToken()
        {
            var tokenStringBuilder = new StringBuilder();
            var c = ReadChar();

            if (char.IsLetterOrDigit(c))
            {
                while (!char.IsWhiteSpace(c))
                {
                    tokenStringBuilder.Append(c);
                    c = PeekChar();
                }
            }

            return new Token { Type = "IDENTIFIER", Value = tokenStringBuilder.ToString() };

        case var c when char.IsWhiteSpace(c):
            // Ignore whitespace
            break;
    }
}

// Define the main lexer class
public class Lexer
{
    private readonly string input;

    public Lexer(string input)
    {
        this.input = input ?? throw new ArgumentNullException(nameof(input));
    }

    public List<Token> Tokenize()
    {
        var tokens = new List<Token>();
        int position = 0;
        while (position < input.Length)
        {
            if (char.IsWhiteSpace(input[position]))
            {
                position++;
                continue;
            }

            if (char.IsLetterOrDigit(input[position]) || input[position] == '_')
            {
                string token = GetToken(input, ref position);
                // Process the token
                // Example: tokens.Add(new Token { Type = TokenType.Identifier, Value = token });
            }
            else if (input[position] == '\"' || input[position] == '\'')
            {
                var endQuote = input.IndexOf(input[position], position + 1);
                var stringLiteral = input.Substring(position, endQuote - position + 1);

                // Add code to handle string literals
                // For example, add the string literal to a list or process it accordingly

                position = endQuote;  // Move past the current string literal
            } while (true);
        }

    public List<Tuple> Parse(List<string> input)
    {
        var tokens = Tokenize(input);
        return new StatementParser(tokens).Parse();
    }
}

public class Token
{
    public enum Kind
    {
        Name,
        Number,
        String,
        Operator,
        Keyword,
        Newline,
        Indent,
        Dedent,
        EndMarker
    }

    public readonly Kind Type;
    public readonly string Value;

    public Token(Kind type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}

The solution will be structured as follows:

1. **Class Library for Lexer**:
   - **Lexer.cs**: The main lexer class that will tokenize the input based on the given grammar.
   - **Token.cs**: Represents a token with properties for type and value.
   - **TokenType.cs**: Enumeration of token types.
   - **AbstractSyntaxTree.cs**: Class to represent the Abstract Syntax Tree (AST).
   - **AstNode.cs**: Base class for all AST nodes.
   - **PrettyPrinter.cs**: Class to pretty-print the AST.

### Solution Structure

1. **LexerLibrary**
    - **Classes**
        - AstNode.cs
        - AssignmentNode.cs
        - CompoundStatementNode.cs
        - SimpleStatementNode.cs
        - ExpressionNode.cs
        - FunctionDefNode.cs
        - ReturnStmtNode.cs
        - ImportStmtNode.cs
        - RaiseStmtNode.cs
        - GlobalStmtNode.cs
        | NonlocalStmtNode.cs
        | DelStmtNode.cs
        | YieldStmtNode.cs
        | AssertStmtNode.cs
        | BreakContinueStmtNode.cs
        | ImportNameNode.cs
        | ImportFromNode.cs
        | WithItemNode.cs

Below are the files and code for the .NET 9.0 Solution as per your requirements.

### File Structure