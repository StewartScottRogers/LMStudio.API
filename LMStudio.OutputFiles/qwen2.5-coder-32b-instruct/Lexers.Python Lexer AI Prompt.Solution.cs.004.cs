public abstract class AstNode {}

public class CompoundStatement : AstNode
{
    public List<AstNode> Children { get; }

    public CompoundStatement(List<AstNode> children)
    {
        this.Children = children;
    }
}

public class AssignmentNode : AstNode
{
    public Variable Left { get; }
    public AstNode Right { get; }

    public AssignmentNode(Variable left, AstNode right)
    {
        this.Left = left;
        this.Right = right;
    }
}

public class TypedAssignment : AstNode
{
    public Variable Left { get; }
    public AstNode TypeExpr { get; }
    public AstNode Right { get; }

    public TypedAssignment(Variable left, AstNode typeExpr)
    {
        this.Left = left;
        this.TypeExpr = typeExpr;
        this.Right = null;
    }

    public TypedAssignment(Variable left, AstNode typeExpr, AstNode right)
    {
        this.Left = left;
        this.TypeExpr = typeExpr;
        this.Right = right;
    }
}

public class ReturnStatement : AstNode
{
    public AstNode Expression { get; }

    public ReturnStatement(AstNode expression)
    {
        this.Expression = expression;
    }
}

public class RaiseStatement : AstNode
{
    public AstNode Exception { get; }
    public AstNode Cause { get; }

    public RaiseStatement(AstNode exception, AstNode cause)
    {
        this.Exception = exception;
        this.Cause = cause;
    }
}

public class Variable : AstNode
{
    public string Name { get; }

    public Variable(string name)
    {
        this.Name = name;
    }
}

public class NumberNode : AstNode
{
    public double Value { get; }

    public NumberNode(double value)
    {
        this.Value = value;
    }
}

public class BinaryOperation : AstNode
{
    public AstNode Left { get; }
    public Token OperatorToken { get; }
    public string Operator => OperatorToken.Value;
    public AstNode Right { get; }

    public BinaryOperation(AstNode left, Token op, AstNode right)
    {
        this.Left = left;
        this.OperatorToken = op;
        this.Right = right;
    }
}