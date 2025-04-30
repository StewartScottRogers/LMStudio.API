public class ASTPrettyPrinter
{
    private int indentLevel = 0;

    private void PrintIndent()
    {
        Console.Write(new string(' ', indentLevel * 2));
    }

    public void PrettyPrint(ASTNode node)
    {
        switch (node)
        {
            case ProgramNode programNode:
                PrettyPrint(programNode.Statements);
                break;
            case StatementListNode statementListNode:
                foreach (var statement in statementListNode.Statements)
                    PrettyPrint(statement);
                break;
            case AssignmentStatementNode assignmentStatementNode:
                PrintIndent();
                Console.WriteLine($"Assignment: {assignmentStatementNode.Identifier} = ");
                indentLevel++;
                PrettyPrint(assignmentStatementNode.Expression);
                indentLevel--;
                break;
            case IfStatementNode ifStatementNode:
                PrintIndent();
                Console.WriteLine("If:");
                indentLevel++;
                PrettyPrint(ifStatementNode.Condition);
                PrettyPrint(ifStatementNode.Consequence);
                indentLevel--;
                break;
            case WhileStatementNode whileStatementNode:
                PrintIndent();
                Console.WriteLine("While:");
                indentLevel++;
                PrettyPrint(whileStatementNode.Condition);
                PrettyPrint(whileStatementNode.Body);
                indentLevel--;
                break;
            case PrintStatementNode printStatementNode:
                PrintIndent();
                Console.Write("Print: ");
                PrettyPrint(printStatementNode.Expression);
                break;
            // Expressions
            case IdentifierExpressionNode identifierExpressionNode:
                PrintIndent();
                Console.WriteLine($"Identifier({identifierExpressionNode.Identifier})");
                break;
            case NumberExpressionNode numberExpressionNode:
                PrintIndent();
                Console.WriteLine($"Number({numberExpressionNode.Value})");
                break;
            case AdditionExpressionNode additionExpressionNode:
                PrintIndent();
                Console.WriteLine("Addition:");
                indentLevel++;
                PrettyPrint(additionExpressionNode.Left);
                PrettyPrint(additionExpressionNode.Right);
                indentLevel--;
                break;
            case SubtractionExpressionNode subtractionExpressionNode:
                PrintIndent();
                Console.WriteLine("Subtraction:");
                indentLevel++;
                PrettyPrint(subtractionExpressionNode.Left);
                PrettyPrint(subtractionExpressionNode.Right);
                indentLevel--;
                break;
            case MultiplicationExpressionNode multiplicationExpressionNode:
                PrintIndent();
                Console.WriteLine("Multiplication:");
                indentLevel++;
                PrettyPrint(multiplicationExpressionNode.Left);
                PrettyPrint(multiplicationExpressionNode.Right);
                indentLevel--;
                break;
            case DivisionExpressionNode divisionExpressionNode:
                PrintIndent();
                Console.WriteLine("Division:");
                indentLevel++;
                PrettyPrint(divisionExpressionNode.Left);
                PrettyPrint(divisionExpressionNode.Right);
                indentLevel--;
                break;
            case GroupedExpressionNode groupedExpressionNode:
                PrintIndent();
                Console.WriteLine("(");
                indentLevel++;
                PrettyPrint(groupedExpressionNode.Inner);
                indentLevel--;
                PrintIndent();
                Console.WriteLine(")");
                break;
            default:
                throw new ArgumentException($"Unknown AST node: {node}");
        }
    }
}