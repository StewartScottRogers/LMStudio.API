namespace LexerLibrary
{
    public abstract class AstNode
    {
        // Base class for all AST nodes
    }

    public class ProgramNode : AstNode
    {
        public readonly var StatementListTuple StatementList;

        public ProgramNode(var statementList)
        {
            this.StatementList = statementList;
        }
    }

    public class StatementNode : AstNode
    {
        // Base class for all statements
    }

    public class AssignStatementNode : StatementNode
    {
        public readonly string Identifier;
        public readonly ExpressionNode Expression;

        public AssignStatementNode(string identifier, ExpressionNode expression)
        {
            this.Identifier = identifier;
            this.Expression = expression;
        }
    }

    // Define other AST nodes similarly...
}