public abstract class ExprNode : IExpression
{
    public abstract Expr Evaluate();
}

public class BinaryOpNode : ExprNode
{
    public readonly Token Op;
    public readonly Expr Left;
    public readonly Expr Right;

    public BinaryOpNode(Token op, Expr left, Expr right)
    {
        Op = op;
        Left = left;
        Right = right;
    }

    public override string ToString() => $"{Left} {Op} {Right}";
}

public class LiteralExpr : ExprNode
{
    public readonly string Value;

    public LiteralExpr(string value)
    {
        Value = value;
    }
}