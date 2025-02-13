// Nodes/BinaryExpressionNode.cs
public class BinaryExpressionNode : ExpressionNode
{
    public readonly ExpressionNode Left;
    public readonly Token Operator;
    public readonly ExpressionNode Right;

    public BinaryExpressionNode(ExpressionNode left, Token op, ExpressionNode right)
    {
        Left = left;
        Operator = op;
        Right = right;
    }

    public override string Accept(IExpressionVisitor visitor) => visitor.VisitBinaryExpression(this);
}

// Nodes/GroupingExpressionNode.cs
public class GroupingExpressionNode : ExpressionNode
{
    public readonly ExpressionNode Expression;

    public GroupingExpressionNode(ExpressionNode expression)
    {
        Expression = expression;
    }

    public override string Accept(IExpressionVisitor visitor) => visitor.VisitGroupingExpression(this);
}

// Nodes/NumberNode.cs
public class NumberNode : ExpressionNode
{
    public readonly double Value;

    public NumberNode(double value)
    {
        Value = value;
    }

    public override string Accept(IExpressionVisitor visitor) => visitor.VisitNumber(this);
}

// Nodes/IdentifierNode.cs
public class IdentifierNode : ExpressionNode
{
    public readonly string Name;

    public IdentifierNode(string name)
    {
        Name = name;
    }

    public override string Accept(IExpressionVisitor visitor) => visitor.VisitIdentifier(this);
}