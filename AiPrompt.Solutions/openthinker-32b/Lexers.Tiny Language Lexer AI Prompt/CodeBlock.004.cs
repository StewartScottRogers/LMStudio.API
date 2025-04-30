public interface IVisitor
{
    void VisitProgram(Program program);
    void VisitStatementList(StatementList statementList);
    void VisitAssignmentStatement(AssignmentStatement assignmentStatement);
    void VisitIfStatement(IfStatement ifStatement);
    void VisitWhileStatement(WhileStatement whileStatement);
    void VisitPrintStatement(PrintStatement printStatement);
    void VisitExpression(Expression expression);
    void VisitTerm(Term term);
    void VisitFactor(Factor factor);
}