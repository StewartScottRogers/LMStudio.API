public class NumberLiteral : Factor
{
    public readonly double Value;

    public NumberLiteral(double value)
    {
        Value = value;
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitNumberLiteral(this);
}