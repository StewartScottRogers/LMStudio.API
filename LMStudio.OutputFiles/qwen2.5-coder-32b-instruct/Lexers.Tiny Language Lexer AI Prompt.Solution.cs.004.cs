public abstract record AstNode;

public sealed record StatementListNode(List<AstNode> Statements) : AstNode;

public sealed record AssignNode(string Name, AstNode Expression) : AstNode;

public sealed record IfNode(AstNode Condition, AstNode ThenBranch) : AstNode;

public sealed record WhileNode(AstNode Condition, AstNode Body) : AstNode;

public sealed record PrintNode(AstNode Expression) : AstNode;

public abstract record ExprNode : AstNode;

public sealed record LiteralNode(string Value) : ExprNode;

public sealed record VariableNode(string Name) : ExprNode;

public sealed record GroupingExprNode(ExprNode Expression) : ExprNode;

public sealed record BinaryExprNode(ExprNode Left, TokenTypes OperatorType, ExprNode Right) : ExprNode;