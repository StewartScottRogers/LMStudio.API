public interface IASTNode { }

public abstract class Statement : IASTNode { }
public class AssignStmtNode : Statement { /* fields and methods */ }

// Example AST Node Creation
var assignStatement = new AssignStmtNode() 
{
    Identifier = "x",
    ValueExpression = new ExprNode(/* ... */) // Created elsewhere
};