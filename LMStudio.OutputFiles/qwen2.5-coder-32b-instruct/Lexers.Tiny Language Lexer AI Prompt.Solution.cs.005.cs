// Parser.cs
using System.Collections.Generic;
using System.Linq;

namespace TinyLanguageParser
{
    public readonly struct Parser
    {
        private readonly Token[] tokens;
        private int currentPos;

        public Parser(Token[] tokens)
        {
            this.tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
            this.currentPos = 0;
        }

        public Node Parse()
        {
            return ParseStmtList();
        }

        private Node ParseStmtList()
        {
            var statements = new List<Node>();

            while (currentPos < tokens.Length)
            {
                var stmt = ParseStmt();

                if (stmt != null)
                    statements.Add(stmt);

                if (tokens[currentPos].Kind == TokenKind.Semicolon)
                    currentPos++;
            }

            return new StmtListNode(statements.ToArray());
        }

        private Node ParseStmt()
        {
            switch (tokens[currentPos].Kind)
            {
                case TokenKind.Identifier:
                    return ParseAssignStmt();
                case TokenKind.IfKeyword:
                    return ParseIfStmt();
                case TokenKind.WhileKeyword:
                    return ParseWhileStmt();
                case TokenKind.PrintKeyword:
                    return ParsePrintStmt();
                default:
                    throw new InvalidOperationException($"Unexpected token: {tokens[currentPos].Value}");
            }
        }

        private AssignStmtNode ParseAssignStmt()
        {
            var identifier = tokens[currentPos++].Value;
            
            if (tokens[currentPos++].Kind != TokenKind.ColonEquals)
                throw new InvalidOperationException("Expected := after identifier");

            var expression = ParseExpr();
            
            return new AssignStmtNode(identifier, expression);
        }

        private IfStmtNode ParseIfStmt()
        {
            currentPos++; // consume 'if'
            var condition = ParseExpr();

            if (tokens[currentPos++].Kind != TokenKind.ThenKeyword)
                throw new InvalidOperationException("Expected 'then' after condition");

            var trueBranch = ParseStmtList();

            if (tokens[currentPos++].Kind != TokenKind.EndKeyword)
                throw new InvalidOperationException("Expected 'end' after true branch");

            return new IfStmtNode(condition, trueBranch);
        }

        private WhileStmtNode ParseWhileStmt()
        {
            currentPos++; // consume 'while'
            var condition = ParseExpr();

            if (tokens[currentPos++].Kind != TokenKind.DoKeyword)
                throw new InvalidOperationException("Expected 'do' after condition");

            var body = ParseStmtList();

            if (tokens[currentPos++].Kind != TokenKind.EndKeyword)
                throw new InvalidOperationException("Expected 'end' after body");

            return new WhileStmtNode(condition, body);
        }

        private PrintStmtNode ParsePrintStmt()
        {
            currentPos++; // consume 'print'
            var expression = ParseExpr();
            
            return new PrintStmtNode(expression);
        }

        private ExprNode ParseExpr()
        {
            var left = ParseTerm();

            while (currentPos < tokens.Length)
            {
                switch (tokens[currentPos].Kind)
                {
                    case TokenKind.Plus:
                    case TokenKind.Minus:
                        var opToken = tokens[currentPos++];
                        var right = ParseTerm();
                        left = new BinaryExprNode(left, opToken.Kind, right);
                        break;
                    default:
                        return left;
                }
            }

            return left;
        }

        private ExprNode ParseTerm()
        {
            var left = ParseFactor();

            while (currentPos < tokens.Length)
            {
                switch (tokens[currentPos].Kind)
                {
                    case TokenKind.Star:
                    case TokenKind.Slash:
                        var opToken = tokens[currentPos++];
                        var right = ParseFactor();
                        left = new BinaryExprNode(left, opToken.Kind, right);
                        break;
                    default:
                        return left;
                }
            }

            return left;
        }

        private ExprNode ParseFactor()
        {
            switch (tokens[currentPos].Kind)
            {
                case TokenKind.Number:
                    var numberValue = int.Parse(tokens[currentPos++].Value);
                    return new NumberExprNode(numberValue);
                case TokenKind.Identifier:
                    var identifier = tokens[currentPos++].Value;
                    return new IdentifierExprNode(identifier);
                case TokenKind.LeftParenthesis:
                    currentPos++; // consume '('
                    var expr = ParseExpr();
                    
                    if (tokens[currentPos++].Kind != TokenKind.RightParenthesis)
                        throw new InvalidOperationException("Expected ')'");
                    
                    return expr;
                default:
                    throw new InvalidOperationException($"Unexpected token: {tokens[currentPos].Value}");
            }
        }
    }
}