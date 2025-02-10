namespace LexerLibrary
{
    public readonly record AstNode(string Name, string Value)
    {
        public override string ToString() => $"Name: {Name}, Value: {Value}";
    }
}