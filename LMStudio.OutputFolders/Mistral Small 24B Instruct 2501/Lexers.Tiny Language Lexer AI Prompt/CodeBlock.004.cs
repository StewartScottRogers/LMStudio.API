// Represents a statement node in the AST.
public abstract record StatementNode : Node;

public sealed record AssignStatementNode(string Identifier, ExpressionNode Expression) : StatementNode;

public sealed record IfStatementNode(ExpressionNode Condition, List<StatementNode> Consequence) : StatementNode;

public sealed record WhileStatementNode(ExpressionNode Condition, List<StatementNode> Body) : StatementNode;

public sealed record PrintStatementNode(ExpressionNode Expression) : StatementNode;