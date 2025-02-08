using System.Collections.Generic;

public class Parser
{
    private readonly Lexer lexer;
    private Token currentToken;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
        currentToken = lexer.GetNextToken();
    }

    private void Eat(TokenType tokenType)
    {
        if (currentToken.Type == tokenType)
            currentToken = lexer.GetNextToken(); // advance the pointer
        else
            throw new Exception($"Unexpected token: {currentToken}");
    }

    public AstNode Parse()
    {
        return Statements();
    }

    private AstNode Statements()
    {
        var statements = new List<AstNode>();
        while (currentToken.Type != TokenType.EndMarker)
        {
            var statement = Statement();
            if (statement != null) // Ensure the statement is not null
                statements.Add(statement);
        }
        return new CompoundStatement(statements);
    }

    private AstNode Statement()
    {
        if (IsCompoundStmt(currentToken))
            return CompoundStmt();

        else if (IsSimpleStmts(currentToken))
            return SimpleStmts();

        throw new Exception("Unknown statement type");
    }

    // Add more parsing methods here for different grammar rules
    private bool IsCompoundStmt(Token token) => token.Type == TokenType.Keyword && (token.Value == "if" || token.Value == "def" || token.Value == "class" || token.Value == "with" || token.Value == "for" || token.Value == "try" || token.Value == "while" || token.Value == "match");
    private bool IsSimpleStmts(Token token) => token.Type != TokenType.Keyword;

    // Placeholder for compound statements
    private AstNode CompoundStmt()
    {
        Eat(TokenType.Keyword);
        return new CompoundStatement(new List<AstNode>()); // Stub implementation
    }

    // Placeholder for simple statements
    private AstNode SimpleStmts()
    {
        var stmts = new List<AstNode>();
        while (currentToken.Type != TokenType.NewLine)
        {
            var stmt = SimpleStmt();
            stmts.Add(stmt);
            if (currentToken.Type == TokenType.Punctuation && currentToken.Value == ";")
                Eat(TokenType.Punctuation); // Skip semicolon
        }
        return new CompoundStatement(stmts);
    }

    private AstNode SimpleStmt()
    {
        switch (currentToken.Type)
        {
            case TokenType.Name:
                return Assignment();
            case TokenType.Keyword when currentToken.Value == "return":
                return ReturnStmt();
            case TokenType.Keyword when currentToken.Value == "raise":
                return RaiseStmt();
            default:
                throw new Exception("Unknown simple statement type");
        }
    }

    private AstNode Assignment()
    {
        var left = new Variable(currentToken.Value);
        Eat(TokenType.Name);

        if (currentToken.Type == TokenType.Punctuation && currentToken.Value == ":")
        {
            Eat(TokenType.Punctuation); // :
            var expr = Expression();
            return new TypedAssignment(left, expr);
        }

        if (currentToken.Type == TokenType.Punctuation && currentToken.Value == "=")
        {
            Eat(TokenType.Punctuation); // =
            var expr = Expression();
            return new AssignmentNode(left, expr);
        }

        throw new Exception("Invalid assignment");
    }

    private AstNode ReturnStmt()
    {
        Eat(TokenType.Keyword); // return
        if (currentToken.Type == TokenType.EndMarker || currentToken.Type == TokenType.NewLine)
            return new ReturnStatement(null);

        var expr = Expression();
        return new ReturnStatement(expr);
    }

    private AstNode RaiseStmt()
    {
        Eat(TokenType.Keyword); // raise
        if (currentToken.Type == TokenType.EndMarker || currentToken.Type == TokenType.NewLine)
            return new RaiseStatement(null, null);

        var exception = Expression();

        if (currentToken.Type != TokenType.Keyword || currentToken.Value != "from")
            return new RaiseStatement(exception, null);

        Eat(TokenType.Keyword); // from
        var cause = Expression();
        return new RaiseStatement(exception, cause);
    }

    private AstNode Expression()
    {
        var node = Term();

        while (currentToken.Type == TokenType.Operator && (currentToken.Value == "+" || currentToken.Value == "-"))
        {
            var token = currentToken;
            Eat(TokenType.Operator);

            if (token.Value == "+")
                node = new BinaryOperation(node, token, Term());
            else
                node = new BinaryOperation(node, token, Term());
        }

        return node;
    }

    private AstNode Term()
    {
        var node = Factor();

        while (currentToken.Type == TokenType.Operator && (currentToken.Value == "*" || currentToken.Value == "/" || currentToken.Value == "//" || currentToken.Value == "%" || currentToken.Value == "@"))
        {
            var token = currentToken;
            Eat(TokenType.Operator);

            if (token.Value == "*")
                node = new BinaryOperation(node, token, Factor());
            else if (token.Value == "/")
                node = new BinaryOperation(node, token, Factor());
            else if (token.Value == "//")
                node = new BinaryOperation(node, token, Factor());
            else if (token.Value == "%")
                node = new BinaryOperation(node, token, Factor());
            else // token.Value == "@"
                node = new BinaryOperation(node, token, Factor());
        }

        return node;
    }

    private AstNode Factor()
    {
        var token = currentToken;
        Eat(TokenType.Number);

        if (token.Type == TokenType.Number)
            return new NumberNode(double.Parse(token.Value));

        throw new Exception("Unexpected token");
    }
}