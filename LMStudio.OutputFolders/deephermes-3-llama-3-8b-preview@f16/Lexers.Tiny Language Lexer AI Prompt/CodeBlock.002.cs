public abstract class AstNode
{
    public int Line { get; }
    
    protected AstNode(int line)
    {
        Line = line;
    }

    // Implement methods to visit nodes or perform operations as needed...
}

// Example of an AST node for the "if" statement
public class IfStmt : AstNode
{
    public Expr Condition { get; }
    public Stmts ThenBranch { get; }

    public IfStmt(Expr condition, Stmts thenBranch, int line) 
        : base(line)
    {
        Condition = condition;
        ThenBranch = thenBranch;
    }
}