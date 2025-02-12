public interface IPrettyPrinter
{
    void VisitAssignmentStatement(AssignmentStatement node);
    void VisitIfStatement(IfStatement node);
    void VisitWhileStatement(WhileStatement node);
    void VisitPrintStatement(PrintStatement node);
    void VisitBinaryExpression(BinaryExpression node);
    void VisitIdentifier(Identifier node);
    void VisitNumberLiteral(NumberLiteral node);
    void VisitParenthesizedExpression(ParenthesizedExpression node);
}