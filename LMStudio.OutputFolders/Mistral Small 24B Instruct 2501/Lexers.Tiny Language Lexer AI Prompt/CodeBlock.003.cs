// Represents the root node of a program.
public sealed record ProgramNode(List<StatementNode> Statements) : Node;