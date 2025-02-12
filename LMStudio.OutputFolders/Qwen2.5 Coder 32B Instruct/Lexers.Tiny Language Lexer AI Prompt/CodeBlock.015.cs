public class ParenthesizedExpression : Expression
{
    public readonly Expression InnerExpression;

    public ParenthesizedExpression(Expression innerExpression)
    {
        InnerExpression = innerExpression ?? throw new ArgumentNullException(nameof(innerExpression));
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitParenthesizedExpression(this);
}