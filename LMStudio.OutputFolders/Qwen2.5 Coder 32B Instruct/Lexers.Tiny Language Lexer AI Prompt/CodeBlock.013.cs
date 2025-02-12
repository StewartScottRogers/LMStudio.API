public class Identifier : Factor
{
    public readonly string Name;

    public Identifier(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public override void Accept(IPrettyPrinter visitor) => visitor.VisitIdentifier(this);
}