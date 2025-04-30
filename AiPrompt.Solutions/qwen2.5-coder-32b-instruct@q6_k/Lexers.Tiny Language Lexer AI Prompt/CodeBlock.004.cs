public class Parser
{
    private readonly Lexer Lexer;
    private Token CurrentToken;

    public Parser(Lexer lexer)
    {
        Lexer = lexer ?? throw new ArgumentNullException(nameof(lexer));
        CurrentToken = Lexer.NextToken();
    }

    public ProgramNode Parse()
    {
        var stmtList = StatementList();

        if (CurrentToken.Type != TokenType.Eof)
            throw new Exception("Unexpected token");

        return new ProgramNode(stmtList);
    }

    private StmtListNode StatementList()
    {
        var stmts = new StmtListNode(Statement(), null);

        while (CurrentToken.Type == TokenType.Semicolon)
        {
            Consume(TokenType.Semicolon);
            stmts.Add(Statement());
        }
        return stmts;
    }

    private Node Statement()
    {
        switch (CurrentToken.Type)
        {
            case TokenType.Identifier:
                return AssignStmt();
            case TokenType.If:
                return IfStmt();
            case TokenType.While:
                return WhileStmt();
            case TokenType.Print:
                return PrintStmt();

            default:
                throw new Exception($"Unexpected token {CurrentToken.Type}");
        }
    }

    private Node AssignStmt()
    {
        var id = (IdNode)Factor();
        Consume(TokenType.Assign);
        var expr = Expression();

        return new AssignStmtNode(id, expr);
    }

    private Node IfStmt()
    {
        Consume(TokenType.If);
        var condition = Expression();
        Consume(TokenType.Then);
        var thenBranch = StatementList();
        Consume(TokenType.End);

        return new IfStmtNode(condition, thenBranch);
    }

    private Node WhileStmt()
    {
        Consume(TokenType.While);
        var condition = Expression();
        Consume(TokenType.Do);
        var doBlock = StatementList();
        Consume(TokenType.End);

        return new WhileStmtNode(condition, doBlock);
    }

    private Node PrintStmt()
    {
        Consume(TokenType.Print);
        var expr = Expression();

        return new PrintStmtNode(expr);
    }

    private ExprNode Expression()
    {
        var expr = Term();

        while (CurrentToken.Type == TokenType.Plus || CurrentToken.Type == TokenType.Minus)
        {
            var op = CurrentToken;
            Consume(op.Type);
            var right = Term();
            expr = new BinaryExprNode(expr, op, right);
        }

        return expr;
    }

    private ExprNode Term()
    {
        var expr = Factor();

        while (CurrentToken.Type == TokenType.Asterisk || CurrentToken.Type == TokenType.Slash)
        {
            var op = CurrentToken;
            Consume(op.Type);
            var right = Factor();
            expr = new BinaryExprNode(expr, op, right);
        }

        return expr;
    }

    private FactorNode Factor()
    {
        switch (CurrentToken.Type)
        {
            case TokenType.Number:
                var number = CurrentToken;
                Consume(TokenType.Number);
                return new NumberNode(number);

            case TokenType.Identifier:
                var id = CurrentToken;
                Consume(TokenType.Identifier);
                return new IdNode(id);

            case TokenType.LeftParen:
                Consume(TokenType.LeftParen);
                var expr = Expression();
                Consume(TokenType.RightParen);
                return new GroupingExprNode(expr);

            default:
                throw new Exception($"Unexpected token {CurrentToken.Type}");
        }
    }

    private void Consume(TokenType type)
    {
        if (CurrentToken.Type == type)
            CurrentToken = Lexer.NextToken();
        else
            throw new Exception($"Expected '{type}' but got '{CurrentToken.Type}'");
    }
}