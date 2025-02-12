public abstract class ASTNode { }

public class ProgramNode : ASTNode
{
    public StatementListNode Statements { get; set; }
}

public class StatementListNode : ASTNode
{
    public List<ASTNode> Statements { get; set; } = new List<ASTNode>();
}

public abstract class StatementNode : ASTNode { }

public class AssignStatementNode : StatementNode
{
    public IdentifierNode Target { get; set; }
    public ExpressionNode Value { get; set; }
}

public class IfStatementNode : StatementNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode ThenBranch { get; set; }
}

public class WhileStatementNode : StatementNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode Body { get; set; }
}

public class PrintStatementNode : StatementNode
{
    public ExpressionNode Expression { get; set; }
}

public abstract class ExpressionNode : ASTNode { }

public class BinaryExpressionNode : ExpressionNode
{
    public Token Operator { get; set; }
    public ExpressionNode Left { get; set; }
    public ExpressionNode Right { get; set; }
}

public class IdentifierNode : ExpressionNode
{
    public string Name { get; set; }
}

public class NumberNode : ExpressionNode
{
    public string Value { get; set; }
}