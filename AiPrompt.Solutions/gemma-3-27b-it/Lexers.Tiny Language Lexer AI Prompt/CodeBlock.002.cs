// AstNode.cs
public class AstNode
{
    // Base class for all AST nodes.  Can add common properties here if needed.
}

// ProgramNode.cs
public class ProgramNode : AstNode
{
    public StatementListNode StatementList { get; set; }

    public ProgramNode(StatementListNode statementList)
    {
        StatementList = statementList;
    }
}

// StatementListNode.cs
public class StatementListNode : AstNode
{
    public List<AstNode> Statements { get; set; } = new List<AstNode>();

    public StatementListNode(List<AstNode> statements)
    {
        Statements = statements;
    }
}

// AssignStatementNode.cs
public class AssignStatementNode : AstNode
{
    public string Identifier { get; set; }
    public ExpressionNode Expression { get; set; }

    public AssignStatementNode(string identifier, ExpressionNode expression)
    {
        Identifier = identifier;
        Expression = expression;
    }
}

// ExpressionNode.cs (Base class for expressions)
public class ExpressionNode : AstNode
{
    // Common properties or methods for all expressions can go here
}

// IdentifierNode.cs
public class IdentifierNode : ExpressionNode
{
    public string Name { get; set; }

    public IdentifierNode(string name)
    {
        Name = name;
    }
}

// NumberNode.cs
public class NumberNode : ExpressionNode
{
    public int Value { get; set; }

    public NumberNode(int value)
    {
        Value = value;
    }
}