// Represents an expression node in the AST.
public abstract record ExpressionNode : Node;

public sealed record IdentifierExpressionNode(string Value) : ExpressionNode;

public sealed record NumberExpressionNode(double Value) : ExpressionNode;

public sealed record BinaryExpressionNode(ExpressionNode Left, string Operator, ExpressionNode Right) : ExpressionNode;

public sealed record GroupedExpressionNode(ExpressionNode Expression) : ExpressionNode;