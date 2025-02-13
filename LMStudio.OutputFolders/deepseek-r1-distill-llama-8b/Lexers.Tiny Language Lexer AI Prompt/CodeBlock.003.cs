using System;
using System.Collections.Generic;

public class Parser
{
    private readonly List<Token> tokens;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
    }

    public Program Parse()
    {
        return new ParserRecursive().ParseStatement();
    }

    class ParserRecursive : IDisposable
    {
        public Statement ParseStatement()
        {
            Statement stmt = null;

            while (tokens.Count > 0 && IsCurrentToken(Type.Assign, Type.If, Type.While, Type.Print))
            {
                switch (CurrentToken.Type)
                {
                    case Type.Assign:
                        stmt = new AssignStmt(
                            new IdentifierToken(tokens[0].Value),
                            ParseExpression());
                        break;
                    case Type.If:
                        IfStmt ifStmt = new IfStmt();
                        ifStmt.Conditional = ParseExpression();
                        while (tokens.Count > 0 && tokens[0].Type == Type.Then)
                        {
                            tokens.RemoveAt(0);
                        }
                        stmt = ifStmt;
                        break;
                    case Type.While:
                        WhileStmt whileStmt = new WhileStmt();
                        whileStmt.Condition = ParseExpression();
                        while (tokens.Count > 0 && tokens[0].Type == Type.Do)
                        {
                            tokens.RemoveAt(0);
                        }
                        stmt = whileStmt;
                        break;
                    case Type.Print:
                        PrintStmt printStmt = new PrintStmt(
                            new IdentifierToken(tokens[0].Value));
                        tokens.RemoveAt(0);
                        return printStmt;
                }
            }

            if (tokens.Count == 0)
                throw new SyntaxErrorException("Unexpected end of input");

            if (stmt != null && !tokens[0].Type.IsAssign || 
                !stmt is IStatement stmt) return stmt;

            throw new SyntaxErrorException("Invalid statement");
        }

        private Expr ParseExpression()
        {
            Expr expr = ParseTerm();
            while (tokens.Count > 0 && IsCurrentToken(Type.Add, Type.Sub))
            {
                switch (tokens[0].Type)
                {
                    case Type.Add: tokens.RemoveAt(0); return new BinaryOpNode(Token.Add, expr, ParseTerm());
                    case Type.Sub: tokens.RemoveAt(0); return new BinaryOpNode(Token.Sub, expr, ParseTerm());
                }
            }

            return expr;
        }

        private Expr ParseTerm()
        {
            Expr term = ParseFactor();
            while (tokens.Count > 0 && IsCurrentToken(Type.Mul, Type.Div))
            {
                switch (tokens[0].Type)
                {
                    case Type.Mul: tokens.RemoveAt(0); return new BinaryOpNode(Token.Mul, term, ParseTerm());
                    case Type.Div: tokens.RemoveAt(0); return new BinaryOpNode(Token.Div, term, ParseTerm());
                }
            }

            return term;
        }

        private Expr ParseFactor()
        {
            if (IsCurrentToken(Type.Literal) || IsCurrentToken(Type.Ident))
                return new LiteralExpr(tokens[0].Value);

            if (tokens.Count > 0 && tokens[0].Type == Type.OpenParen)
            {
                tokens.RemoveAt(0);
                return ParseExpression();
                if (!tokens.Count) throw new SyntaxErrorException("Mismatched parentheses");
            }

            throw new SyntaxErrorException("Unexpected token: " + tokens[0]);
        }

        private bool IsCurrentToken(params Type[] types)
        {
            return (tokens.Count > 0 && types.Contains(tokens[0].Type));
        }

        public void Dispose()
        {
            // No resources to dispose
        }
    }
}