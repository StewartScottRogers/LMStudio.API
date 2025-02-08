using System;
using System.Collections.Generic;

public class Parser
{
    private readonly List<Token> tokens;
    private int current = 0;

    public Parser(IEnumerable<Token> tokens)
    {
        this.tokens = new List<Token>(tokens);
    }

    public AstNode Parse()
    {
        return StmtList();
    }

    private AstNode StmtList()
    {
        var statements = new List<AstNode>();
        while (!IsAtEnd() && Peek().Type != TokenTypes.End)
        {
            statements.Add(Stmt());
            if (Peek().Type == TokenTypes.Semicolon)
                Advance();
        }
        return new StatementListNode(statements);
    }

    private AstNode Stmt()
    {
        switch (Peek().Type)
        {
            case TokenTypes.Identifier when PeekNext().Type == TokenTypes.Equal:
                return AssignStmt();
            case TokenTypes.If:
                return IfStmt();
            case TokenTypes.While:
                return WhileStmt();
            case TokenTypes.Print:
                return PrintStmt();
            default:
                throw new ArgumentException("Unexpected statement");
        }
    }

    private AstNode AssignStmt()
    {
        var identifier = Consume(TokenTypes.Identifier, "Expect variable name.");
        Consume(TokenTypes.Equal, "Expect '=' after variable name.");
        var expression = Expr();
        return new AssignNode(identifier.Value, expression);
    }

    private AstNode IfStmt()
    {
        Consume(TokenTypes.If, "Expect 'if'.");
        var condition = Expr();
        Consume(TokenTypes.Then, "Expect 'then'.");
        var thenBranch = StmtList();
        Consume(TokenTypes.End, "Expect 'end' after if-statement.");
        return new IfNode(condition, thenBranch);
    }

    private AstNode WhileStmt()
    {
        Consume(TokenTypes.While, "Expect 'while'.");
        var condition = Expr();
        Consume(TokenTypes.Do, "Expect 'do'.");
        var body = StmtList();
        Consume(TokenTypes.End, "Expect 'end' after while-statement.");
        return new WhileNode(condition, body);
    }

    private AstNode PrintStmt()
    {
        Consume(TokenTypes.Print, "Expect 'print'.");
        var expression = Expr();
        return new PrintNode(expression);
    }

    private Token Consume(TokenTypes type, string message)
    {
        if (Check(type))
            return Advance();

        throw new ArgumentException(message);
    }

    private bool Check(TokenTypes type)
    {
        if (IsAtEnd())
            return false;
        return Peek().Type == type;
    }

    private Token Peek()
    {
        return tokens[current];
    }

    private Token PeekNext()
    {
        return current + 1 < tokens.Count ? tokens[current + 1] : null;
    }

    private bool IsAtEnd()
    {
        return current >= tokens.Count - 1 || Peek().Type == TokenTypes.End;
    }

    private Token Advance()
    {
        if (!IsAtEnd())
            current++;
        return tokens[current - 1];
    }

    private AstNode Expr()
    {
        var expr = Term();
        while (Match(TokenTypes.Plus) || Match(TokenTypes.Minus))
        {
            var op = Previous();
            var right = Term();
            expr = new BinaryExprNode(expr, op.Type, right);
        }
        return expr;
    }

    private AstNode Term()
    {
        var expr = Factor();
        while (Match(TokenTypes.Asterisk) || Match(TokenTypes.Slash))
        {
            var op = Previous();
            var right = Factor();
            expr = new BinaryExprNode(expr, op.Type, right);
        }
        return expr;
    }

    private AstNode Factor()
    {
        if (Match(TokenTypes.Number))
            return new LiteralNode(Previous().Value);

        if (Match(TokenTypes.Identifier))
            return new VariableNode(Previous().Value);

        if (Match(TokenTypes.LeftParenthesis))
        {
            var expr = Expr();
            Consume(TokenTypes.RightParenthesis, "Expect ')' after expression.");
            return new GroupingExprNode(expr);
        }

        throw new ArgumentException("Unexpected factor");
    }

    private bool Match(params TokenTypes[] types)
    {
        foreach (var type in types)
        {
            if (Check(type))
            {
                Advance();
                return true;
            }
        }
        return false;
    }

    private Token Previous()
    {
        return tokens[current - 1];
    }
}