namespace PythonLexer.Nodes.Expressions
{
    using Tokenizer.Tokens;

    public sealed class LiteralExpressionNode : INode
    {
        public readonly TokenKind LiteralType;
        public readonly string Value;

        public LiteralExpressionNode(Token token)
        {
            this.LiteralType = token.Kind == TokenKind.NumberLiteral ? TokenKind.NumberLiteral : TokenKind.StringLiteral;
            this.Value = token.Value ?? throw new ArgumentNullException(nameof(token));
        }
    }
}