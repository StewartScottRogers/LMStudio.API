public class Parser
{
    private readonly Lexer lexer;
    private Token currentToken;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
        NextToken();
    }

    private void NextToken()
    {
        currentToken = lexer.NextToken();
    }

    private bool CurTokenIs(TokenType tokenType)
    {
        return currentToken.Type == tokenType;
    }

    private void Eat(TokenType tokenType)
    {
        if (CurTokenIs(tokenType))
            NextToken();
        else
            throw new Exception($"Expected {tokenType}, got {currentToken.Type}");
    }

    public ASTNode ParseProgram()
    {
        var statements = new List<Statement>();
        
        while (!CurTokenIs(TokenType.EndOfFile))
            statements.Add(ParseStatement());
        
        return new ProgramNode(new StatementListNode(statements));
    }

    private Statement ParseStatement()
    {
        switch (currentToken.Type)
        {
            case TokenType.Identifier:
                if (Peek().Type == TokenType.ColonEquals)
                    return ParseAssignmentStatement();
                break;
            case TokenType.IfKeyword:
                return ParseIfStatement();
            case TokenType.WhileKeyword:
                return ParseWhileStatement();
            case TokenType.PrintKeyword:
                return ParsePrintStatement();
        }
        
        throw new Exception($"Unknown statement: {currentToken}");
    }

    private Token Peek()
    {
        var peekToken = lexer.NextToken();
        lexer.ReadChar();  // Reset the read position
        return peekToken;
    }

    private Statement ParseAssignmentStatement()
    {
        Eat(TokenType.Identifier);
        string identifier = currentToken.Value;

        Eat(TokenType.ColonEquals);

        ExpressionNode expression = ParseExpression();

        Eat(TokenType.Semicolon);

        return new AssignmentStatementNode(identifier, expression);
    }

    private IfStatementNode ParseIfStatement()
    {
        Eat(TokenType.IfKeyword);

        var condition = ParseExpression();
        
        Eat(TokenType.ThenKeyword);

        var consequence = ParseBlockStatement();

        Eat(TokenType.EndKeyword);

        return new IfStatementNode(condition, consequence);
    }

    private WhileStatementNode ParseWhileStatement()
    {
        Eat(TokenType.WhileKeyword);

        var condition = ParseExpression();
        
        Eat(TokenType.DoKeyword);

        var body = ParseBlockStatement();

        Eat(TokenType.EndKeyword);

        return new WhileStatementNode(condition, body);
    }

    private PrintStatementNode ParsePrintStatement()
    {
        Eat(TokenType.PrintKeyword);

        var expression = ParseExpression();
        
        Eat(TokenType.Semicolon);

        return new PrintStatementNode(expression);
    }

    private StatementListNode ParseBlockStatement()
    {
        var statements = new List<Statement>();

        while (!CurTokenIs(TokenType.EndKeyword))
            statements.Add(ParseStatement());

        return new StatementListNode(statements);
    }

    private ExpressionNode ParseExpression()
    {
        // This is a very simplified version of expression parsing
        return ParseTerm();
    }

    private ExpressionNode ParseTerm()
    {
        var factor = ParseFactor();

        while (CurTokenIs(TokenType.Multiply) || CurTokenIs(TokenType.Divide))
        {
            if (CurTokenIs(TokenType.Multiply))
                factor = new MultiplicationExpressionNode(factor, ParseFactor());
            else
                factor = new DivisionExpressionNode(factor, ParseFactor());

            Eat(CurTokenIs(TokenType.Multiply) ? TokenType.Multiply : TokenType.Divide);
        }

        return factor;
    }

    private ExpressionNode ParseFactor()
    {
        if (CurTokenIs(TokenType.Number))
        {
            int value = int.Parse(currentToken.Value);
            Eat(TokenType.Number);
            return new NumberExpressionNode(value);
        }
        else if (CurTokenIs(TokenType.Identifier))
        {
            string identifier = currentToken.Value;
            Eat(TokenType.Identifier);
            return new IdentifierExpressionNode(identifier);
        }
        else if (CurTokenIs(TokenType.LeftParenthesis))
        {
            Eat(TokenType.LeftParenthesis);
            var expression = ParseExpression();
            Eat(TokenType.RightParenthesis);

            return new GroupedExpressionNode(expression);
        }

        throw new Exception($"Unexpected token in parseFactor: {currentToken.Type}");
    }
}