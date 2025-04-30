public abstract class ASTNode {}

// Statements
public abstract class Statement : ASTNode {}
public class ProgramNode : Statement
{
    public readonly StatementListNode Statements;
    
    public ProgramNode(StatementListNode statements)
    {
        Statements = statements;
    }
}

public class StatementListNode : Statement
{
    public readonly List<Statement> Statements;

    public StatementListNode(List<Statement> statements)
    {
        Statements = statements ?? new();
    }
}

public class AssignmentStatementNode : Statement
{
    public readonly string Identifier;
    public readonly ExpressionNode Expression;
    
    public AssignmentStatementNode(string identifier, ExpressionNode expression)
    {
        Identifier = identifier;
        Expression = expression;
    }
}

public class IfStatementNode : Statement
{
    public readonly ExpressionNode Condition;
    public readonly StatementListNode Consequence;

    public IfStatementNode(ExpressionNode condition, StatementListNode consequence)
    {
        Condition = condition;
        Consequence = consequence;
    }
}

public class WhileStatementNode : Statement
{
    public readonly ExpressionNode Condition;
    public readonly StatementListNode Body;

    public WhileStatementNode(ExpressionNode condition, StatementListNode body)
    {
        Condition = condition;
        Body = body;
    }
}

public class PrintStatementNode : Statement
{
    public readonly ExpressionNode Expression;

    public PrintStatementNode(ExpressionNode expression)
    {
        Expression = expression;
    }
}

// Expressions
public abstract class ExpressionNode : ASTNode {}
public class IdentifierExpressionNode : ExpressionNode
{
    public readonly string Identifier;

    public IdentifierExpressionNode(string identifier)
    {
        Identifier = identifier;
    }
}

public class NumberExpressionNode : ExpressionNode
{
    public readonly int Value;

    public NumberExpressionNode(int value)
    {
        Value = value;
    }
}

public abstract class BinaryOperationExpressionNode : ExpressionNode
{
    public readonly ExpressionNode Left;
    public readonly ExpressionNode Right;

    protected BinaryOperationExpressionNode(ExpressionNode left, ExpressionNode right)
    {
        Left = left;
        Right = right;
    }
}

public class AdditionExpressionNode : BinaryOperationExpressionNode
{
    public AdditionExpressionNode(ExpressionNode left, ExpressionNode right) 
        : base(left, right)
    {
    }
}

public class SubtractionExpressionNode : BinaryOperationExpressionNode
{
    public SubtractionExpressionNode(ExpressionNode left, ExpressionNode right) 
        : base(left, right)
    {
    }
}

public class MultiplicationExpressionNode : BinaryOperationExpressionNode
{
    public MultiplicationExpressionNode(ExpressionNode left, ExpressionNode right) 
        : base(left, right)
    {
    }
}

public class DivisionExpressionNode : BinaryOperationExpressionNode
{
    public DivisionExpressionNode(ExpressionNode left, ExpressionNode right) 
        : base(left, right)
    {
    }
}

public class GroupedExpressionNode : ExpressionNode
{
    public readonly ExpressionNode Inner;

    public GroupedExpressionNode(ExpressionNode inner)
    {
        Inner = inner;
    }
}