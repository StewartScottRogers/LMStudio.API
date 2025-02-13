public class AbstractSyntaxTree
{
    private readonly Lexer lexer;
    private Token currentToken;

    public AbstractSyntaxTree(string source)
    {
        lexer = new Lexer(source);
        Advance();
    }

    private void Advance()
    {
        currentToken = lexer.ScanToken();
    }

    public StatementNode ParseStatementList()
    {
        var statements = new List<StatementNode>();
        
        while (currentToken.Kind != TokenKind.EndOfFile)
        {
            statements.Add(ParseStatement());
            if (currentToken.Kind == TokenKind.Semicolon)
                Advance();
            else
                throw new Exception($"Expected ';' after statement, found {currentToken.Kind}");
        }

        return new StatementListNode(statements);
    }
    
    private StatementNode ParseStatement()
    {
        switch (currentToken.Kind)
        {
            case TokenKind.Identifier:
                return ParseAssignStatement();
            case TokenKind.IfKeyword:
                return ParseIfStatement();
            case TokenKind.WhileKeyword:
                return ParseWhileStatement();
            case TokenKind.PrintKeyword:
                return ParsePrintStatement();
            default:
                throw new Exception($"Unexpected token {currentToken.Kind}");
        }
    }

    private AssignStatementNode ParseAssignStatement()
    {
        var id = (IdentifierNode)ParseFactor();
        Consume(TokenKind.ColonEquals, "Expected ':=' after identifier");
        var expression = ParseExpression();

        return new AssignStatementNode(id, expression);
    }

    private IfStatementNode ParseIfStatement()
    {
        Advance(); // consume 'if'
        var condition = ParseExpression();
        Consume(TokenKind.ThenKeyword, "Expected 'then' after if statement");
        var thenBranch = ParseStatementList();
        Consume(TokenKind.EndKeyword, "Expected 'end' after if statement");

        return new IfStatementNode(condition, thenBranch);
    }

    private WhileStatementNode ParseWhileStatement()
    {
        Advance(); // consume 'while'
        var condition = ParseExpression();
        Consume(TokenKind.DoKeyword, "Expected 'do' after while statement");
        var body = ParseStatementList();
        Consume(TokenKind.EndKeyword, "Expected 'end' after while statement");

        return new WhileStatementNode(condition, body);
    }

    private PrintStatementNode ParsePrintStatement()
    {
        Advance(); // consume 'print'
        var expression = ParseExpression();

        return new PrintStatementNode(expression);
    }

    private ExpressionNode ParseExpression()
    {
        var expr = ParseTerm();
        
        while (currentToken.Kind is TokenKind.Plus or TokenKind.Minus)
        {
            var op = currentToken;
            Advance();
            var right = ParseTerm();
            expr = new BinaryExpressionNode(expr, op, right);
        }

        return expr;
    }

    private TermNode ParseTerm()
    {
        var term = ParseFactor();
        
        while (currentToken.Kind is TokenKind.Asterisk or TokenKind.Slash)
        {
            var op = currentToken;
            Advance();
            var right = ParseFactor();
            term = new BinaryExpressionNode(term, op, right);
        }

        return term;
    }
    
    private FactorNode ParseFactor()
    {
        switch (currentToken.Kind)
        {
            case TokenKind.LeftParen:
                Advance(); // consume '('
                var expr = ParseExpression();
                Consume(TokenKind.RightParen, "Expected ')' after expression");
                return new GroupingExpressionNode(expr);
            
            case TokenKind.Number:
                var numberValue = currentToken;
                Advance();
                return new NumberNode(double.Parse(numberValue.Lexeme));
                
            case TokenKind.Identifier:
                var identifierName = currentToken;
                Advance();
                return new IdentifierNode(identifierName.Lexeme);

            default:
                throw new Exception($"Unexpected token {currentToken.Kind}");
        }
    }

    private void Consume(TokenKind expected, string message)
    {
        if (currentToken.Kind == expected)
        {
            Advance();
        }
        else
        {
            throw new Exception(message);
        }
    }
}