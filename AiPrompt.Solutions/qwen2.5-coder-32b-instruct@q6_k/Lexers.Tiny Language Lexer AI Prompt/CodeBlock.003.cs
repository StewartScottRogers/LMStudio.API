public abstract class Node { }

public class ProgramNode : Node
{
    public readonly StmtListNode StmtList;

    public ProgramNode(StmtListNode stmtList)
    {
        StmtList = stmtList ?? throw new ArgumentNullException(nameof(stmtList));
    }
}

public class StmtListNode : Node
{
    public readonly Node Statement;
    public readonly StmtListNode Next;

    public StmtListNode(Node statement, StmtListNode next)
    {
        Statement = statement ?? throw new ArgumentNullException(nameof(statement));
        Next = next;
    }

    public void Add(Node node)
    {
        var current = this;
        while (current.Next != null)
            current = current.Next;

        current.Next = new StmtListNode(node, null);
    }
}

public class AssignStmtNode : Node
{
    public readonly IdNode Identifier;
    public readonly ExprNode Expression;

    public AssignStmtNode(IdNode identifier, ExprNode expression)
    {
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }
}

public class IfStmtNode : Node
{
    public readonly ExprNode Condition;
    public readonly StmtListNode ThenBranch;

    public IfStmtNode(ExprNode condition, StmtListNode thenBranch)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        ThenBranch = thenBranch ?? throw new ArgumentNullException(nameof(thenBranch));
    }
}

public class WhileStmtNode : Node
{
    public readonly ExprNode Condition;
    public readonly StmtListNode DoBlock;

    public WhileStmtNode(ExprNode condition, StmtListNode doBlock)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        DoBlock = doBlock ?? throw new ArgumentNullException(nameof(doBlock));
    }
}

public class PrintStmtNode : Node
{
    public readonly ExprNode Expression;

    public PrintStmtNode(ExprNode expression)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }
}

public abstract class ExprNode : Node { }

public class BinaryExprNode : ExprNode
{
    public readonly ExprNode Left;
    public readonly Token OperatorToken;
    public readonly ExprNode Right;

    public BinaryExprNode(ExprNode left, Token operatorToken, ExprNode right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        OperatorToken = operatorToken;
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }
}

public class UnaryExprNode : ExprNode
{
    public readonly Token OperatorToken;
    public readonly ExprNode Operand;

    public UnaryExprNode(Token operatorToken, ExprNode operand)
    {
        OperatorToken = operatorToken;
        Operand = operand ?? throw new ArgumentNullException(nameof(operand));
    }
}

public class GroupingExprNode : ExprNode
{
    public readonly ExprNode Expression;

    public GroupingExprNode(ExprNode expression)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }
}

public abstract class FactorNode : ExprNode { }

public class IdNode : FactorNode
{
    public readonly Token IdentifierToken;

    public IdNode(Token identifierToken)
    {
        IdentifierToken = identifierToken;
    }
}

public class NumberNode : FactorNode
{
    public readonly Token NumberToken;

    public NumberNode(Token numberToken)
    {
        NumberToken = numberToken;
    }
}