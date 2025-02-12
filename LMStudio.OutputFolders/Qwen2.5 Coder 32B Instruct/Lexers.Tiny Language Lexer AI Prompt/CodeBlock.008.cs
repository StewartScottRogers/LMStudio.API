public class PrintStatement : IAstNode
{
    public readonly Expression Expression;

    public PrintStatement(Expression expression)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitPrintStatement(this);
}