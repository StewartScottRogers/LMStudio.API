public class BinaryExpression : Expression
{
    public readonly Expression Left;
    public readonly Token OperatorToken;
    public readonly Expression Right;

    public BinaryExpression(Expression left, Token operatorToken, Expression right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        OperatorToken = operatorToken;
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitBinaryExpression(this);
}