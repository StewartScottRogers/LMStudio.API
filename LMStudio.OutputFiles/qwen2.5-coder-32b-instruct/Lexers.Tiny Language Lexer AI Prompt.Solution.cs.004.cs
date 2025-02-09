// AssignStmtNode.cs
namespace TinyLanguageParser
{
    public readonly record struct AssignStmtNode(string Identifier, ExprNode Expression) : Node;
}

// IfStmtNode.cs
namespace TinyLanguageParser
{
    public readonly record struct IfStmtNode(ExprNode Condition, StmtListNode TrueBranch) : Node;
}

// WhileStmtNode.cs
namespace TinyLanguageParser
{
    public readonly record struct WhileStmtNode(ExprNode Condition, StmtListNode Body) : Node;
}

// PrintStmtNode.cs
namespace TinyLanguageParser
{
    public readonly record struct PrintStmtNode(ExprNode Expression) : Node;
}

// ExprNode.cs
namespace TinyLanguageParser
{
    public abstract record ExprNode : Node;

    public readonly record struct BinaryExprNode(ExprNode Left, TokenKind Operator, ExprNode Right) : ExprNode;
    public readonly record struct UnaryExprNode(TokenKind Operator, ExprNode Operand) : ExprNode;
    public readonly record struct IdentifierExprNode(string Identifier) : ExprNode;
    public readonly record struct NumberExprNode(int Value) : ExprNode;
}

// StmtListNode.cs
namespace TinyLanguageParser
{
    public readonly record struct StmtListNode(Node[] Statements) : Node;
}