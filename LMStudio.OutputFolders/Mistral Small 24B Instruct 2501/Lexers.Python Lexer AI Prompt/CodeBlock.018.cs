namespace LexerLibrary.AstNodes
{
    public class StatementNode : AstNode
    {
        public readonly CompoundStmtNode CompoundedStatement;
        public readonly SimpleStmtsNode SimpleStatements;

        public StatementNode(CompoundStmtNode compoundedStatement, SimpleStmtsNode simpleStatements)
        {
            this.CompoundedStatement = compoundedStatement;
            this.SimpleStatements = simpleStatements;
        }
    }

    public class CompoundStmt
    {

    }