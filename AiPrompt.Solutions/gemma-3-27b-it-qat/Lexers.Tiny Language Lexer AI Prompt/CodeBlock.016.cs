using System;
using System.Collections.Generic;

namespace LexerLibrary;

public class Parser
{
    private readonly Lexer _lexer;
    private (Token Token, string RemainingInput) _currentToken;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _currentToken = _lexer.GetNextToken();
    }

    public ProgramNode ParseProgram()
    {
        var programNode = new ProgramNode();
        programNode.Statements = ParseStatementList();
        return programNode;
    }

    private List<AstNode> ParseStatementList()
    {
        var statements = new List<AstNode>();
        statements.Add(ParseStatement());

        while (_currentToken.Token.Type == TokenType.Semicolon)
        {
            ConsumeToken(); // Consume the semicolon
            if (_currentToken.Token.Type != TokenType.EndOfFile)
            {
                statements.Add(ParseStatement());
            }
        }

        return statements;
    }

    private AstNode ParseStatement()
    {
        switch (_currentToken.Token.Type)
        {
            case TokenType.Identifier:
                return ParseAssignStatement();
            case TokenType.IfKeyword:
                return ParseIfStatement();
            case TokenType.WhileKeyword:
                return ParseWhileStatement();
            case TokenType.PrintKeyword:
                return ParsePrintStatement();
            default:
                throw new ArgumentException($"Unexpected token '{_currentToken.Token}'.");
        }
    }

    private AssignStatementNode ParseAssignStatement()
    {
        var assignStatementNode = new AssignStatementNode();
        assignStatementNode.Identifier = _currentToken.Token.Value;
        ConsumeToken(); // Consume identifier

        if (_currentToken.Token.Type != TokenType.Assign)
        {
            throw new ArgumentException($"Expected ':=' token.");
        }
        ConsumeToken(); // Consume assignment operator

        assignStatementNode.Expression = ParseExpression();
        return assignStatementNode;
    }

    private IfStatementNode ParseIfStatement()
    {
        var ifStatementNode = new IfStatementNode();
        ConsumeToken(); // Consume "if" keyword

        ifStatementNode.Condition = ParseExpression();

        if (_currentToken.Token.Type != TokenType.ThenKeyword)
        {
            throw new ArgumentException($"Expected 'then' token.");
        }
        ConsumeToken(); // Consume "then" keyword

        ifStatementNode.ThenBlock = ParseStatementList();

        if (_currentToken.Token.Type != TokenType.EndKeyword)
        {
            throw new ArgumentException($"Expected 'end' token.");
        }
        ConsumeToken(); // Consume "end" keyword

        return ifStatementNode;
    }

    private WhileStatementNode ParseWhileStatement()
    {
        var whileStatementNode = new WhileStatementNode();
        ConsumeToken(); // Consume "while" keyword

        whileStatementNode.Condition = ParseExpression();

        if (_currentToken.Token.Type != TokenType.DoKeyword)
        {
            throw new ArgumentException($"Expected 'do' token.");
        }
        ConsumeToken(); // Consume "do" keyword

        whileStatementNode.DoBlock = ParseStatementList();

        if (_currentToken.Token.Type != TokenType.EndKeyword)
        {
            throw new ArgumentException($"Expected 'end' token.");
        }
        ConsumeToken(); // Consume "end" keyword

        return whileStatementNode;
    }

    private PrintStatementNode ParsePrintStatement()
    {
        var printStatementNode = new PrintStatementNode();
        ConsumeToken(); // Consume "print" keyword

        printStatementNode.Expression = ParseExpression();
        return printStatementNode;
    }

    private ExpressionNode ParseExpression()
    {
        var expressionNode = new ExpressionNode();
        expressionNode.Left = ParseTerm();

        while (_currentToken.Token.Type == TokenType.Plus || _currentToken.Token.Type == TokenType.Minus)
        {
            expressionNode.Operator = _currentToken.Token.Value;
            ConsumeToken(); // Consume operator
            expressionNode.Right = ParseTerm();
        }

        return expressionNode;
    }

    private TermNode ParseTerm()
    {
        var termNode = new TermNode();
        termNode.Left = ParseFactor();

        while (_currentToken.Token.Type == TokenType.Multiply || _currentToken.Token.Token.Type == TokenType.Divide)
        {
            termNode.Operator = _currentToken.Token.Value;
            ConsumeToken(); // Consume operator
            termNode.Right = ParseFactor();
        }

        return termNode;
    }

    private FactorNode ParseFactor()
    {
        var factorNode = new FactorNode();

        switch (_currentToken.Token.Type)
        {
            case TokenType.Identifier:
                factorNode.Identifier = new IdentifierNode { Value = _currentToken.Token.Value };
                ConsumeToken(); // Consume identifier
                return factorNode;
            case TokenType.Number:
                factorNode.Number = new NumberNode { Value = _currentToken.Token.Value };
                ConsumeToken(); // Consume number
                return factorNode;
            case TokenType.LeftParen:
                ConsumeToken(); // Consume "("
                factorNode.Expression = ParseExpression();
                if (_currentToken.Token.Type != TokenType.RightParen)
                {
                    throw new ArgumentException($"Expected ')' token.");
                }
                ConsumeToken(); // Consume ")"
                return factorNode;
            default:
                throw new ArgumentException($"Unexpected token '{_currentToken.Token}'.");
        }
    }

    private void ConsumeToken()
    {
        _currentToken = _lexer.GetNextToken();
    }
}