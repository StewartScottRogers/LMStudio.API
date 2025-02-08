public class PrettyPrinter
{
    private readonly AstNode ast;

    public PrettyPrinter(AstNode ast)
    {
        this.ast = ast;
    }

    public void Print()
    {
        PrintNode(ast, 0);
    }

    private void PrintNode(AstNode node, int indentLevel)
    {
        var indent = new string(' ', indentLevel * 2);

        switch (node)
        {
            case CompoundStatement compoundStmt:
                Console.WriteLine($"{indent}CompoundStatement");
                foreach (var child in compoundStmt.Children)
                    PrintNode(child, indentLevel + 1);
                break;
            case AssignmentNode assignment:
                Console.WriteLine($"{indent}Assignment: {assignment.Left.Name}");
                PrintNode(assignment.Right, indentLevel + 1);
                break;
            case TypedAssignment typedAssignment:
                Console.WriteLine($"{indent}TypedAssignment: {typedAssignment.Left.Name}");
                if (typedAssignment.TypeExpr != null)
                {
                    Console.WriteLine($"{indent}Type:");
                    PrintNode(typedAssignment.TypeExpr, indentLevel + 2);
                }
                if (typedAssignment.Right != null)
                {
                    Console.WriteLine($"{indent}Right:");
                    PrintNode(typedAssignment.Right, indentLevel + 1);
                }
                break;
            case ReturnStatement returnStmt:
                Console.Write($"{indent}Return ");
                if (returnStmt.Expression != null)
                    PrintNode(returnStmt.Expression, indentLevel + 1);
                else
                    Console.WriteLine();
                break;
            case RaiseStatement raiseStmt:
                Console.Write($"{indent}Raise ");
                if (raiseStmt.Exception != null)
                    PrintNode(raiseStmt.Exception, indentLevel + 1);

                if (raiseStmt.Cause != null)
                {
                    Console.Write($"{indent}From: ");
                    PrintNode(raiseStmt.Cause, indentLevel + 2);
                }
                break;
            case Variable variable:
                Console.WriteLine($"{indent}Variable({variable.Name})");
                break;
            case NumberNode number:
                Console.WriteLine($"{indent}Number({number.Value})");
                break;
            case BinaryOperation binaryOp:
                Console.WriteLine($"{indent}BinaryOperation: {binaryOp.Operator}");
                PrintNode(binaryOp.Left, indentLevel + 1);
                PrintNode(binaryOp.Right, indentLevel + 1);
                break;
        }
    }
}