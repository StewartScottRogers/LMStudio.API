using System;

namespace GrammarParser
{
    public abstract class Node { }

    public class EmptyNode : Node { }

    public class StmtListNode : Node
    {
        public readonly Node Stmt;
        public readonly Node NextStmtList;

        public StmtListNode(Node stmt, Node nextStmtList)
        {
            Stmt = stmt ?? throw new ArgumentNullException(nameof(stmt));
            NextStmtList = nextStmtList ?? throw new ArgumentNullException(nameof(nextStmtList));
        }
    }

    public class AssignNode : Node
    {
        public readonly string Identifier;
        public readonly Expression Expression;

        public AssignNode(string identifier, Expression expression)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
    }

    public class IfNode : Node
    {
        public readonly Expression Condition;
        public readonly Node ThenPart;

        public IfNode(Expression condition, Node thenPart)
        {
            Condition = condition ?? throw new ArgumentNullException(nameof(condition));
            ThenPart = thenPart ?? throw new ArgumentNullException(nameof(thenPart));
        }
    }

    public class WhileNode : Node
    {
        public readonly Expression Condition;
        public readonly Node Body;

        public WhileNode(Expression condition, Node body)
        {
            Condition = condition ?? throw new ArgumentNullException(nameof(condition));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }
    }

    public class PrintNode : Node
    {
        public readonly Expression Expression;

        public PrintNode(Expression expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
    }

    public abstract class Expression { }

    public class BinaryOpNode : Expression
    {
        public readonly Expression Left;
        public readonly TokenType Operator;
        public readonly Expression Right;

        public BinaryOpNode(Expression left, TokenType op, Expression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Operator = op;
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }

    public class NumberNode : Expression
    {
        public readonly int Value;

        public NumberNode(int value)
        {
            Value = value;
        }
    }

    public class IdentifierNode : Expression
    {
        public readonly string Name;

        public IdentifierNode(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}