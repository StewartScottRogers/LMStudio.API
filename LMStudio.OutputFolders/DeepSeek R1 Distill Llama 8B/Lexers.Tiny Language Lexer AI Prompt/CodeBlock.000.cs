using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public record Token
{
    public TokenType Type { get; }
    public string Value { get; }
}

public enum TokenType
{
    ID,
    NUMBER,
    OP_PLUS,
    OP_MINUS,
    OP_MULTIPLY,
    OP_DIVIDE,
    LPAREN,
    RPAREN,
    EQUALS,
    END_IF,
    END_WHILE,
    PRINT,
    ERROR
}

// Lexer implementation
public class Lexer
{
    private readonly string input;
    private int position;

    public Lexer(string input)
    {
        this.input = input;
        position = 0;
    }

    public List<Token> Tokenize()
    {
        var tokens = new List<Token>();
        while (position < input.Length)
        {
            if (IsLetterOrDigit(input[position]))
                tokens.Add(new Token { Type = TokenType.ID, Value = ReadID() });
            else if (input[position] == '+' || input[position] == '-' || input[position] == '*' || input[position] == '/')
                tokens.Add(new Token { Type = GetOperatorType(input[position]), Value = input[position].ToString() });
            else if (input[position] == '(' || input[position] == ')')
                tokens.Add(new Token { Type = TokenType.LPAREN, Value = input[position].ToString() });
            else if (input[position] == '=')
                tokens.Add(new Token { Type = TokenType.EQUALS, Value = "=" });
            else
                throw new SyntaxError("Unexpected character: " + input[position]);
            position++;
        }
        return tokens;
    }

    private string ReadID()
    {
        var start = position;
        while (IsLetterOrDigit(input[start]))
            start++;
        return input.Substring(position, start - position);
    }

    private static bool IsLetterOrDigit(char c)
    {
        return char.IsLetter(c) || char.IsDigit(c);
    }

    private static TokenType GetOperatorType(char op)
    {
        switch (op)
        {
            case '+':
                return TokenType.OP_PLUS;
            case '-':
                return TokenType.OP_MINUS;
            case '*':
                return TokenType.OP_MULTIPLY;
            case '/':
                return TokenType.OP_DIVIDE;
            default:
                throw new SyntaxError("Unexpected operator: " + op);
        }
    }

    // Parser implementation
    public class Parser
    {
        private readonly List<Token> tokens;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            currentTokenIndex = 0;
        }

        private int currentTokenIndex;

        public T Parse<T>(Func<List<Token>, T> parseFunction) where T : INode
        {
            return parseFunction(tokens);
        }

        // Methods for parsing various statements and expressions (not fully implemented)
    }

    // AST Node interface
    public interface INode
    {
        void Accept(PrettyPrinter prettyPrinter);
    }

    // Various AST nodes as records
    public record AssignStmt : INode
    {
        public string Id { get; }
        public Expr Expr { get; }

        public AssignStmt(string id, Expr expr)
        {
            Id = id;
            Expr = expr;
        }

        public void Accept(PrettyPrinter prettyPrinter)
        {
            prettyPrinter.VisitAssignStatement(this);
        }
    }

    // Similar structure for other nodes like IfStmt, WhileStmt, PrintStmt, etc.
}

// Pretty printer implementation
public class PrettyPrinter
{
    public virtual string VisitAssignStatement(AssignStmt statement)
    {
        return $"{statement.Id} = {VisitExpression(statement.Expr)}";
    }

    // Methods for visiting other node types (not fully implemented)
}

// Unit test implementation
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class AppointmentsUnitTests : TestCaseLibrary
{
    [Test]
    public void TestLexer()
    {
        string input = "x=5";
        var lexer = new Lexer(input);
        var tokens = lexer.Tokenize();
        Assert.AreEqual(3, tokens.Count);

        var idToken = tokens.Find(t => t.Type == TokenType.ID) ?? null;
        AssertNotNull(idToken, "ID token missing");

        var equalsToken = tokens.Find(t => t.Type == TokenType.EQUALS) ?? null;
        AssertNotNull(equalsToken, "Equals token missing");

        var numberToken = tokens.Find(t => t.Type == TokenType.NUMBER) ?? null;
        AssertNotNull(numberToken, "Number token missing");
    }

    // Other unit tests for parser and pretty printer (not fully implemented)
}