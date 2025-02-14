using System.Collections.Generic;

public class Parser
{
    private readonly Lexer _lexer;
    private Token _currentToken;
    private Token _peekToken;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _currentToken = _lexer.NextToken();
        _peekToken = _lexer.NextToken();
    }

    private void NextToken()
    {
        _currentToken = _peekToken;
        _peekToken = _lexer.NextToken();
    }

    public ProgramNode ParseProgram()
    {
        var statements = new List<StatementNode>();
        while (_currentToken.Type != TokenType.EOF)
        {
            var stmt = ParseStatement();
            if (stmt is not null)
            {
                statements.Add(stmt);
            }
            NextToken();
        }
        return new(statements);
    }

    private StatementNode? ParseStatement()
    {
        return _currentToken.Type switch
        {
            TokenType.Assign => ParseAssignStatement(),
            TokenType.If => ParseIfStatement(),
            TokenType.While => ParseWhileStatement(),
            TokenType.Print => ParsePrintStatement(),
            _ => null,
        };
    }

    private AssignStatementNode ParseAssignStatement()
    {
        var token = _currentToken;
        var identifier = (IdentifierExpressionNode)ParseIdentifier();

        if (!ExpectPeek(TokenType.Assign))
        {
            throw new Exception($"Expected token ASSIGN, got {_peekToken.Type}");
        }

        NextToken(); // Eat the '=' sign

        var expression = ParseExpression(Precedence.Lowest);

        return new(identifier.Value, expression);
    }

    private IfStatementNode ParseIfStatement()
    {
        if (!ExpectPeek(TokenType.LeftParenthesis))
            throw new Exception($"Expected token LEFT_PARENTHESIS, got {_peekToken.Type}");

        NextToken(); // Eat the '('

        var condition = ParseExpression(Precedence.Lowest);

        if (!ExpectPeek(TokenType.RightParenthesis))
            throw new Exception($"Expected token RIGHT_PARENTHESIS, got {_peekToken.Type}");

        NextToken(); // Eat the ')'

        if (!ExpectPeek(TokenType.LeftBrace))
            throw new Exception($"Expected token LEFT_BRACE, got {_peekToken.Type}");

        var consequence = ParseBlockStatement();

        return new(condition, consequence);
    }

    private WhileStatementNode ParseWhileStatement()
    {
        if (!ExpectPeek(TokenType.LeftParenthesis))
            throw new Exception($"Expected token LEFT_PARENTHESIS, got {_peekToken.Type}");

        NextToken(); // Eat the '('

        var condition = ParseExpression(Precedence.Lowest);

        if (!ExpectPeek(TokenType.RightParenthesis))
            throw new Exception($"Expected token RIGHT_PARENTHESIS, got {_peekToken.Type}");

        NextToken(); // Eat the ')'

        if (!ExpectPeek(TokenType.LeftBrace))
            throw new Exception($"Expected token LEFT_BRACE, got {_peekToken.Type}");

        var body = ParseBlockStatement();

        return new(condition, body);
    }

    private PrintStatementNode ParsePrintStatement()
    {
        NextToken(); // Eat the print token

        var expression = ParseExpression(Precedence.Lowest);

        if (PeekTokenIs(TokenType.Semicolon))
            NextToken();

        return new(expression);
    }

    private List<StatementNode> ParseBlockStatement()
    {
        NextToken(); // Eat the '{'

        var statements = new List<StatementNode>();

        while (!_currentToken.Type.Equals(TokenType.RightBrace) && !_currentToken.Type.Equals(TokenType.EOF))
        {
            var stmt = ParseStatement();
            if (stmt is not null)
                statements.Add(stmt);
            NextToken();
        }

        return statements;
    }

    private ExpressionNode ParseExpression(Precedence precedence)
    {
        var expression = _currentToken.Type switch
        {
            TokenType.Identifier => ParseIdentifier(),
            TokenType.Number => ParseNumberLiteral(),
            TokenType.LeftParenthesis => ParseGroupedExpression(),
            _ => throw new Exception($"No parsing function for token {_currentToken.Type}"),
        };

        while (_peekToken.Type != TokenType.Semicolon && precedence < PeekPrecedence())
        {
            if (InfixParseFunctions.TryGetValue(_peekToken.Type, out var infix))
            {
                NextToken();
                expression = infix(expression);
            }
            else
            {
                break;
            }
        }

        return expression;
    }

    private IdentifierExpressionNode ParseIdentifier()
    {
        var token = _currentToken;
        return new(token.Value!);
    }

    private NumberExpressionNode ParseNumberLiteral()
    {
        var token = _currentToken;

        if (!double.TryParse(token.Value, out double value))
            throw new Exception($"Could not parse number literal: {token.Value}");

        return new(value);
    }

    private GroupedExpressionNode ParseGroupedExpression()
    {
        NextToken();

        var expression = ParseExpression(Precedence.Lowest);

        if (!ExpectPeek(TokenType.RightParenthesis))
            throw new Exception($"Expected token RIGHT_PARENTHESIS, got {_peekToken.Type}");

        return new(expression);
    }

    private bool PeekTokenIs(TokenType type)
    {
        return _peekToken.Type == type;
    }

    private bool CurrentTokenIs(TokenType type)
    {
        return _currentToken.Type == type;
    }

    private bool ExpectPeek(TokenType type)
    {
        if (_peekToken.Type == type)
        {
            NextToken();
            return true;
        }
        else
        {
            throw new Exception($"Expected token {type}, got {_peekToken.Type}");
        }
    }

    private Precedence PeekPrecedence()
    {
        return PrecedenceValues.TryGetValue(_peekToken.Type, out var precedence) ? precedence : Precedence.Lowest;
    }

    private Precedence CurrentPrecedence()
    {
        return PrecedenceValues.TryGetValue(_currentToken.Type, out var precedence) ? precedence : Precedence.Lowest;
    }

    private readonly Dictionary<TokenType, Func<ExpressionNode, ExpressionNode>> InfixParseFunctions = new Dictionary<TokenType, Func<ExpressionNode, ExpressionNode>>
    {
        { TokenType.Plus, ParseInfixExpression },
        { TokenType.Minus, ParseInfixExpression },
        { TokenType.Multiply, ParseInfixExpression },
        { TokenType.Divide, ParseInfixExpression }
    };

    private readonly Dictionary<TokenType, Precedence> PrecedenceValues = new Dictionary<TokenType, Precedence>
    {
        { TokenType.Plus, Precedence.Sum },
        { TokenType.Minus, Precedence.Sum },
        { TokenType.Multiply, Precedence.Product },
        { TokenType.Divide, Precedence.Product }
    };

    private ExpressionNode ParseInfixExpression(ExpressionNode left)
    {
        var token = _currentToken;
        var precedence = CurrentPrecedence();
        NextToken();
        var right = ParseExpression(precedence);
        return new BinaryExpressionNode(left, token.Value!, right);
    }

    private enum Precedence
    {
        Lowest,
        Sum,
        Product,
    }
}