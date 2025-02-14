// Utility to print AST nodes.
public class PrettyPrinter : NodeVisitor<string>
{
    public override string VisitProgramNode(ProgramNode node)
    {
        var statements = string.Join("\n", node.Statements.Select(Visit));
        return $"Program: {{\n{statements}\n}}";
    }

    public override string VisitAssignStatementNode(AssignStatementNode node)
    {
        return $"{node.Identifier} := {Visit(node.Expression)}";
    }

    public override string VisitIfStatementNode(IfStatementNode node)
    {
        var condition = Visit(node.Condition);
        var consequence = string.Join("\n", node.Consequence.Select(s => $"  {Visit(s)}"));
        return $"if ({condition}) then\n{{\n{consequence}\n}}";
    }

    public override string VisitWhileStatementNode(WhileStatementNode node)
    {
        var condition = Visit(node.Condition);
        var body = string.Join("\n", node.Body.Select(b => $"  {Visit(b)}"));
        return $"while ({condition}) do\n{{\n{body}\n}}";
    }

    public override string VisitPrintStatementNode(PrintStatementNode node)
    {
        return $"print({Visit(node.Expression)})";
    }

    public override string VisitIdentifierExpressionNode(IdentifierExpressionNode node)
    {
        return node.Value;
    }

    public override string VisitNumberExpressionNode(NumberExpressionNode node)
    {
        return node.Value.ToString();
    }

    public override string VisitBinaryExpressionNode(BinaryExpressionNode node)
    {
        var left = Visit(node.Left);
        var right = Visit(node.Right);
        return $"({left} {node.Operator} {right})";
    }

    public override string VisitGroupedExpressionNode(GroupedExpressionNode node)
    {
        return $"({Visit(node.Expression)})";
    }
}

// Abstract visitor pattern for AST nodes.
public abstract class NodeVisitor<T>
{
    public virtual T Visit(Node node) => node switch
    {
        ProgramNode p => VisitProgramNode(p),
        AssignStatementNode a => VisitAssignStatementNode(a),
        IfStatementNode i => VisitIfStatementNode(i),
        WhileStatementNode w => VisitWhileStatementNode(w),
        PrintStatementNode p => VisitPrintStatementNode(p),
        IdentifierExpressionNode i => VisitIdentifierExpressionNode(i),
        NumberExpressionNode n => VisitNumberExpressionNode(n),
        BinaryExpressionNode b => VisitBinaryExpressionNode(b),
        GroupedExpressionNode g => VisitGroupedExpressionNode(g),
        _ => throw new Exception($"Unknown node type: {node}")
    };

    public abstract T VisitProgramNode(ProgramNode node);

    public abstract T VisitAssignStatementNode(AssignStatementNode node);

    public abstract T VisitIfStatementNode(IfStatementNode node);

    public abstract T VisitWhileStatementNode(WhileStatementNode node);

    public abstract T VisitPrintStatementNode(PrintStatementNode node);

    public abstract T VisitIdentifierExpressionNode(IdentifierExpressionNode node);

    public abstract T VisitNumberExpressionNode(NumberExpressionNode node);

    public abstract T VisitBinaryExpressionNode(BinaryExpressionNode node);

    public abstract T VisitGroupedExpressionNode(GroupedExpressionNode node);
}