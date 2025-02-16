using System.Collections.Generic;

namespace GrammarParser
{
    public class Parser
    {
        private readonly List<Token> Tokens;
        private int CurrentPosition = 0;
        private Token CurrentToken => Tokens[CurrentPosition];

        public Parser(List<Token> tokens)
        {
            Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
        }

        public Node Parse()
        {
            return ParseStmtList();
        }

        private Node ParseStmtList()
        {
            if (CurrentToken.Type == TokenType.EndOfFile)
                return new EmptyNode();

            var stmt = ParseStmt();

            if (CurrentToken.Type != TokenType.Semicolon)
                return stmt;

            Advance();
            var nextStmtList = ParseStmtList();

            return new StmtListNode(stmt, nextStmtList);
        }

        private Node ParseStmt()
        {
            switch (CurrentToken.Type)
            {
                case TokenType.Identifier:
                    return ParseAssignStmt();
                case TokenType.If:
                    return ParseIfStmt();
                case TokenType.While:
                    return ParseWhileStmt();
                case TokenType.Print:
                    return ParsePrintStmt();
                default:
                    throw new InvalidOperationException($"Unexpected token: {CurrentToken.Text}");
            }
        }

        private AssignNode ParseAssignStmt()
        {
            var identifier = CurrentToken.Text;
            Consume(TokenType.Identifier);

            Consume(TokenType.Assign);
            var expression = ParseExpr();

            return new AssignNode(identifier, expression);
        }

        private IfNode ParseIfStmt()
        {
            Consume(TokenType.If);
            var condition = ParseExpr();
            Consume(TokenType.Then);
            var thenPart = ParseStmtList();
            Consume(TokenType.End);

            return new IfNode(condition, thenPart);
        }

        private WhileNode ParseWhileStmt()
        {
            Consume(TokenType.While);
            var condition = ParseExpr();
            Consume(TokenType.Do);
            var body = ParseStmtList();
            Consume(TokenType.End);

            return new WhileNode(condition, body);
        }

        private PrintNode ParsePrintStmt()
        {
            Consume(TokenType.Print);
            var expression = ParseExpr();

            return new PrintNode(expression);
        }

        private Expression ParseExpr()
        {
            var term = ParseTerm();

            while (CurrentToken.Type == TokenType.Plus || CurrentToken.Type == TokenType.Minus)
            {
                var op = CurrentToken.Type;
                Advance();
                var nextTerm = ParseTerm();

                term = new BinaryOpNode(term, op, nextTerm);
            }

            return term;
        }

        private Expression ParseTerm()
        {
            var factor = ParseFactor();

            while (CurrentToken.Type == TokenType.Multiply || CurrentToken.Type == TokenType.Divide)
            {
                var op = CurrentToken.Type;
                Advance();
                var nextFactor = ParseFactor();

                factor = new BinaryOpNode(factor, op, nextFactor);
            }

            return factor;
        }

        private Expression ParseFactor()
        {
            switch (CurrentToken.Type)
            {
                case TokenType.Number:
                    var number = int.Parse(CurrentToken.Text);
                    Advance();
                    return new NumberNode(number);
                case TokenType.Identifier:
                    var identifier = CurrentToken.Text;
                    Advance();
                    return new IdentifierNode(identifier);
                case TokenType.LeftParen:
                    Advance();
                    var expr = ParseExpr();
                    Consume(TokenType.RightParen);
                    return expr;
                default:
                    throw new InvalidOperationException($"Unexpected token: {CurrentToken.Text}");
            }
        }

        private void Consume(TokenType type)
        {
            if (CurrentToken.Type == type)
                Advance();
            else
                throw new InvalidOperationException($"Expected token of type {type}, but found {CurrentToken.Type}");
        }

        private void Advance()
        {
            CurrentPosition++;
        }
    }
}